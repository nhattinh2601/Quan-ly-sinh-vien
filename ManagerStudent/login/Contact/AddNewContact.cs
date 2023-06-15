using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class AddNewContact : Form
    {
        public AddNewContact()
        {
            InitializeComponent();
        }
        Contact contact = new Contact();
        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //string count = user.totalUser();
                int userid = fLogin_02.GlobalUserID;
                int groupid = Convert.ToInt32(TextBoxGroupID.Text);
                int id = Convert.ToInt32(TextBoxID.Text);
                string lname = TextBoxLName.Text;
                string fname = TextBoxFName.Text;
                string email = TextBoxEmail.Text;
                string address = TextBoxAddress.Text;
                string phone = TextBoxPhone.Text;

                MemoryStream pic = new MemoryStream();


                if (verif())//&& contact.contactExist(id)
                {

                    PictureBoxUser.Image.Save(pic, PictureBoxUser.Image.RawFormat);
                    try
                    {
                        if (contact.insertContact(id,fname, lname, phone, address,email,userid, groupid, pic))
                        {
                            MessageBox.Show("New Contact Added", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TextBoxEmail.Text = "";
                            TextBoxID.Text = "";
                            TextBoxGroupID.Text = "";
                            TextBoxFName.Text = "";
                            TextBoxLName.Text = "";
                            TextBoxAddress.Text = "";
                            TextBoxPhone.Text = "";
                            PictureBoxUser.Image = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields or Dupplicate ID", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Invalid input. Please check again !!!");
            }
        }
        bool verif()
        {
            if ((TextBoxFName.Text.Trim() == "")
                || (TextBoxLName.Text.Trim() == "")
                || (TextBoxID.Text.Trim() == "")
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

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
