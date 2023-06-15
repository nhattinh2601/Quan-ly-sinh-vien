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
using ThuVienWinform.Report.AsposeWordExtension;//thêm thư viện này (File Lib\ReportExtentionMethod.cs)
using Word = Microsoft.Office.Interop.Word;
using Aspose.Words;//Thêm thư viện này (file Dll\Aspose.Word.dll)
using Aspose.Words.Tables;

namespace login
{
    public partial class ManagerScore : Form
    {
        public ManagerScore()
        {
            InitializeComponent();
        }
        Score score = new Score();
        STUDENT STUDENT = new STUDENT();
        COURSE COURSE = new COURSE();
        string data = "score";
        private void ManagerScore_Load(object sender, EventArgs e)
        {
            /*
            // TODO: This line of code loads data into the 'myDBDataSet.Score' table. You can move, or remove it, as needed.
            this.scoreTableAdapter.Fill(this.myDBDataSet.Score);
            */
            DataGridView1.DataSource = score.getStudensScore();

            ComboBoxSelectCourse.DataSource = COURSE.getAllCourse();
            ComboBoxSelectCourse.DisplayMember = "label";
            ComboBoxSelectCourse.ValueMember = "id";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            data = "score";
            DataGridView1.DataSource = score.getStudensScore();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            data = "std";
            SqlCommand command = new SqlCommand("SELECT Id as 'ID',fname as 'First Name',lname as 'Last Name',bdate as  'Birth Day' FROM std");
            DataGridView1.DataSource = STUDENT.getStudents(command);
        }

        void getDataFromDatagridView()
        {
            if (data == "std")
            {
                LabelTotalStudents.Text = DataGridView1.CurrentRow.Cells[0].Value.ToString();

            }
            else if (data == "score")
            {
                LabelTotalStudents.Text = DataGridView1.CurrentRow.Cells[0].Value.ToString();
                ComboBoxSelectCourse.SelectedValue = DataGridView1.CurrentRow.Cells[3].Value;
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getDataFromDatagridView();
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            AvarageScoreByCourse avarageScoreByCourse = new AvarageScoreByCourse();
            avarageScoreByCourse.Show(this);

        }

        private void ButtonAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                int studenID = Convert.ToInt32(TextBoxID.Text);
                int courseID = Convert.ToInt32(ComboBoxSelectCourse.SelectedValue);
                float scoreValue = Convert.ToInt32(TextBoxScore.Text);
                string description = TextBoxDes.Text;

                if (!score.studentScoreExist(studenID, courseID))
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

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            try 
            {
                int courseID = int.Parse(DataGridView1.CurrentRow.Cells[3].Value.ToString());
                int studentID = int.Parse(DataGridView1.CurrentRow.Cells[0].Value.ToString());


                if ((MessageBox.Show("Are Yousure Want to Detele This Score", "Remove Score", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    if (score.deleteScore(studentID, courseID))
                    {
                        MessageBox.Show("Course Deleted", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridView1.DataSource = score.getStudensScore();
                    }
                    else
                    {
                        MessageBox.Show("Course not Deleted", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Please Input Invalid ID and courseID !!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {
            if (DataGridView1.Rows.Count != 0)
            {
                int RowCount = DataGridView1.Rows.Count;
                int ColumnCount = DataGridView1.Columns.Count;
                Microsoft.Office.Interop.Word.Document oDoc = new Microsoft.Office.Interop.Word.Document();
                oDoc.Application.Visible = true;
                oDoc.PageSetup.Orientation = Microsoft.Office.Interop.Word.WdOrientation.wdOrientLandscape;
                //dynamic oRange = oDoc.Content.Application.Selection.Range;
                //string oTemp = "";
                Object oMissing = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Word.Range rng = oDoc.Range(0, 0);
                Word.Table thongtin = oDoc.Tables.Add(rng, DataGridView1.Rows.Count + 1, DataGridView1.Columns.Count);
                thongtin.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleDouble;
                thongtin.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                for (int i = 1; i < DataGridView1.Columns.Count + 1; i++)
                {
                    thongtin.Cell(1, i).Range.Text = DataGridView1.Columns[i - 1].HeaderText;
                }
                /*thongtin.Cell(1, 1).Range.Text = "MSSV";
                thongtin.Cell(1, 2).Range.Text = "Tên";
                thongtin.Cell(1, 3).Range.Text = "Họ và tên đệm";
                thongtin.Cell(1, 4).Range.Text = "Mô tả môn học";*/
                for (int r = 0; r <= RowCount - 1; r++)
                {
                    //oTemp = "";
                    for (int c = 0; c < ColumnCount; c++)
                    {
                        if (DataGridView1.Rows[r].Cells[c].Value == null)
                            thongtin.Cell(r + 2, c + 1).Range.InsertAfter("");
                        else
                            thongtin.Cell(r + 2, c + 1).Range.InsertAfter(DataGridView1.Rows[r].Cells[c].Value.ToString());
                        //oTemp = oTemp + dataGridView1.Rows[r].Cells[c].Value + "\t";

                    }
                    /*var oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                    oPara1.Range.Text = oTemp;
                    oPara1.Range.InsertParagraphAfter();*/
                    //oTemp += "\n";
                }
                try
                {
                    oDoc.SaveAs2(filename);

                }
                catch(Exception)
                { }
                //save the file
            }
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Word Documents (.docx)|.docx";
            sfd.FileName = "Score_new.docx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Export_Data_To_Word(DataGridView1, sfd.FileName);
                MessageBox.Show("Save successful!!!", "Save File docx", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
