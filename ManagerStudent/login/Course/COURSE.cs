using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login
{
    internal class COURSE
    {
        MY_DB mydb = new MY_DB();
        public bool checkCourseName(string courseName, int courseId = 0)// cái này bị thiếu
        {
            SqlCommand command = new SqlCommand("select * from Course where label=@cName and id <> @cID", mydb.getConnection);
            
            command.Parameters.Add("@cName",SqlDbType.VarChar).Value = courseName;
            command.Parameters.Add("@cID", SqlDbType.Int).Value = courseId;
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            command.ExecuteNonQuery();
            DataTable table = new DataTable();

            if((table.Rows.Count > 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool insertCourse(int Id,string lable,int period, string description)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Course (id, label, period,description)" +
                 " VALUES(@id,@lab, @per, @des)", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@lab", SqlDbType.VarChar).Value = lable;
            command.Parameters.Add("@per", SqlDbType.Int).Value = period;
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

        public bool deleteCourse(int id)
        {
            SqlCommand command = new SqlCommand("delete from Course where id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
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

        public bool updateCourse(int Id, string lable, int period, string description)
        {
            SqlCommand command = new SqlCommand("update Course set label=@lab,period=@per,description=@des" +
                " where id=@Id", mydb.getConnection);

            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@lab", SqlDbType.VarChar).Value = lable;
            command.Parameters.Add("@per", SqlDbType.Int).Value = period;
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

        public DataTable getCourse(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getAllCourse()
        {
            SqlCommand command = new SqlCommand("select * from Course",mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getCourseByID(int courseID)
        {
            SqlCommand command = new SqlCommand("select * from Course where id=@cid", mydb.getConnection);

            command.Parameters.Add("@cid", SqlDbType.VarChar).Value = courseID;
            
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }
        string execCount(string query)
        {
            SqlCommand cmd = new SqlCommand(query, mydb.getConnection);
            mydb.openConnection();
            String count = cmd.ExecuteScalar().ToString();
            mydb.closeConnection();
            return count;
        }

        public string totalCourse()
        {
            return execCount("select count(*) from Course");
        }

        public bool courseExist(int id)
        {
            SqlCommand command = new SqlCommand("select * from Course where id=@studentID", mydb.getConnection);

            command.Parameters.Add("@studentID", SqlDbType.Int).Value = id;

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
    }
}
