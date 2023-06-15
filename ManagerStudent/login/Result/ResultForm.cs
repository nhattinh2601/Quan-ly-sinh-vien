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

    public partial class ResultForm : Form
    {
        string[] chuoi = new string[10];
        public static DataTable Result = new DataTable();
        public static int vitri;
        public ResultForm()
        {
            InitializeComponent();
            customizeDesing();

        }
        private void customizeDesing()
        {
            panel1.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panel1.Visible == true)
                panel1.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == true)
            {
                subMenu.Visible = false;
            }
            else
                subMenu.Visible = true;
        }
        MY_DB mydb = new MY_DB();
        Score score = new Score();
        int id = 1;
        private void ResultForm_Load(object sender, EventArgs e)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable tableUser = new DataTable();
            SqlCommand command = new SqlCommand("select * from (select std.id as stdid,fname, lname, COURSE.id as courseid, LABEL  from std, course ) as q left join score on stdid = student_id and courseid = course_id order by stdid asc", mydb.getConnection);
            adapter.SelectCommand = command;
            adapter.Fill(tableUser);

            DataTable tableCourse = new DataTable();
            command = new SqlCommand("select * from course", mydb.getConnection);
            adapter.SelectCommand = command;
            adapter.Fill(tableCourse);

            int nCourse = tableCourse.Rows.Count;
            int nUser = tableUser.Rows.Count;
            int total = nUser / nCourse;
            dataGridView1.Columns.Add("id", "Student ID");//tên biến và tên hiển thị
            dataGridView1.Columns.Add("fname", "First Name");
            dataGridView1.Columns.Add("lname", "Last Name");
            foreach (DataRow VARIABLE in tableCourse.Rows)
            {
                dataGridView1.Columns.Add(VARIABLE["id"].ToString(), VARIABLE["label"].ToString());
            }
            dataGridView1.Columns.Add("av", "Average Score");
            dataGridView1.Columns.Add("res", "Results");
            // thêm các tên cột vào trong dataGridView


            double tong = 0;
            int dem = 1;
            //cột thứ 7 trong tableUser là điểm 
            //điền các điểm của từng môn từ hàng dọc vào hàng ngang
            //bởi vì câu lệnh select đầu tiên sẽ trả ra giá trị từng học sinh tương ứng với 1 môn học
            //trong bảng đó thì tên học sinh sẽ hiển thị nhiều lần tương ứng với số môn học cho nên
            //tổng số dòng sẽ là số học sinh * số môn học : tableUser 
            //cho nên tổng số học sinh sẽ bằng số dòng trong tableUser chia cho số môn học
            //thử các câu lệnh trong Sql Server
            for (int i = 0; i < total; i++)
            {
                dataGridView1.Rows.Add((DataGridViewRow)dataGridView1.Rows[0].Clone());
                dataGridView1.Rows[i].Cells[0].Value = tableUser.Rows[i * nCourse][0].ToString();
                dataGridView1.Rows[i].Cells[1].Value = tableUser.Rows[i * nCourse][1].ToString();
                dataGridView1.Rows[i].Cells[2].Value = tableUser.Rows[i * nCourse][2].ToString();
                //3 dòng đầu là tương ứng với các thông tin cơ bản của học sinh 
                // * nCourse vì sẽ in lần lượt hết các bảng điểm của học sinh (xem kết quá select trong Sql)
                tong = dem = 0;
                for (int j = 0; j < nCourse; j++)
                {
                    if (tableUser.Rows[j + i * nCourse][7].ToString().Trim() != "")
                    {
                        tong += Convert.ToDouble(tableUser.Rows[j + i * nCourse][7].ToString());
                        dem += 1;
                        //tính điểm trung bình
                    }
                    dataGridView1.Rows[i].Cells[3 + j].Value = tableUser.Rows[j + i * nCourse][7].ToString();
                    // cột thứ 7 là điểm trong bảng tableUser 
                    // j : duyệt từng môn trong danh sách môn 
                }
                if (dem != 0)
                {
                    double diem = (tong * 1.0 / dem);
                    dataGridView1.Rows[i].Cells[3 + nCourse].Value = Math.Round(diem, 2);
                    dataGridView1.Rows[i].Cells[4 + nCourse].Value = diem > 5 ? "Đạt" : "Rớt";
                }
            }
            /*
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                Result.Columns.Add(column.HeaderText);
            }

            //Adding the Rows.
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Result.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    Result.Rows[Result.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                }
            }
            */
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable tableUser = new DataTable();
            SqlCommand command = new SqlCommand("select * from (select std.id as stdid,fname, lname, COURSE.id as courseid, LABEL  from std, course ) as q left join score on stdid = student_id and courseid = course_id order by stdid asc", mydb.getConnection);
            adapter.SelectCommand = command;
            adapter.Fill(tableUser);

            DataTable tableCourse = new DataTable();
            command = new SqlCommand("select * from course", mydb.getConnection);
            adapter.SelectCommand = command;
            adapter.Fill(tableCourse);

            int nCourse = tableCourse.Rows.Count;
            int nUser = tableUser.Rows.Count;
            int total = nUser / nCourse;

            double tong = 0;
            int dem = 1;

            for (int i = 0; i < total; i++)
            {
                dataGridView1.Rows.Add((DataGridViewRow)dataGridView1.Rows[0].Clone());
                dataGridView1.Rows[i].Cells[0].Value = tableUser.Rows[i * nCourse][0].ToString();
                dataGridView1.Rows[i].Cells[1].Value = tableUser.Rows[i * nCourse][1].ToString();
                dataGridView1.Rows[i].Cells[2].Value = tableUser.Rows[i * nCourse][2].ToString();

                tong = dem = 0;
                for (int j = 0; j < nCourse; j++)
                {
                    if (tableUser.Rows[j + i * nCourse][7].ToString().Trim() != "")
                    {
                        tong += Convert.ToDouble(tableUser.Rows[j + i * nCourse][7].ToString());
                        dem += 1;

                    }
                    dataGridView1.Rows[i].Cells[3 + j].Value = tableUser.Rows[j + i * nCourse][7].ToString();

                }
                if (dem != 0)
                {
                    double diem = (tong * 1.0 / dem);
                    dataGridView1.Rows[i].Cells[3 + nCourse].Value = Math.Round(diem, 2);
                    dataGridView1.Rows[i].Cells[4 + nCourse].Value = diem > 5 ? "Đạt" : "Rớt";
                }
            }


            try
            {


                //string lName = TextBoxLname.Text;
                //string fName = TextBoxFname.Text;
                //MessageBox.Show(fName);
                //int id = Convert.ToInt32(textBox1.Text);
                List<string> termsList = new List<string>();
                string Search = TextBoxSearch.Text;

                String ten, ten1, ten2;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (button4.Text == "First Name")
                    {

                        string kq = dupplicate_fname(Search);
                        int result = Convert.ToInt32(kq);
                        if (result == 1)
                        {
                            if (Search == dataGridView1.Rows[i].Cells[1].Value.ToString())
                            {
                                vitri = i + 1;//bat dau tinh tu 1

                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please input another value");
                            //break;
                            return; // dùng để trả về giá trị dừng các hoạt động phía sau
                        }


                    }
                    if (button4.Text == "ID")
                    {
                        int id = Convert.ToInt32(TextBoxSearch.Text);
                        string kq = dupplicate(id);
                        int result = Convert.ToInt32(kq);
                        if (result == 1)
                        {
                            if (id == Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString()))
                            {
                                vitri = i + 1;//bat dau tinh tu 0                         

                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please input another value");
                            //break;
                            return; // dùng để trả về giá trị dừng các hoạt động phía sau
                        }


                    }
                }

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    string tmp = dataGridView1.Rows[vitri - 1].Cells[i].Value.ToString();
                    termsList.Add(tmp);
                }


                dataGridView1.Rows.Clear();
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Rows[0].Cells[i].Value = termsList[i];
                }

                string a = Convert.ToString(dataGridView1.Rows[0].Cells[1].Value);
                string b = Convert.ToString(dataGridView1.Rows[0].Cells[2].Value);
                string c = Convert.ToString(dataGridView1.Rows[0].Cells[0].Value);
                label10.Text = a + b;
                label9.Text = c;
                int ii = 0;
                chuoi[0] = Convert.ToString(dataGridView1.Rows[ii].Cells[0].Value);
                label1.Text = chuoi[0];
                chuoi[1] = Convert.ToString(dataGridView1.Rows[ii].Cells[1].Value);
                label2.Text = chuoi[1];
                chuoi[2] = Convert.ToString(dataGridView1.Rows[ii].Cells[2].Value);
                label3.Text = chuoi[2];
                chuoi[3] = Convert.ToString(dataGridView1.Rows[ii].Cells[3].Value);
                label5.Text = chuoi[3];
                chuoi[4] = Convert.ToString(dataGridView1.Rows[ii].Cells[4].Value);
                label6.Text = chuoi[4];
                chuoi[5] = Convert.ToString(dataGridView1.Rows[ii].Cells[5].Value);
                label7.Text = chuoi[5];
                chuoi[6] = Convert.ToString(dataGridView1.Rows[ii].Cells[6].Value);
                label8.Text = chuoi[6];
            }
            catch (Exception)
            {
                MessageBox.Show("Input Invalid");
            }


        }
        // viết đoạn code Sql để truy vấn ra , có thể thêm vào table , click chuột phải vào DataSet1 rồi nhấn add query
        // nếu khi tìm các bảng trong add dữ liệu cũng không ra thì có thể thử vào trong toolBox phần data để có thể add vd như DataSet hay tương tự vậy
        // đọc thêm các tài liệu về pivot table 
        // tìm hiểu thêm về add query in dataGridView , add thêm cột vào DataSet 
        // thực hiện các chức năng còn thiếu , còn rất nhiều chức năng khác chưa thêm vào 

        public bool insertStudent(int Id)
        {

            SqlCommand command = new SqlCommand("select * from std where Id =@id", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;

            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Word Documents (.docx)|.docx";
            sfd.FileName = "Score.docx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Export_Data_To_Word(dataGridView1, sfd.FileName);
                MessageBox.Show("Save successful!!!", "Save File docx", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Word Documents (.docx)|.docx";
                sfd.FileName = "export.docx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Export_Data_To_Word(dataGridView1, sfd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        string execCount(string query)
        {
            SqlCommand cmd = new SqlCommand(query, mydb.getConnection);
            mydb.openConnection();
            String count = cmd.ExecuteScalar().ToString();
            mydb.closeConnection();
            return count;
        }
        public string dupplicate(int username01)
        {
            return execCount("select count(*) from std where  Id =" + username01);
        }
        public string dupplicate_lname(string lname)
        {
            return execCount("select count(*) from std where  lname ='" + lname + "'");
        }
        public string dupplicate_fname(string fname)
        {
            return execCount("select count(*) from std where  fname ='" + fname + "'");
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable tableUser = new DataTable();
            SqlCommand command = new SqlCommand("select * from (select std.id as stdid,fname, lname, COURSE.id as courseid, LABEL  from std, course ) as q left join score on stdid = student_id and courseid = course_id order by stdid asc", mydb.getConnection);
            adapter.SelectCommand = command;
            adapter.Fill(tableUser);

            DataTable tableCourse = new DataTable();
            command = new SqlCommand("select * from course", mydb.getConnection);
            adapter.SelectCommand = command;
            adapter.Fill(tableCourse);

            int nCourse = tableCourse.Rows.Count;
            int nUser = tableUser.Rows.Count;
            int total = nUser / nCourse;

            double tong = 0;
            int dem = 1;
            //cột thứ 7 trong tableUser là điểm 
            //điền các điểm của từng môn từ hàng dọc vào hàng ngang
            //bởi vì câu lệnh select đầu tiên sẽ trả ra giá trị từng học sinh tương ứng với 1 môn học
            //trong bảng đó thì tên học sinh sẽ hiển thị nhiều lần tương ứng với số môn học cho nên
            //tổng số dòng sẽ là số học sinh * số môn học : tableUser 
            //cho nên tổng số học sinh sẽ bằng số dòng trong tableUser chia cho số môn học
            //thử các câu lệnh trong Sql Server
            for (int i = 0; i < total; i++)
            {
                dataGridView1.Rows.Add((DataGridViewRow)dataGridView1.Rows[0].Clone());
                dataGridView1.Rows[i].Cells[0].Value = tableUser.Rows[i * nCourse][0].ToString();
                dataGridView1.Rows[i].Cells[1].Value = tableUser.Rows[i * nCourse][1].ToString();
                dataGridView1.Rows[i].Cells[2].Value = tableUser.Rows[i * nCourse][2].ToString();
                //3 dòng đầu là tương ứng với các thông tin cơ bản của học sinh 
                // * nCourse vì sẽ in lần lượt hết các bảng điểm của học sinh (xem kết quá select trong Sql)
                tong = dem = 0;
                for (int j = 0; j < nCourse; j++)
                {
                    if (tableUser.Rows[j + i * nCourse][7].ToString().Trim() != "")
                    {
                        tong += Convert.ToDouble(tableUser.Rows[j + i * nCourse][7].ToString());
                        dem += 1;
                        //tính điểm trung bình
                    }
                    dataGridView1.Rows[i].Cells[3 + j].Value = tableUser.Rows[j + i * nCourse][7].ToString();
                    // cột thứ 7 là điểm trong bảng tableUser 
                    // j : duyệt từng môn trong danh sách môn 
                }
                if (dem != 0)
                {
                    double diem = (tong * 1.0 / dem);
                    dataGridView1.Rows[i].Cells[3 + nCourse].Value = Math.Round(diem, 2);
                    dataGridView1.Rows[i].Cells[4 + nCourse].Value = diem > 5 ? "Đạt" : "Rớt";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showSubMenu(panel1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button4.Text = "ID";
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button4.Text = "First Name";
            hideSubMenu();
        }

        public void Export_Data_To_Word_New(DataGridView DGV, string filename)
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

                oDoc.SaveAs2(filename);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                
                var homNay = DateTime.Now;
                //Bước 1: Nạp file mẫu
                Document baoCao = new Document("wordd\\Mau_Bao_Cao1.doc");
                DataTable dt = new DataTable();
                dataGridView1.DataSource = dt;
                
                baoCao.MailMerge.Execute(new[] { "Ho_Ten" }, new[] { label10.Text });
                baoCao.MailMerge.Execute(new[] { "Ngay_Sinh" }, new[] { label9.Text });
                


                //Bước 3: Điền thông tin lên bảng
                Table bangThongTinGiaDinh = baoCao.GetChild(NodeType.Table, 1, true) as Table;//Lấy bảng thứ 2 trong file mẫu
                int hangHienTai = 1;
                bangThongTinGiaDinh.InsertRows(hangHienTai, hangHienTai, dataGridView1.RowCount);
                for (int i = 1; i <= dataGridView1.RowCount; i++)
                {
                    
                    bangThongTinGiaDinh.PutValue(hangHienTai, 0, label1.Text);
                    bangThongTinGiaDinh.PutValue(hangHienTai, 1, label2.Text);//Cột Họ và tên
                    bangThongTinGiaDinh.PutValue(hangHienTai, 2, label3.Text);//Cột quan hệ
                    bangThongTinGiaDinh.PutValue(hangHienTai, 3, label5.Text);//Cột Số điện thoại
                    bangThongTinGiaDinh.PutValue(hangHienTai, 4, label6.Text);
                    bangThongTinGiaDinh.PutValue(hangHienTai, 5, label7.Text);
                    bangThongTinGiaDinh.PutValue(hangHienTai, 6, label8.Text);

                    hangHienTai++;
                }

                //Bước 4: Lưu và mở file
                baoCao.SaveAndOpenFile("BaoCao.doc");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }// viết thêm vòng vặp select từng cái table để select in ra result làm biến toàn cục

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
