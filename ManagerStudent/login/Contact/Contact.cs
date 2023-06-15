using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace login
{
    internal class Contact
    {
        MY_DB mydb = new MY_DB();
        public bool insertContact(int id,string fname, string lname, string phone, string address,string email,int userid,int groupid, MemoryStream picture)
        {

            SqlCommand command = new SqlCommand("INSERT INTO mycontact ( id,fname, lname,group_id,phone,email,address,userid,pic)" +
                 " VALUES(@id,@fn, @ln, @grp, @phn,@mail,@adrs,@uid,@pic)", mydb.getConnection);

            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@grp", SqlDbType.Int).Value = groupid;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@mail",SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
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


        public bool updateContact(int id,string fname, string lname, string phone, string address, string email, int userid, int groupid, MemoryStream picture)
        {

            SqlCommand command = new SqlCommand("update mycontact set fname=@fn, lname=@ln,group_id=@grp,phone=@phn,email=@mail,address=@adrs,userid=@uid ,pic=@pic where id=@id", mydb.getConnection);

            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@grp", SqlDbType.Int).Value = groupid;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@mail", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
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
        public bool deleteContact(int contactID)
        {

            SqlCommand command = new SqlCommand("delete mycontact where id=@id", mydb.getConnection);

            
            command.Parameters.Add("@id", SqlDbType.Int).Value = contactID;
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

        public DataTable SelectContactList(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable GetContactByID(int contactID)
        {
            SqlCommand command = new SqlCommand("select id,fname,lname,group_id,email,phone,address,pic,userid from mycontact where id=@id", mydb.getConnection);
            command.Parameters.Add("@id",SqlDbType.Int).Value = contactID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


        public bool contactExist(int id)
        {
            SqlCommand command = new SqlCommand("select * from mycontact where id=@studentID", mydb.getConnection);

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
