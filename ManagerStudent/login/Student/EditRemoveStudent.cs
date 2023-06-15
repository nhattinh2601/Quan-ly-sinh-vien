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
    public partial class EditRemoveStudent : Form
    {
        public EditRemoveStudent()
        {
            InitializeComponent();
        }
        STUDENT student = new STUDENT();
        private void ButtonEditStudent_Click(object sender, EventArgs e)
        {
            try 
            {
                int id = Convert.ToInt32(txtStudentID.Text);
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
                else if(student.studentExist(id))
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
                || (txtStudentID.Text.Trim() == "")
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
                int studentID = Convert.ToInt32(txtStudentID.Text);

                if (student.deleteStudent(studentID))
                {
                    MessageBox.Show("Student deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStudentID.Text = "";
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
        private void fillGrid(SqlCommand command)
        {
            DataGridView1.ReadOnly = true;

            DataGridViewImageColumn picCol = new DataGridViewImageColumn();

            DataGridView1.RowTemplate.Height = 80;

            DataGridView1.DataSource = student.getStudents(command);

            picCol = (DataGridViewImageColumn)DataGridView1.Columns[7];

            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            DataGridView1.AllowUserToAddRows = false;

            //LabelTotalStudents.Text = ("Total Student : " + DataGridView1.Rows.Count);
        }
        private void EditRemoveStudent_Load(object sender, EventArgs e)
        {
            this.stdTableAdapter.Fill(this.myDBDataSet.std);
            fillGrid(new SqlCommand("select * from std"));
        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {
            txtStudentID.Text = DataGridView1.CurrentRow.Cells[0].Value.ToString();
            TextBoxFname.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();
            TextBoxLname.Text = DataGridView1.CurrentRow.Cells[2].Value.ToString();
            DateTimePicker1.Value = (DateTime)DataGridView1.CurrentRow.Cells[3].Value;
            // gender
            if ((DataGridView1.CurrentRow.Cells[4].Value.ToString() == "Female"))
            {
                RadioButtonFemale.Checked = true;
            }
            else
                RadioButtonMale.Checked = true;
            TextBoxPhone.Text = DataGridView1.CurrentRow.Cells[5].Value.ToString();
            TextBoxAddress.Text = DataGridView1.CurrentRow.Cells[6].Value.ToString();
            // image
            byte[] pic;
            pic = (byte[])DataGridView1.CurrentRow.Cells[7].Value;
            MemoryStream picture = new MemoryStream(pic);
            PictureBoxStudentImage.Image = Image.FromStream(picture);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
