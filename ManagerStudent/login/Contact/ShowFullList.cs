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
    public partial class ShowFullList : Form
    {
        Contact contact = new Contact();
        MY_DB mydb = new MY_DB();  
        Group group = new Group();
        public ShowFullList()
        {
            InitializeComponent();
        }
        public static int ContactID { get; private set; }
        public static void SetContactID(int userID)
        { ContactID = userID; }
        private void ShowFullList_Load(object sender, EventArgs e)
        {
            
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();

            
            string query = " select * from mycontact where userid=" + fLogin_02.GlobalUserID+" order by id ASC";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.Add("@userid", SqlDbType.Int).Value = fLogin_02.GlobalUserID;

            dataGridView1.DataSource = contact.SelectContactList(command);

            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (IsOdd(i))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }
            listBox1.DataSource = group.getGroups(fLogin_02.GlobalUserID);
            listBox1.DisplayMember = "name";
            listBox1.ValueMember = "id";

            listBox1.SelectedItem = null;
            dataGridView1.ClearSelection();
        }

        private void Contacts_List_Form_Load(object sender,EventArgs e)
        {
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();

            SqlCommand command = new SqlCommand("");

            command.Parameters.Add("@userid", SqlDbType.Int).Value = fLogin_02.GlobalUserID;

            dataGridView1.DataSource = contact.SelectContactList(command);

            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            for(int i =0; i < dataGridView1.Rows.Count; i++)
            {
                if(IsOdd(i))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }
            listBox1.DataSource = group.getGroups(fLogin_02.GlobalUserID);
            listBox1.DisplayMember = "name";
            listBox1.ValueMember = "id";

            listBox1.SelectedItem = null;
            dataGridView1.ClearSelection();
        }

        public  bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            try 
            {
                int groupid = (Int32)listBox1.SelectedValue;
                
                string query = " select * from mycontact where userid=" + fLogin_02.GlobalUserID +"and group_id="+groupid ;
                SqlCommand command = new SqlCommand(query);
                dataGridView1.DataSource = contact.SelectContactList(command);
                for (int i = 0; i< dataGridView1.Rows.Count; i++)
                {
                    if(IsOdd(i))
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }    
                }
            }
            catch(Exception )
            {

            }
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int id =Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            SetContactID(id);
            ShowProfileContact showProfileContact = new ShowProfileContact();
            showProfileContact.Show(this);
        }
    }
}
