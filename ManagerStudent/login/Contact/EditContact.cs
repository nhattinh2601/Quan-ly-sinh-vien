using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class EditContact : Form
    {
        public EditContact()
        {
            InitializeComponent();
        }
        Contact contact = new Contact();
        MY_DB mydb = new MY_DB();
        private void button2_Click(object sender, EventArgs e)
        {
            SelectContact selectContact = new SelectContact();
            //MessageBox.Show(SelectContact.IDContact.ToString());
            selectContact.ShowDialog(this);
            SqlCommand command = new SqlCommand("select id,fname,lname,group_id,email,phone,address,pic,userid from mycontact where id="+SelectContact.IDContact, mydb.getConnection);            
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            
            foreach (DataRow row in dataTable.Rows)
            {
                TextBoxID.Text=row["id"].ToString();
                TextBoxFName.Text=row["fname"].ToString();
                TextBoxLName.Text= row["lname"].ToString();
                TextBoxGroupID.Text = row["group_id"].ToString();
                TextBoxPhone.Text = row["phone"].ToString();
                TextBoxAddress.Text = row["address"].ToString();
                TextBoxEmail.Text = row["email"].ToString();
                byte[] pic;
                pic = (byte[])row["pic"];
                MemoryStream picture = new MemoryStream(pic);
                PictureBoxUser.Image = Image.FromStream(picture);

            }
            
        }

        private void ButtonEditContact_Click(object sender, EventArgs e)
        {
            try
            {
                //string count = user.totalUser();
                int userid = fLogin_02.GlobalUserID;
                int groupid = Convert.ToInt32(TextBoxGroupID.Text);
                int id = Convert.ToInt32(TextBoxID.Text); ;
                string lname = TextBoxLName.Text;
                string fname = TextBoxFName.Text;
                string email = TextBoxEmail.Text;
                string address = TextBoxAddress.Text;
                string phone = TextBoxPhone.Text;

                MemoryStream pic = new MemoryStream();


                if (verif())
                {

                    PictureBoxUser.Image.Save(pic, PictureBoxUser.Image.RawFormat);
                    try
                    {
                        if (contact.updateContact(id,fname, lname, phone, address, email, userid, groupid, pic))
                        {
                            MessageBox.Show(" Contact Edit Sucessful", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Edit Contact Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input. Please check again !!!");
            }
        }
        bool verif()
        {
            if ((TextBoxFName.Text.Trim() == "")
                || (TextBoxLName.Text.Trim() == "")
                || (TextBoxAddress.Text.Trim() == "")
                || (TextBoxPhone.Text.Trim() == "")
                || (TextBoxEmail.Text.Trim() == "")
                || (TextBoxGroupID.Text.Trim() == "")
                || (PictureBoxUser.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void ButtonUploadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = " Select Image(*.jpg;*png;*gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                PictureBoxUser.Image = Image.FromFile(opf.FileName);
            }
        }
    }
}
