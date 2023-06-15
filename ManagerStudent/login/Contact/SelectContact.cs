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
    public partial class SelectContact : Form
    {
        public static int IDContact=10;
        Contact contact = new Contact();
        public SelectContact()
        {
            InitializeComponent();
        }

        private void SelectContact_Load(object sender, EventArgs e)
        {
            string query = " select * from mycontact where userid="+fLogin_02.GlobalUserID;
            SqlCommand command = new SqlCommand(query);
            dataGridView1.DataSource = contact.SelectContactList(command);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                IDContact = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                this.Close();
            }
            catch (Exception )
            {
                MessageBox.Show("Invalid ID !");
            }
        }
    }
}
