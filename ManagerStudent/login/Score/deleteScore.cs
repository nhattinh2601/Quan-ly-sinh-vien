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
    public partial class deleteScore : Form
    {
        public deleteScore()
        {
            InitializeComponent();
        }

        
        Score course = new Score();

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int courseID = Convert.ToInt32(TextBoxCourseID.Text);
                int studentID = Convert.ToInt32(TextBoxID.Text);

                if (course.deleteScore(studentID,courseID))
                {
                    MessageBox.Show("Student deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void TextBoxCourseID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
