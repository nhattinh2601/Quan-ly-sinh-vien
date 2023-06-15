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
    public partial class NewUserForm : Form
    {
        public NewUserForm()
        {
            InitializeComponent();
        }
        User user = new User();

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //string count = user.totalUser();
                int id = Convert.ToInt32(TextBoxID.Text);                
                string lname = TextBoxLName.Text;
                string fname = TextBoxFName.Text;
                string username = TextBoxUsername.Text;
                string pass = TextBoxPass.Text;
                string enterpass = TextBoxEnterNewPass.Text;


                MemoryStream pic = new MemoryStream();

                if (verif() && user.usernameExist(username) && user.userIDExist(id))
                {

                    PictureBoxUser.Image.Save(pic, PictureBoxUser.Image.RawFormat);
                    try
                    {
                        if (user.insertUser(id, lname, fname, username, pass, pic))
                        {
                            MessageBox.Show("New User Added", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Add User", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields or Information is Error (id or username is dupplicate)", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception )
            {
                MessageBox.Show("Invalid input , please check again !!!");
            }
        }
        bool verif()
        {
            if ((TextBoxFName.Text.Trim() == "")
                || (TextBoxLName.Text.Trim() == "")
                || (TextBoxID.Text.Trim() == "")
                || (TextBoxPass.Text.Trim() == "")
                || (TextBoxEnterNewPass.Text.Trim() == "")
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
