using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login
{
    internal class User
    {
        MY_DB mydb=new MY_DB();
        public DataTable getUserByID(Int32 userid)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand("select * from hr where ID=@uid", mydb.getConnection);
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            return table;
            
        }

        public bool insertUser(int id,string fname, string lname,  string username, string password, MemoryStream picture)
        {

            SqlCommand command = new SqlCommand("INSERT INTO hr ( id,f_name, l_name,uname,pwd, fig)" +
                 " VALUES(@id,@fn, @ln, @un, @pass,@pic)", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;           
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

        public bool usernameExist(string username,string operation,int userid=0)
        {
            string query = "";

            if(operation=="register")
            {
                query = "select * from hr where uname=@un";
            }
            else if(operation=="edit")
            {
                query = "select * from hr where uname=@un and id<>@uid";
            }
            SqlCommand command = new SqlCommand(query,mydb.getConnection);


            command.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            
            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool updateUser(int userid,string lname, string fname, string username, string password, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("update hr set f_name=@fn,l_name=@ln,uname=@un,pwd=@pass,fig=@pic where id=@uid", mydb.getConnection);

            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
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
        string execCount(string query)
        {
            SqlCommand cmd = new SqlCommand(query, mydb.getConnection);
            mydb.openConnection();
            String count = cmd.ExecuteScalar().ToString();
            mydb.closeConnection();
            return count;
        }
        public bool userIDExist(int id)
        {
            SqlCommand command = new SqlCommand("select * from hr where id=@studentID", mydb.getConnection);

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

        public bool usernameExist(string id)
        {
            SqlCommand command = new SqlCommand("select * from hr where uname=@studentID", mydb.getConnection);

            command.Parameters.Add("@studentID", SqlDbType.VarChar).Value = id;

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

        public string totalUser()
        {
            return execCount("select count(*) from hr");
        }
    }
}
