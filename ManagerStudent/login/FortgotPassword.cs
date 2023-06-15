using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class FortgotPassword : Form
    {
        string randomcode;
        public static string to;
        public FortgotPassword()
        {
            InitializeComponent();
        }
        Account account = new Account();

        private void button1_Click(object sender, EventArgs e)
        {
            if (account.checkEmail(textBoxEmai.Text))
            {

                try
                {
                    string from, pass, messageBody;
                    // code rank
                    Random rand = new Random();
                    randomcode = rand.Next(999999).ToString();
                    messageBody = "Your reset code is: " + randomcode;
                    ///tạo email

                    //email ngươi nhận
                    to = textBoxEmai.Text;
                    // email gui
                    from = "congchap27042002@gmail.com";
                    pass = "congchap555";

                    MailMessage message = new MailMessage();
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    message.From = new MailAddress(from);
                    message.To.Add(to);

                    message.Subject = "password reseting code";
                    message.IsBodyHtml = true;
                    message.Body = messageBody;

                    message.Priority = MailPriority.High;

                    smtp.Port = 587;

                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, pass);


                    smtp.EnableSsl = true;
                    smtp.Send(message);
                    MessageBox.Show("Code send successfully");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw ;
                }
            }
            else
            {
                label4.Visible = true;
            }
        }

        private void Quên_MK_Load(object sender, EventArgs e)
        {
            textBoxEmai.Focus();
        }

        private void buttonResetpassword_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text.Trim() == "")
            {
                labelTestpasword.Text = "Password empty";
               // labelTestpasword.Visible = true;

            }
            if (textBoxConfirmpassword.Text.Trim() == "")
            {
                labelTestForgotPassword.Text = "Password empty";
              //  labelTestForgotPassword.Visible = true;

            }
            if (textBoxPassword.Text.Trim() != textBoxConfirmpassword.Text.Trim())
            {
                labelTestForgotPassword.Text = "Re-entered password does not match ";
              //  labelTestForgotPassword.Visible = true;
            }
            else if (randomcode == textBoxCodeFG.Text.ToString())
            {
                string username = TextBoxUserName.Text;
                string password = textBoxPassword.Text;
                if (account.updatePasswor(username, password))
                {
                    MessageBox.Show("Reset password success", "Forget password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Reset password unsuccessful", "Forget password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                labelTestcode.Text = "Wrong code";
            }
        }

        private void textBoxEmai_Leave(object sender, EventArgs e)
        {
            if (textBoxEmai.Text.Trim() == "")
            {
                labelTestMai.Text = "Email empty";
           //     labelTestMai.Visible = true;
            }
            else if (!account.checkEmail(textBoxEmai.Text))
            {
                labelTestMai.Text = "Email is not in use";
              //  labelTestMai.Visible = true;
            }
            else
            {
                labelUserNameEmail.Text = "User Name Of Email: " + account.getUserNameOfEmail(textBoxEmai.Text);
            //    labelUserNameEmail.Visible = true;
                labelTestMai.Visible = false;
            }
        }

        private void textBoxConfirmpassword_Enter(object sender, EventArgs e)
        {
            labelTestForgotPassword.Visible = false;
        }

        private void labelTestcode_Click(object sender, EventArgs e)
        {

        }

        private void imgNextStep1_Click(object sender, EventArgs e)
        {

        }
    }
}
