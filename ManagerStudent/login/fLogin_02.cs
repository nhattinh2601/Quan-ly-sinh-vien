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
    public partial class fLogin_02 : Form
    {
        public fLogin_02()
        {
            InitializeComponent();
        }
        public static int GlobalUserID { get;private set; }
        public static void SetGlobalUserID(int userID)
        { GlobalUserID = userID; }
        public static int id_next;
        private void bt_cancel_Click(object sender, EventArgs e)
        {
            if(rdbStudent.Checked)
            {
                Register register = new Register();
                register.ShowDialog();
            }
            else
            {
                NewUserForm newUserForm = new NewUserForm();
                newUserForm.ShowDialog();
            }
        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            if(rdbStudent.Checked)
            {
                MY_DB db = new MY_DB();

                SqlDataAdapter adapter = new SqlDataAdapter();

                DataTable table = new DataTable();

                SqlCommand command = new SqlCommand("SELECT * FROM login WHERE username = @User AND password = @Pass", db.getConnection);
                command.Parameters.Add("@User", SqlDbType.VarChar).Value = TextBoxUsername.Text;
                command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = TextBoxPassword.Text;

                adapter.SelectCommand = command;
                // nếu làm theo video thì báo lỗi đọc ở chỗ tanle : lo_gin không có thì sửa cái câu lệnh coppy ở đoạn code trong word lại
                // đọc đoạn thông báo lỗi
                adapter.Fill(table);
                if ((table.Rows.Count > 0))
                {
                    //MessageBox.Show("Ok, next time will be go to Main Menu of App");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                /*
                FormContact formContact = new FormContact();
                formContact.ShowDialog();
                */
                MY_DB db = new MY_DB();

                SqlDataAdapter adapter = new SqlDataAdapter();

                DataTable table = new DataTable();

                SqlCommand command = new SqlCommand("SELECT * FROM hr WHERE uname = @User AND pwd = @Pass", db.getConnection);
                command.Parameters.Add("@User", SqlDbType.VarChar).Value = TextBoxUsername.Text;
                command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = TextBoxPassword.Text;

                adapter.SelectCommand = command;
                // nếu làm theo video thì báo lỗi đọc ở chỗ tanle : lo_gin không có thì sửa cái câu lệnh coppy ở đoạn code trong word lại
                // đọc đoạn thông báo lỗi
                adapter.Fill(table);
                if ((table.Rows.Count > 0))
                {
                    
                    foreach (DataRow row in table.Rows)
                    {
                        id_next= Convert.ToInt32(row["id"].ToString());
                    }
                    SetGlobalUserID(id_next);
                    FormContact formContact = new FormContact();
                    formContact.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void fLogin_02_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("../../images/cat.jpg");
            rdbStudent.Checked = true;
        }

        private void fLogin_02_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void bt_login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // Enter key pressed
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FortgotPassword fortgotPassword = new FortgotPassword();
            fortgotPassword.Show(this);
        }
    }
}
