using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace login
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = " Select Image(*.jpg;*png;*gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                PictureBoxStudentImage.Image = Image.FromFile(opf.FileName);
            }
        }
        // dua o duoi sau khi sua bi loi thi ta dua len tren 
        private void ButtonAddStudent_Click(object sender, EventArgs e)
        {
            STUDENT student = new STUDENT();
            try
            {
                int id = Convert.ToInt32(TextBoxID.Text);
                string lname = TextBoxLname.Text;
                string fname = TextBoxFname.Text;
                DateTime bdate = DateTimePicker1.Value;
                string phone = TextBoxPhone.Text;
                string adrs = TextBoxAddress.Text;
                string gender = "Male";
                if (RadioButtonFemale.Checked)
                {
                    gender = "Female";
                }

                MemoryStream pic = new MemoryStream();
                int born_year = DateTimePicker1.Value.Year;
                int this_year = DateTime.Now.Year;

                if ((this_year - born_year) < 10 || (this_year - born_year) > 100)
                {
                    MessageBox.Show("The Student Age Must Be Between 10 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (student.studentExist(id) == true)
                {
                    MessageBox.Show("The Student ID Id Dupplicate", "Invalid Student ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (verif())
                {

                    PictureBoxStudentImage.Image.Save(pic, PictureBoxStudentImage.Image.RawFormat);
                    try
                    {
                        if (student.insertStudent(id, lname, fname, bdate, gender, phone, adrs, pic))
                        {
                            MessageBox.Show("New Student Added", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getReturnTextBox();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void getReturnTextBox()
        {
            TextBoxID.Text = "";
            TextBoxFname.Text = "";
            TextBoxLname.Text = "";
            TextBoxAddress.Text = "";
            TextBoxPhone.Text = "";
            PictureBoxStudentImage.Image = null;
        }
        bool verif()
        {
            if ((TextBoxFname.Text.Trim() == "")
                || (TextBoxLname.Text.Trim() == "")
                || (TextBoxAddress.Text.Trim() == "")
                || (TextBoxPhone.Text.Trim() == "")
                || (PictureBoxStudentImage.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxLname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStudentID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBoxPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
