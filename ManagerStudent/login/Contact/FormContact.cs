using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace login
{
    public partial class FormContact : Form
    {
        public FormContact()
        {
            InitializeComponent();
        }
        public int id_edit;
        private void ButtonAddContact_Click(object sender, EventArgs e)
        {
            AddNewContact addNewContact = new AddNewContact();
            addNewContact.Show(this);
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            EditContact editContact = new EditContact();
            editContact.Show(this);
        }
        MY_DB mydb = new MY_DB();

        private void ButtonSelectContact_Click(object sender, EventArgs e)
        {
            SelectContact01 selectContact = new SelectContact01();
            //MessageBox.Show(SelectContact.IDContact.ToString());
            selectContact.ShowDialog(this);
            SqlCommand command = new SqlCommand("select id,fname,lname,group_id,email,phone,address,pic,userid from mycontact where id=" + SelectContact.IDContact, mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                TextBoxIDRemove.Text = row["id"].ToString();
            }
        }

        private void ButtonShow_Click(object sender, EventArgs e)
        {
            ShowFullList showFullList = new ShowFullList();
            showFullList.Show(this);
        }
        Group group = new Group();
        private void ButtonGroupName_Click(object sender, EventArgs e)
        {


            try
            {
                int id = Convert.ToInt32(TextBoxID.Text);
                string name = TextBoxAddNewGroup.Text;
                int userid = fLogin_02.GlobalUserID;
                if(group.groupExist(id))
                {
                    MessageBox.Show("Dupplicate ");
                }
                else
                {
                    if (verif() && group.nameExist(name)==false)//chỗ này còn lỗi
                    {

                        try
                        {
                            if (group.insertGroup(id, name, userid))
                            {
                                MessageBox.Show("New Group Added", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                TextBoxID.Text = "";
                                TextBoxAddNewGroup.Text = "";
                                RefreshForm();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(" Dupplicate ID", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Empty Fields or Dupplicate ID", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input. Please check again !!!");
            }
        }
        bool verif()
        {
            if ((TextBoxID.Text.Trim() == "")
                || (TextBoxAddNewGroup.Text.Trim() == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void FormContact_Load(object sender, EventArgs e)
        {
            int id = fLogin_02.GlobalUserID;
            MY_DB mydb = new MY_DB();
            SqlCommand command = new SqlCommand("select id,f_name,l_name,uname,pwd,fig from hr where id=" + id, mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                LabelName.Text = row["f_name"].ToString() + row["l_name"].ToString();
                byte[] pic;
                pic = (byte[])row["fig"];
                MemoryStream picture = new MemoryStream(pic);
                PictureBoxUser.Image = Image.FromStream(picture);

            }


            try
            {
                ComboBoxSelectGroup.DataSource = group.getCourseByUserID();
                ComboBoxSelectGroup.DisplayMember = "name";
                ComboBoxSelectGroup.ValueMember = "id";
                id_edit = Convert.ToInt32(ComboBoxSelectGroup.SelectedValue.ToString());
            }
            catch (Exception ex)
            { }


        }
        Contact contact = new Contact();
        private void ButtonRemove_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("You really want to delete this contact ?", "Delete Contact", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                try
                {
                    int contactID = Convert.ToInt32(TextBoxIDRemove.Text);

                    if (contact.deleteContact(contactID))
                    {
                        MessageBox.Show("Contact deleted", "Delete Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TextBoxIDRemove.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Contact Not Deleted , Please Input valid value", "Deleted Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch
                {
                    MessageBox.Show("Please Enter A valid id", "Delete Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
        private void ButtonRemoveGroup_Click(object sender, EventArgs e)
        {
            try
            {
                int groupID = Convert.ToInt32(TextBoxRemoveGroup.Text);

                if (group.deleteGroup(groupID))
                {
                    MessageBox.Show("Group deleted", "Delete Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TextBoxIDRemove.Text = "";
                    RefreshForm();
                }
                else
                {
                    MessageBox.Show("Group Not Deleted , Please Input valid value", "Deleted Group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Please Enter A valid id", "Delete Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ButtonEditGroup_Click(object sender, EventArgs e)
        {
            try
            {

                id_edit = Convert.ToInt32(ComboBoxSelectGroup.SelectedValue.ToString());


                int groupID = id_edit;
                string name = TextBoxEnterNGroup.Text;
                if (group.updateGroup(groupID, name))
                {
                    MessageBox.Show("Group updated", "Update Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TextBoxEnterNGroup.Text = "";
                    RefreshForm();
                }
                else
                {
                    MessageBox.Show("Group Not Updated , Please Input valid value", "Update Group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Please Enter A valid id", "Update Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            RefreshForm();

        }
        public void RefreshForm()
        {
            int id = fLogin_02.GlobalUserID;
            MY_DB mydb = new MY_DB();
            SqlCommand command = new SqlCommand("select id,f_name,l_name,uname,pwd,fig from hr where id=" + id, mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                LabelName.Text = row["f_name"].ToString() + row["l_name"].ToString();
                byte[] pic;
                pic = (byte[])row["fig"];
                MemoryStream picture = new MemoryStream(pic);
                PictureBoxUser.Image = Image.FromStream(picture);

            }

            try
            {
                ComboBoxSelectGroup.DataSource = group.getCourseByUserID();
                ComboBoxSelectGroup.DisplayMember = "name";
                ComboBoxSelectGroup.ValueMember = "id";
                id_edit = Convert.ToInt32(ComboBoxSelectGroup.SelectedValue.ToString());
            }
            catch(Exception ex)
            { }



        }
        private void label10_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListGroup listGroup = new ListGroup();
            listGroup.ShowDialog(this);
            SqlCommand command = new SqlCommand("select * from mygroups where id=" + ListGroup.IDGroup, mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                TextBoxRemoveGroup.Text = row["id"].ToString();
            }
        }
    }
}
