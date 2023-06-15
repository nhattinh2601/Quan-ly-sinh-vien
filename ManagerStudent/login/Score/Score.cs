using System.Data;
using System.Data.SqlClient;

namespace login
{
    internal class Score
    {
        MY_DB mydb = new MY_DB();
        public bool insertScore(int student_id, int course_id, float student_score, string description)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Score (student_id, course_id, student_score,description)" +
                 " VALUES(@id,@lab, @per, @des)", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = student_id;
            command.Parameters.Add("@lab", SqlDbType.VarChar).Value = course_id;
            command.Parameters.Add("@per", SqlDbType.Int).Value = student_score;
            command.Parameters.Add("@des", SqlDbType.VarChar).Value = description;
            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }

        public bool studentScoreExist(int studentID, int courseID)
        {
            SqlCommand command = new SqlCommand("select * from Score where student_id=@studentID and course_id = @courseID", mydb.getConnection);

            command.Parameters.Add("@cName", SqlDbType.VarChar).Value = studentID;
            command.Parameters.Add("@cID", SqlDbType.Int).Value = courseID;

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            if ((table.Rows.Count == 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public DataTable getAvgScoreByScore()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;

            command.CommandText = "select Course.label,avg(Score.student_score) as AverageGrade from Course,Score where Course.Id =" +
            "Score.course_id group by Course.label";

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }

        public bool deleteScore(int studentID, int courseID)
        {
            SqlCommand command = new SqlCommand("delete from Score where student_id=@student_id and course_id=@course_id", mydb.getConnection);

            command.Parameters.Add("@student_id", SqlDbType.Int).Value = studentID;
            command.Parameters.Add("@course_id", SqlDbType.Int).Value = courseID;

            mydb.openConnection();

            if ((command.ExecuteNonQuery() == 1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public DataTable getCourseScores(int courseID)
        {
            SqlCommand command = new SqlCommand();

            command.Connection = mydb.getConnection;
            command.CommandText = ("select Score.student_id,std.fname,std.lname,Score.course_id,Course.label,Score." +
            "student_score from std inner join score on std.id=score.student_id inner join course on score.course_id=course.ID where score.course_id=" + courseID);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);
            return table;
        }

        public DataTable getStudensScore()//1 khóa học nhiều học sinh
        {
            SqlCommand command = new SqlCommand();

            command.Connection = mydb.getConnection;

            command.CommandText = ("select Score.student_id as 'ID',std.fname as 'First Name',std.lname as 'Last Name',Course.label as 'Label',Score." +
                "student_score as 'Score' from std inner join score on std.id=score.student_id inner join course on score.course_id=Course.ID ");//where score.student_id= +studentID
            // bỏ điều kiện where và tham số truyền vào
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }

        public DataTable getStudenScores(int studentID)// 1 học sinh nhiều khóa học
        {
            SqlCommand command = new SqlCommand();

            command.Connection = mydb.getConnection;

            command.CommandText = ("select Score.student_id,std.fname,std.lname,Score.course_id,Course.label,Score." +
                "student_score from std inner join score on std.id=score.student_id inner join course on score.course_id=Course.ID where score.student_id=" + studentID);
            // bỏ điều kiện where và tham số truyền vào
            // coi lại sql 
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);
            return table;
        }

        public DataTable getTableScores(int studentID)// 1 học sinh nhiều khóa học
        {
            SqlCommand command = new SqlCommand();

            command.Connection = mydb.getConnection;

            command.CommandText = ("select Score.student_id,Score.course_id,Course.label,Score." +
                "student_score from std inner join score on std.id=score.student_id inner join course on score.course_id=Course.ID where score.student_id=" + studentID);
            // bỏ điều kiện where và tham số truyền vào
            // coi lại sql 
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);
            return table;
        }
        public DataTable getResult()// 1 học sinh nhiều khóa học
        {
            SqlCommand command = new SqlCommand();

            command.Connection = mydb.getConnection;

            command.CommandText = ("select std.Id,std.fname,std.lname,tableResult.id, " +
"tableResult.Machine_learning,tableResult.AI,tableResult.OOP,tableResult.Graph_Theory " +
"from std inner join tableResult on std.id = tableResult.id ");
            // bỏ điều kiện where và tham số truyền vào
            // coi lại sql 
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);
            return table;
        }

    }
}
