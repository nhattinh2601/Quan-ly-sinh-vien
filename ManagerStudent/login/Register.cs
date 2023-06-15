using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            try
            {
                // không cần hiển thị id lên
                Account account = new Account();
                string count = account.totalAccount();
                int id = Convert.ToInt32(TextBoxID.Text);
                string username = TextBoxNameLogin.Text;
                string enterpassword = TextBoxEnterPassword.Text;
                string pass = TextBoxPassword.Text;

                string count_user = account.dupplicate(username);
                int count_username = Convert.ToInt32(count_user);
                string email = TextBoxEmail.Text;
                // 

                if (verif())
                {
                    if (pass != enterpassword)
                    {
                        MessageBox.Show("Invalid Password", "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (count_username > 0 && account.userIDExist(id))
                        {
                            MessageBox.Show("Dupplicate Username of ID", "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            if (account.insertAccount(id, username, pass, email))
                            {
                                MessageBox.Show("New Account Added", "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Error", "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid", "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception ) { MessageBox.Show("Invalid Input or Dupplicate ID or Username"); }
        }
        bool verif()
        {
            if ((TextBoxNameLogin.Text.Trim() == "")
                || (TextBoxPassword.Text.Trim() == "")
                || (TextBoxEnterPassword.Text.Trim() == "")
                || (TextBoxEmail.Text.Trim() == ""))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit ?", "Notification", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = false;
            }
        }



        private void Register_Load(object sender, EventArgs e)
        {
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
