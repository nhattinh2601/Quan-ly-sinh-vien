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
    public partial class UpdateDeleteStudentForm : Form
    {
        public UpdateDeleteStudentForm()
        {
            InitializeComponent();
        }

        private void TextBoxID_TextChanged(object sender, EventArgs e)
        {

        }
        STUDENT student = new STUDENT();
        private void ButtonFind_Click(object sender, EventArgs e)
        {
            
        }
        // kiem tra nhap vao la ky tu
        private void TextBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        

        private void ButtonFindPhone_Click(object sender, EventArgs e)
        {
            

        }
        
        public string getFirstName
        {
            get
            {
                return TextBoxFname.Text;
            }
        }


       
        private void ButtonEditStudent_Click(object sender, EventArgs e)
        {
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
                    try
                    {
                        PictureBoxStudentImage.Image.Save(pic, PictureBoxStudentImage.Image.RawFormat);
                        if (student.updateStudent(id, lname, fname, bdate, gender, phone, adrs, pic))
                        {
                            MessageBox.Show("Student Infor Updated", "Adit Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error", "Adit Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Edit students", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int studentID = Convert.ToInt32(TextBoxID.Text);

                if (student.deleteStudent(studentID))
                {
                    MessageBox.Show("Student deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TextBoxID.Text = "";
                    TextBoxAddress.Text = "";
                    TextBoxFname.Text = "";
                    TextBoxLname.Text = "";
                    TextBoxPhone.Text = "";
                    DateTimePicker1.Value = DateTime.Now;
                    PictureBoxStudentImage.Image = null;
                }
                else
                {
                    MessageBox.Show("Student Not Deleted", "Deleted Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Please Enter A valid id", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void UpdateDeleteStudentForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }




        private void phoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // tim theo id, phan mo rong se tim theo dien thoai. neu tim theo ten thi se xuat hien 1 form khac list toan bo ket qua trung ten
            int phone = int.Parse(TextBoxPhone.Text);
            SqlCommand command = new SqlCommand("SELECT id, lname, fname, bdate, gender, phone, address, picture FROM std WHERE id = " + phone);
            DataTable table = student.getStudents(command);
            if (table.Rows.Count > 0)
            {
                TextBoxID.Text = table.Rows[0]["Id"].ToString();
                TextBoxLname.Text = table.Rows[0]["lname"].ToString();
                TextBoxFname.Text = table.Rows[0]["fname"].ToString();
                DateTimePicker1.Value = (DateTime)table.Rows[0]["bdate"];
                // gender
                if (table.Rows[0]["gender"].ToString() == "Female")
                {
                    RadioButtonFemale.Checked = true;
                }
                else
                {
                    RadioButtonMale.Checked = true;
                }

                TextBoxAddress.Text = table.Rows[0]["address"].ToString();
                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                PictureBoxStudentImage.Image = Image.FromStream(picture);
            }
            else
            {
                MessageBox.Show("not| found", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void iDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // tim theo id, phan mo rong se tim theo dien thoai. neu tim theo ten thi se xuat hien 1 form khac list toan bo ket qua trung ten
            int id = int.Parse(TextBoxID.Text);
            SqlCommand command = new SqlCommand("SELECT id, lname, fname, bdate, gender, phone, address, picture FROM std WHERE id = " + id);
            DataTable table = student.getStudents(command);
            if (table.Rows.Count > 0)
            {
                TextBoxLname.Text = table.Rows[0]["lname"].ToString();
                TextBoxFname.Text = table.Rows[0]["fname"].ToString();
                DateTimePicker1.Value = (DateTime)table.Rows[0]["bdate"];
                // gender
                if (table.Rows[0]["gender"].ToString() == "Female")
                {
                    RadioButtonFemale.Checked = true;
                }
                else
                {
                    RadioButtonMale.Checked = true;
                }
                TextBoxPhone.Text = table.Rows[0]["phone"].ToString();
                TextBoxAddress.Text = table.Rows[0]["address"].ToString();
                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                PictureBoxStudentImage.Image = Image.FromStream(picture);
            }
            else
            {
                MessageBox.Show("not| found", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void TextBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            formSearch search = new formSearch();
            search.Show(this);
        }
    }
}
