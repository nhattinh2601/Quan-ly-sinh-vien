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
    public partial class ListGroup : Form
    {
        public ListGroup()
        {
            InitializeComponent();
        }
        Group group = new Group();
        public static int IDGroup = 10;
        private void ListGroup_Load(object sender, EventArgs e)
        {
            string query = " select * from mygroups where userid=" + fLogin_02.GlobalUserID;
            SqlCommand command = new SqlCommand(query);
            dataGridView1.DataSource = group.SelectGroupList(command);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                IDGroup = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid ID !");
            }
        }
    }
}
