using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class ManageStudentForm : Form
    {
        public ManageStudentForm()
        {
            InitializeComponent();
        }

        STUDENT student = new STUDENT();

        private void fillGrid(SqlCommand command)
        {
            DataGridView1.ReadOnly = true;

            DataGridViewImageColumn picCol = new DataGridViewImageColumn();

            DataGridView1.RowTemplate.Height = 80;

            DataGridView1.DataSource = student.getStudents(command);

            picCol = (DataGridViewImageColumn)DataGridView1.Columns[7];

            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            DataGridView1.AllowUserToAddRows = false;

            LabelTotalStudents.Text = ("Total Student : " + DataGridView1.Rows.Count);
        }

        private void ManageStudentForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDBDataSet.std' table. You can move, or remove it, as needed.
            this.stdTableAdapter.Fill(this.myDBDataSet.std);
            fillGrid(new SqlCommand("select * from std"));
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
    
        private void ButtonDowload_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog svf = new SaveFileDialog();

            svf.FileName = ("Student_" +txtStudentID.Text);
            if((PictureBoxStudentImage.Image == null))
            {
                MessageBox.Show("No Image In The PictureBox");
            }
            else if((svf.ShowDialog() == DialogResult.OK))
            {
                PictureBoxStudentImage.Image.Save((svf.FileName +("." + ImageFormat.Jpeg.ToString())));
            }  
            
        }

        private void ButtonAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                STUDENT student = new STUDENT();
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
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Dupplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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



        private void phoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // tim theo id, phan mo rong se tim theo dien thoai. neu tim theo ten thi se xuat hien 1 form khac list toan bo ket qua trung ten
            int phone = int.Parse(TextBoxPhone.Text);
            SqlCommand command = new SqlCommand("SELECT id, lname, fname, bdate, gender, phone, address, picture FROM std WHERE id = " + phone);
            DataTable table = student.getStudents(command);
            if (table.Rows.Count > 0)
            {
                txtStudentID.Text = table.Rows[0]["Id"].ToString();
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
            int id = int.Parse(txtStudentID.Text);
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

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
