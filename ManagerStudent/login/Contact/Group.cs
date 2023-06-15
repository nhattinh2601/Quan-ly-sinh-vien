using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login
{
    internal class Group
    {
        MY_DB mydb = new MY_DB();
        public bool insertGroup(int id, string name,int userid)
        {

            SqlCommand command = new SqlCommand("INSERT INTO mygroups ( id,name,userid)" +
                 " VALUES(@id,@name,@uid)", mydb.getConnection);

            command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;            
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
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

        public DataTable SelectGroupList(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool updateGroup(int id, string name)
        {

            SqlCommand command = new SqlCommand("update mygroups set name=@name where id=@id", mydb.getConnection);

            command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
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
        public bool deleteGroup(int groupID)
        {

            SqlCommand command = new SqlCommand("delete mygroups where id=@id", mydb.getConnection);


            command.Parameters.Add("@id", SqlDbType.Int).Value = groupID;
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

        public DataTable getGroups(int userid)
        {
            SqlCommand command = new SqlCommand("select * from mygroups where userid=@uid",mydb.getConnection);

            command.Parameters.Add("@uid",SqlDbType.Int).Value = userid;
            command.Connection = mydb.getConnection;

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }

        public bool groupExist(string name,string operation,int userid=0,int groupid=0)
        {
            string query = "";

            SqlCommand command = new SqlCommand();

            if(operation=="add")
            {
                query = " select * from mygroups where name = @name and userid = @uid";

                command.Parameters.Add("@name",SqlDbType.VarChar).Value = name;
                command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;

            }
            else if(operation=="edit")
            {
                query = "select * from mygroups where name=@name and userid=@uid and id=@gid ";

                command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
                command.Parameters.Add("@gid", SqlDbType.Int).Value = groupid;

            }

            command.Connection = mydb.getConnection;
            command.CommandText = query;

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);


            command.ExecuteNonQuery();
            if (table.Rows.Count>0)
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

        public bool groupExist(int id)
        {
            SqlCommand command = new SqlCommand("select * from mygroups where id=@studentID", mydb.getConnection);

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

        public bool nameExist(string name)
        {
            SqlCommand command = new SqlCommand("select * from mygroups where name=@studentID", mydb.getConnection);

            command.Parameters.Add("@studentID", SqlDbType.VarChar).Value = name;

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

        public DataTable getCourseByUserID()
        {
            SqlCommand command = new SqlCommand("select * from mygroups where userid="+fLogin_02.GlobalUserID, mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
