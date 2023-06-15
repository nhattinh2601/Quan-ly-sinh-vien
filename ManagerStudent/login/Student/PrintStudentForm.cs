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
using System.Diagnostics;
using System.IO;

namespace login
{
    public partial class PrintStudentForm : Form
    {
        public PrintStudentForm()
        {
            InitializeComponent();
        }

        STUDENT sTUDENT = new STUDENT();
        private void fillGrid(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;

            DataGridViewImageColumn picCol = new DataGridViewImageColumn();

            dataGridView1.RowTemplate.Height = 80;

            dataGridView1.DataSource = sTUDENT.getStudents(command);

            picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];

            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AllowUserToAddRows = false;

        }

        private void PrintStudentForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDBDataSet.std' table. You can move, or remove it, as needed.
            this.stdTableAdapter.Fill(this.myDBDataSet.std);
            SqlCommand command = new SqlCommand("select * from std");

            fillGrid(command);
            if (RadioButtonNo.Checked)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
        }

        private void RadioButtonYes_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
        }

        private void RadioButtonNo_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
        }

        private void ButtonCheck_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            String query;

            if (RadioButtonYes.Checked)
            {


                string date1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");

                if (RadioButtonMale.Checked)
                {
                    query = "SELECT * FROM std WHERE gender = 'Male' AND bdate BETWEEN '" + date1 + " 'AND' " + date2 + "'";
                }
                else if (RadioButtonFemale.Checked)
                {
                    query = "SELECT * FROM std WHERE gender = 'Female' AND bdate BETWEEN '" + date1 + " 'AND' " + date2 + "'";
                }
                else
                {
                    query = "SELECT * FROM std WHERE bdate BETWEEN '" + date1 + " 'AND' " + date2 + "'";
                }
                command = new SqlCommand(query);
                fillGrid(command);

            }
            else
            {
                if (RadioButtonMale.Checked)
                {
                    query = "select * from std where gender = 'Male'";
                }
                else if (RadioButtonFemale.Checked)
                {
                    query = "select * from std where gender = 'female'";
                }
                else
                {
                    query = " select * from std ";
                }
                command = new SqlCommand(query);
                fillGrid(command);
            }
        }

        private void BunttonToPrint_Click(object sender, EventArgs e)
        {
            /*
            PrintDialog printDialog = new PrintDialog();
            //PrintDocument printDocument = new PrintDocument();
            printDocument.DocumentName = "Print Document";
            printDialog.Document = printDocument;
            printDialog.AllowSelection = true;
            printDialog.AllowSomePages = true;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
            */
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\studewnts_list.txt";
            using (var writer = new StreamWriter(path))
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }

                DateTime bdate;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count - 1; j++)
                    {
                        if (j == 3)
                        {
                            bdate = Convert.ToDateTime(dataGridView1.Rows[i].Cells[j].Value.ToString());
                            writer.Write("\t" + bdate.ToString("yyyy-MM-dd" + "\t" + "|"));
                        }
                        else if (j == dataGridView1.Columns.Count - 2)
                        {
                            writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString());
                        }
                        else
                        {
                            writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                        }
                    }
                    writer.WriteLine("");
                    writer.WriteLine("------------------------------------");
                }
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
            worksheet.Cells[1, 2] = "Last Name";
            worksheet.Cells[1, 3] = "First Name";
            worksheet.Cells[1, 4] = "Birth Day";
            worksheet.Cells[1, 5] = "Gender";
            worksheet.Cells[1, 6] = "Phone";
            worksheet.Cells[1, 7] = "Address";
            

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count - 1; j++)
                {
                    if (j == 3)
                    {
                        DateTime bdate = Convert.ToDateTime(dataGridView1.Rows[i].Cells[j].Value.ToString());
                        worksheet.Cells[i + 2, j + 1] = bdate.ToString("yyyy-MM-dd");
                    }
                    //string text01 = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
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
            DataTable dt = (DataTable)dataGridView1.DataSource;
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    Aspose.Words.Document baoCao = new Aspose.Words.Document("wordd\\Mau3.doc");

                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Word Documents (*.docx)|*.docx";
                    sfd.FileName = "Manager_Student.docx";

                    Style style = baoCao.Styles.Add(StyleType.Paragraph, "MyStyle1");
                    style.Font.Size = 11;
                    style.Font.Name = "Times New Roman";
                    style.ParagraphFormat.SpaceAfter = 12;



                    var homNay = DateTime.Now;

                    baoCao.MailMerge.Execute(new[] { "Ngay_Thang_Nam_BC" }, new[] { string.Format("TP.Hồ Chí Minh, ngày {0} tháng {1} năm {2}", homNay.Day, homNay.Month, homNay.Year) });

                    DocumentBuilder builder = new DocumentBuilder(baoCao);



                    Table bangThongTinGiaDinh = baoCao.GetChild(NodeType.Table, 1, true) as Table;
                    int hangHienTai = 1;
                    int count = dataGridView1.Rows.Count;
                    label1.Text = count.ToString();
                    bangThongTinGiaDinh.InsertRows(hangHienTai, hangHienTai, count - 1);
                    for (int i = 0; i < count; i++)
                    {
                        byte[] pic;
                        pic = (byte[])dataGridView1.Rows[i].Cells[7].Value;
                        MemoryStream picture = new MemoryStream(pic);

                        for (int j = 0; j < 7; j++)
                        {
                            if (j == 3)
                            { j += 1; }
                            bangThongTinGiaDinh.PutValue(hangHienTai, j, dataGridView1.Rows[i].Cells[j].Value.ToString());
                            builder.MoveToCell(1, hangHienTai, j, 0);
                            builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
                            builder.ParagraphFormat.Style = baoCao.Styles["MyStyle1"];
                        }

                        bangThongTinGiaDinh.PutValue(hangHienTai, 3, Convert.ToDateTime(dataGridView1.Rows[i].Cells[3].Value).ToString("dd/MM/yyyy"));
                        builder.MoveToCell(1, hangHienTai, 3, 0);
                        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
                        builder.ParagraphFormat.Style = baoCao.Styles["MyStyle1"];

                        builder.MoveToCell(1, hangHienTai, 7, 0);
                        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
                        builder.InsertImage(new Bitmap(System.Drawing.Image.FromStream(picture), new Size(100, 100)));
                        builder.RowFormat.Height = builder.CellFormat.Width;


                        hangHienTai++;
                    }
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        //Bước 4: Lưu và mở file

                        baoCao.Save(sfd.FileName);
                        Process.Start(sfd.FileName);

                        //baoCao.SaveAndOpenFile("BaoCao.doc");
                    }

                }
                else
                {
                    MessageBox.Show("No records to exported", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}// lưu hình ảnh dưới dạng đĩa tệp rồi dán nó vào
 // sửa lại exception nếu đang mở file thì không cho lưu lại




