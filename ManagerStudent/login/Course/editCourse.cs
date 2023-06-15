using System;
using System.Data;
using System.Windows.Forms;

namespace login
{
    public partial class editCourse : Form
    {
        public editCourse()
        {
            InitializeComponent();
        }

        COURSE course = new COURSE();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(comboBox1.SelectedValue);
                DataTable table = new DataTable();
                table = course.getCourseByID(id);
                TextBoxLab.Text = table.Rows[0][1].ToString();
                numericUpDown1.Value = Int32.Parse(table.Rows[0][2].ToString());
                TextBoxDes.Text = table.Rows[0][3].ToString();
            }
            catch { }
        }

        private void editCourse_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = course.getAllCourse();
            comboBox1.DisplayMember = "label";
            comboBox1.ValueMember = "id";
            comboBox1.SelectedItem = "null";
        }

        private void fillCOmbo(int index)
        {
            comboBox1.DataSource = course.getAllCourse();
            comboBox1.DisplayMember = "label";
            comboBox1.ValueMember = "id";
            comboBox1.SelectedItem = "index";
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string name = TextBoxLab.Text;
                int hrs = (int)numericUpDown1.Value;
                string descr = TextBoxDes.Text;
                int id = (int)comboBox1.SelectedValue;

                if (!course.checkCourseName(name, Convert.ToInt32(comboBox1.SelectedValue)))
                {
                    MessageBox.Show("This Course Name Already Exist", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (course.courseExist(id))
                {
                    MessageBox.Show("ID Course id Dupplicate", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        if (course.updateCourse(id, name, hrs, descr))
                        {
                            MessageBox.Show("Course Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fillCOmbo(comboBox1.SelectedIndex);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Course Not Updated", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
