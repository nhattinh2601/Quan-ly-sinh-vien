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
    public partial class RegisterCourseForm : Form
    {
        public RegisterCourseForm()
        {
            InitializeComponent();
        }
        Score score = new Score();
        COURSE course = new COURSE();
        STUDENT STUDENT = new STUDENT();


        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            COURSE course = new COURSE();

            try
            {
                int studenID = Convert.ToInt32(TextBoxID.Text);
                int courseID = Convert.ToInt32(ComboBoxSelectCourse.SelectedValue);
                float scoreValue = 0;
                string description = "";
                if (course.courseExist(studenID))
                {
                    MessageBox.Show("ID Course id Dupplicate", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(!score.studentScoreExist(studenID, courseID))
                {
                    if (score.insertScore(studenID, courseID, scoreValue, description))
                    {
                        MessageBox.Show("New Course Added", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void RegisterCourseForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDBDataSet.std' table. You can move, or remove it, as needed.
            this.stdTableAdapter.Fill(this.myDBDataSet.std);
            // TODO: This line of code loads data into the 'myDBDataSet.Course' table. You can move, or remove it, as needed.
            //this.courseTableAdapter.Fill(this.myDBDataSet.Course);
            ComboBoxSelectCourse.DataSource = course.getAllCourse();
            ComboBoxSelectCourse.DisplayMember = "label";
            ComboBoxSelectCourse.ValueMember = "id";

            SqlCommand command = new SqlCommand("select id,fname,lname from std");
            DataGridViewStudent.DataSource = STUDENT.getStudents(command);
        }

        private void DataGridViewStudent_Click_1(object sender, EventArgs e)
        {
            TextBoxID.Text = DataGridViewStudent.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
