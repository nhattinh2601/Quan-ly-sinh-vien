using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace login
{
    public partial class studentListForm : Form
    {
        public studentListForm()
        {
            InitializeComponent();
        }
        STUDENT student = new STUDENT();
        private void studentListForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDBDataSet.std' table. You can move, or remove it, as needed.
            this.stdTableAdapter.Fill(this.myDBDataSet.std);

            SqlCommand command = new SqlCommand("select * from std");
            DataGridView1.ReadOnly = true;

            // xử lý hình ảnh
            DataGridViewImageColumn pisCol = new DataGridViewImageColumn();
            // khởi tạo đối tượng làm việc với dạng hình ảnh
            DataGridView1.RowTemplate.Height = 80;
            DataGridView1.DataSource = student.getStudents(command);

            pisCol = (DataGridViewImageColumn)DataGridView1.Columns[7];
            pisCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            DataGridView1.AllowUserToAddRows = false;
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from std");
            DataGridView1.ReadOnly = true;
            // xử lý hình ảnh
            DataGridViewImageColumn pisCol = new DataGridViewImageColumn();
            // khởi tạo đối tượng làm việc với dạng hình ảnh
            DataGridView1.RowTemplate.Height = 80;
            DataGridView1.DataSource = student.getStudents(command);

            pisCol = (DataGridViewImageColumn)DataGridView1.Columns[7];
            pisCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            DataGridView1.AllowUserToAddRows = false;
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            UpdateDeleteStudentForm updateDeleteStdF = new UpdateDeleteStudentForm();
            // thu tu cua cac cot: id fname 1nane - bd gdr phn adrs pic
            updateDeleteStdF.TextBoxID.Text = DataGridView1.CurrentRow.Cells[0].Value.ToString();
            updateDeleteStdF.TextBoxFname.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();
            updateDeleteStdF.TextBoxLname.Text = DataGridView1.CurrentRow.Cells[2].Value.ToString();
            updateDeleteStdF.DateTimePicker1.Value = (DateTime)DataGridView1.CurrentRow.Cells[3].Value;
            // gender
            if ((DataGridView1.CurrentRow.Cells[4].Value.ToString() == "Female"))
            {
                updateDeleteStdF.RadioButtonFemale.Checked = true;
            }
            updateDeleteStdF.TextBoxPhone.Text = DataGridView1.CurrentRow.Cells[5].Value.ToString();
            updateDeleteStdF.TextBoxAddress.Text = DataGridView1.CurrentRow.Cells[6].Value.ToString();
            // code xu ly hinh anh up len, version 01, chay OK, tim hieu them de code nhe hon
            byte[] pic;
            pic = (byte[])DataGridView1.CurrentRow.Cells[7].Value;
            MemoryStream picture = new MemoryStream(pic);
            updateDeleteStdF.PictureBoxStudentImage.Image = Image.FromStream(picture);
            updateDeleteStdF.Show();
        }

        private void studentListForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
