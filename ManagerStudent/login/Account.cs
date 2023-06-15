using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login
{
    internal class Account
    {
        MY_DB db = new MY_DB();
        // function to insert a new student
        public bool insertAccount(int id, string username, string password,string email)
        {
            SqlCommand command = new SqlCommand("INSERT INTO login (Id, username, password,email)" +
                 " VALUES(@id, @user, @pass,@email)", db.getConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;

            db.openConnection();

            if ((command.ExecuteNonQuery() == 1))
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
        public bool updatePasswor(string username, string password)
        {
            SqlCommand command = new SqlCommand("update login set password = @pass where username=@username", db.getConnection);

            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }

        }

        public string getUserNameOfEmail(string email)
        {
            string userName = "";
            SqlCommand command = new SqlCommand("select * from login where email like @email ");

            command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            command.Connection = db.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                userName = table.Rows[0][0].ToString();
            }
            return userName;
        }

        public bool checkEmail(string email)
        {
            SqlCommand command = new SqlCommand("select * from login where email like @email ");

            command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            command.Connection = db.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable getStudents(SqlCommand command)
        {
            command.Connection = db.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        string execCount(string query)
        {
            SqlCommand cmd = new SqlCommand(query, db.getConnection);
            db.openConnection();
            String count = cmd.ExecuteScalar().ToString();
            db.closeConnection();
            return count;
        }

        public string totalAccount()
        {
            return execCount("select count(*) from login");
        }

        public string dupplicate(string username01)
        {
            return execCount("select count(*) from login where username='"+username01+"'");
        }

        public bool userIDExist(int id)
        {
            SqlCommand command = new SqlCommand("select * from login where Id=@studentID", db.getConnection);

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
