using System;
using System.Windows.Forms;

namespace login
{
    public partial class AddCourse : Form
    {
        public AddCourse()
        {
            InitializeComponent();
        }

        private void AddCourse_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void ButtonAddStudent_Click(object sender, EventArgs e)
        {

        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            COURSE course = new COURSE();
            try
            {
                int id = Convert.ToInt32(TextBoxID.Text);
                string lab = TextBoxLable.Text;
                int per = Convert.ToInt32(TextBoxPeriod.Text);
                string des = TextBoxDes.Text;

                if (verif())
                {
                    if (course.courseExist(id))
                    {
                        MessageBox.Show("ID Course id Dupplicate", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        if (course.insertCourse(id, lab, per, des))
                        {
                            MessageBox.Show("New Course Added", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TextBoxID.Text = "";
                            TextBoxDes.Text = "";
                            TextBoxLable.Text = "";
                            TextBoxPeriod.Text = "";
                        }

                    }

                }
                else
                {
                    MessageBox.Show("Empty Fields", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool verif()
        {
            if ((TextBoxLable.Text.Trim() == "")
                || (TextBoxPeriod.Text.Trim() == "")
                || (TextBoxDes.Text.Trim() == ""))
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
            this.Close();
        }
    }
}
