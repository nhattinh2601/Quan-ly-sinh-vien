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
    public partial class RemoveScore : Form
    {
        public RemoveScore()
        {
            InitializeComponent();
        }
        Score Score = new Score();
        private void RemoveScore_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDBDataSet.Score' table. You can move, or remove it, as needed.
            //this.scoreTableAdapter.Fill(this.myDBDataSet.Score);
            dataGridView1.DataSource = score.getStudensScore();

        }
        int studentID;
        int courseID;
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView1.CurrentRow.Cells[0].Value != null && dataGridView1.CurrentRow.Cells[1].Value != null && dataGridView1.CurrentRow.Cells[2].Value != null && dataGridView1.CurrentRow.Cells[3].Value != null)
                {
                    studentID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    courseID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+" Nhan cho co du lieu !!!");
            }
            
            
        }
        Score score = new Score();

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            try 
            {
                if(score.deleteScore(studentID, courseID))
                {
                    MessageBox.Show("Delete Seccessful", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"Error!!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
