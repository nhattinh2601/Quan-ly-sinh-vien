using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class ManagerCourseForm : Form
    {

        COURSE COURSE = new COURSE();
        int pos;
        public ManagerCourseForm()
        {
            InitializeComponent();
        }

        private void ManagerCourseForm_Load(object sender, EventArgs e)
        {
            reloadListBoxData();
        }
        void reloadListBoxData()
        {
            ListBox.DataSource = COURSE.getAllCourse();
            ListBox.ValueMember = "id";
            ListBox.DisplayMember = "label";

            ListBox.SelectedItem = null;

            LabelTotalCourses.Text = ("Total Course : " + COURSE.totalCourse());
        }
        void showData(int index)
        {
            DataRow dr = COURSE.getAllCourse().Rows[index];

            ListBox.SelectedIndex = index;

            TextBoxID.Text = dr.ItemArray[0].ToString();

            TextBoxLable.Text = dr.ItemArray[1].ToString();

            NumericUpDownPeriod.Value = int.Parse(dr.ItemArray[2].ToString());

            TextBoxDes.Text = dr.ItemArray[3].ToString();
        }

        private void ListBox_Click(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)ListBox.SelectedItem;

            pos = ListBox.SelectedIndex;

            showData(pos);
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(TextBoxID.Text);
                string lab = TextBoxLable.Text;
                int per = Convert.ToInt32(NumericUpDownPeriod.Value);
                string des = TextBoxDes.Text;



                if (verif())
                {
                    if (COURSE.courseExist(id))
                    {
                        MessageBox.Show("ID Course id Dupplicate", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        if (COURSE.insertCourse(id, lab, per, des))
                        {
                            MessageBox.Show("New Course Added", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TextBoxID.Text = "";
                            TextBoxDes.Text = "";
                            TextBoxLable.Text = "";
                        }

                    }

                }
                else
                {
                    MessageBox.Show("Empty Fields", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Invalid Infomation !");
            }
        }
        bool verif()
        {
            if ((TextBoxLable.Text.Trim() == "")
                || (TextBoxDes.Text.Trim() == ""))
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
                int courseID = Convert.ToInt32(TextBoxID.Text);

                if (COURSE.deleteCourse(courseID))
                {
                    MessageBox.Show("Student deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TextBoxID.Text = "";
                    TextBoxLable.Text = "";
                    NumericUpDownPeriod.Value = 0;
                    TextBoxDes.Text = "";
                    reloadListBoxData();

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

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string name = TextBoxLable.Text;
                int hrs = (int)NumericUpDownPeriod.Value;
                string descr = TextBoxDes.Text;
                int id = (int)Convert.ToInt32(TextBoxID.Text);

                if (!COURSE.checkCourseName(name, Convert.ToInt32(TextBoxID.Text)))
                {
                    MessageBox.Show("This Course Name Already Exist", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (COURSE.courseExist(id))
                {
                    MessageBox.Show("ID Course id Dupplicate", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (COURSE.updateCourse(id, name, hrs, descr))
                {
                    MessageBox.Show("Course Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reloadListBoxData();
                }
                else
                {
                    MessageBox.Show("Course Not Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonFirst_Click(object sender, EventArgs e)
        {
            pos = 0;
            showData(pos);
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if(pos < (COURSE.getAllCourse().Rows.Count-1))
            {
                pos = pos + 1;
                showData(pos);
            }
        }

        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            if(pos>0)
            {
                pos = pos - 1;
                showData(pos);
            }
        }

        private void ButtonLast_Click(object sender, EventArgs e)
        {
            pos = COURSE.getAllCourse().Rows.Count-1;
            showData(pos);
        }

        private void TextBoxID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
