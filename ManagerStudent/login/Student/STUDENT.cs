using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace login
{
    internal class STUDENT
    {
        MY_DB mydb = new MY_DB();
        // function to insert a new student
        public bool insertStudent(int Id, string lname, string fname, DateTime bdate, string gender, string phone, string address, MemoryStream picture)
        {
            
            SqlCommand command = new SqlCommand("INSERT INTO std (id, lname, fname, bdate, gender, phone, address, picture)" +
                 " VALUES(@id, @ln, @fn, @bdt, @gdr, @phn, @adrs, @pic)", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
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

        public bool updateStudent(int Id, string lname, string fname, DateTime bdate, string gender, string phone, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("update std set fname=@fn,lname=@ln,bdate=@bdt,gender=@gdr,phone=@phn,ad" +
                "dress=@adrs,picture=@pic where id=@ID", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
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
        public bool deleteStudent(int id)
        {
            SqlCommand command = new SqlCommand("delete from std where id = @id", mydb.getConnection);
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
        public DataTable getStudents(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
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

        public string totalStudent()
        {
            return execCount("select count(*) from std");
        }

        public string totalMaleStudent()
        {
            return execCount("select count(*) from std where gender='Male'");
        }

        public string totalFemaleStudent()
        {
            return execCount("select count(*) from std where gender='Female'");
        }

        public bool studentExist(int id)
        {
            SqlCommand command = new SqlCommand("select * from std where id=@studentID", mydb.getConnection);

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

