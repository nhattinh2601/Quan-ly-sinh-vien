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

namespace login
{
    public partial class formSearch : Form
    {
        public formSearch()
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
            if(panel1.Visible==true)
                panel1.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if(subMenu.Visible==true)
            {
                subMenu.Visible = false;
            }    
            else
                subMenu.Visible = true;
        }
        public void Search()
        {
            STUDENT sTUDENT = new STUDENT();
            UpdateDeleteStudentForm up1 = new UpdateDeleteStudentForm();
            // TODO: This line of code loads data into the 'myDBDataSet.std' table. You can move, or remove it, as needed.
            //this.stdTableAdapter.Fill(this.myDBDataSet.std);

            string fname = Convert.ToString(TextBoxSearch.Text);
            SqlCommand command;
            if (button2.Text == "ID")
                command = new SqlCommand("SELECT id, lname, fname, bdate, gender, phone, address, picture FROM std WHERE id like '%" + fname + "%'");
            else if (button2.Text == "Name")
                command = new SqlCommand("SELECT id, lname, fname, bdate, gender, phone, address, picture FROM std WHERE fname like '%" + fname + "%'");
            else
                command = new SqlCommand("SELECT id, lname, fname, bdate, gender, phone, address, picture FROM std WHERE phone like '%" + fname + "%'");

            dataGridView1.ReadOnly = true;
            // xử lý hình ảnh
            DataGridViewImageColumn pisCol = new DataGridViewImageColumn();
            // khởi tạo đối tượng làm việc với dạng hình ảnh
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = sTUDENT.getStudents(command);

            pisCol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            pisCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AllowUserToAddRows = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void formSearch_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDBDataSet.std' table. You can move, or remove it, as needed.
            //this.stdTableAdapter.Fill(this.myDBDataSet.std);
            // TODO: This line of code loads data into the 'myDBDataSet.std' table. You can move, or remove it, as needed.
            //this.stdTableAdapter.Fill(this.myDBDataSet.std);
            button2.Image = Image.FromFile("../../images/images01.png");
            button2.ImageAlign = ContentAlignment.MiddleRight;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Text = "ID";
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button2.Text = "Name";
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button2.Text = "Phone";
            hideSubMenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showSubMenu(panel1);
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
