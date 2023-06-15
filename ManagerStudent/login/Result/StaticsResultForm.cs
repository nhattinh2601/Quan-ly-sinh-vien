using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace login
{
    public partial class StaticsResultForm : Form
    {
        public StaticsResultForm()
        {
            InitializeComponent();
        }
        Score score = new Score();
        DataTable dt = new DataTable();
        MY_DB mydb = new MY_DB();int a = 0, b = 0;
        public void StaticsResultForm_Load(object sender, EventArgs e)
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
                    if(  diem > 5 )
                    {
                        dataGridView1.Rows[i].Cells[4 + nCourse].Value = "dau";
                        a++;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[4 + nCourse].Value = "rot";
                        b++;
                 } 
                        
                }
            }

            
            dt = score.getAvgScoreByScore();
            
            foreach (DataRow dr in dt.Rows)
            {
                string label = dr["label"].ToString();
                string point = dr["AverageGrade"].ToString();
                chart2.Series["Series1"].Points.AddXY(label, point);
            }
            
            
            
            for(int i =0; i<dataGridView1.Rows.Count-1;i++)
            {
                string label =dataGridView1.Rows[i].Cells[1].Value.ToString();
                string point = dataGridView1.Rows[i].Cells[7].Value.ToString();
                chart1.Series["s1"].Points.AddXY(label, point);
            }

            if (a != 0)
            {
                chart3.Series["s2"].Points.AddXY("pass", a);
            }
            if(b!=0)
            {
                chart3.Series["s2"].Points.AddXY("fail", b);
            }    

        }
    }
}
