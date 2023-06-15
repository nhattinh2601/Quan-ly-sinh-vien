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
    public partial class PrintCourse : Form
    {
        public PrintCourse()
        {
            InitializeComponent();
        }

        private void PrintCourse_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDBDataSet.Course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.myDBDataSet.Course);
            SqlCommand command = new SqlCommand("select * from Course");

            fillGrid(command);
        }
        COURSE COURSE = new COURSE();
        private void fillGrid(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;

            DataGridViewImageColumn picCol = new DataGridViewImageColumn();

            dataGridView1.RowTemplate.Height = 80;

            dataGridView1.DataSource = COURSE.getCourse(command);


            dataGridView1.AllowUserToAddRows = false;

        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            /*
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\studewnts_list.txt";
            using (var writer = new StreamWriter(path))
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count - 1; j++)
                    {
                        writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString());

                    }
                    writer.WriteLine("");
                    writer.WriteLine("------------------------------------");
                }
            }
            */
        }
        private void ButtonSaveDocx_Click(object sender, EventArgs e)
        {
            /*
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Word Documents (.docx)|.docx";
            sfd.FileName = "Score.docx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Export_Data_To_Word(dataGridView1, sfd.FileName);
                MessageBox.Show("Save successful!!!", "Save File docx", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            */
            Document baoCao = new Document("wordd\\danhsachmonhoc.doc");




            Table Bangdiem = baoCao.GetChild(NodeType.Table, 0, true) as Table;//Lấy bảng thứ 1 trong file mẫu
            int hangHienTai = 1;
            //DataTable ressult = new DataTable();
            // ressult = score.getAVGResultByScore();
            int SoMonHoc = dataGridView1.Rows.Count;
            Bangdiem.InsertRows(hangHienTai, hangHienTai, SoMonHoc - 1);

            for (int i = 0; i < SoMonHoc; i++)
            {
                // int i = 1;
                int a = i + 1;
                Bangdiem.PutValue(hangHienTai, 0, a.ToString());
                Bangdiem.PutValue(hangHienTai, 1, dataGridView1.Rows[i].Cells[1].Value.ToString());
                Bangdiem.PutValue(hangHienTai, 2, dataGridView1.Rows[i].Cells[2].Value.ToString());
                Bangdiem.PutValue(hangHienTai, 3, dataGridView1.Rows[i].Cells[3].Value.ToString());


                hangHienTai++;
            }

            //bangThongTinGiaDinh.PutValue(1, 1, "C#");
            // bangThongTinGiaDinh.PutValue(2, 1, "Cloud Computing");
            //bangThongTinGiaDinh.PutValue(3, 1, "Machine learning");
            ///bangThongTinGiaDinh.PutValue(4, 1, "Java");

            baoCao.SaveAndOpenFile("PhieuDiem.doc");
        }

        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                int RowCount = dataGridView1.Rows.Count;
                int ColumnCount = dataGridView1.Columns.Count;
                Microsoft.Office.Interop.Word.Document oDoc = new Microsoft.Office.Interop.Word.Document();
                oDoc.Application.Visible = true;
                oDoc.PageSetup.Orientation = Microsoft.Office.Interop.Word.WdOrientation.wdOrientLandscape;
                //dynamic oRange = oDoc.Content.Application.Selection.Range;
                //string oTemp = "";
                Object oMissing = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Word.Range rng = oDoc.Range(0, 0);
                Word.Table thongtin = oDoc.Tables.Add(rng, dataGridView1.Rows.Count + 1, dataGridView1.Columns.Count);
                thongtin.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleDouble;
                thongtin.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    thongtin.Cell(1, i).Range.Text = dataGridView1.Columns[i - 1].HeaderText;
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
                        if (dataGridView1.Rows[r].Cells[c].Value == null)
                            thongtin.Cell(r + 2, c + 1).Range.InsertAfter("");
                        else
                            thongtin.Cell(r + 2, c + 1).Range.InsertAfter(dataGridView1.Rows[r].Cells[c].Value.ToString());
                        //oTemp = oTemp + dataGridView1.Rows[r].Cells[c].Value + "\t";

                    }
                    /*var oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                    oPara1.Range.Text = oTemp;
                    oPara1.Range.InsertParagraphAfter();*/
                    //oTemp += "\n";
                }
                //save the file
                oDoc.SaveAs2(filename);
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            object Nothing = System.Reflection.Missing.Value;
            var app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = false;
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Add(Nothing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets[1];
            worksheet.Name = "WorkSheet";
            // Write data
            worksheet.Cells[1, 1] = "ID";
            worksheet.Cells[1, 2] = "Label";
            worksheet.Cells[1, 3] = "Period";
            worksheet.Cells[1, 4] = "Description";
            //worksheet.Cells[2, 1] = dataGridView1.Rows[0].Cells[0].Value;
            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    //string text01 = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    worksheet.Cells[i+2,j+1] = dataGridView1.Rows[i].Cells[j].Value;
                }
            } 
            // Show save file dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                worksheet.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);
                workBook.Close(false, Type.Missing, Type.Missing);
                app.Quit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
