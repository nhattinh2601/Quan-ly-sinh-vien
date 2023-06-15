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
    public partial class ShowProfileContact : Form
    {
        public ShowProfileContact()
        {
            InitializeComponent();
        }
        Contact contact = new Contact();
        private void ShowProfileContact_Load(object sender, EventArgs e)
        {
            string query = " select Course.label as 'Tên môn học',Course.description as 'Mô tả',Course.period as 'Số tiết' from Course,mycontact where mycontact.id=" + ShowFullList.ContactID + " and Course.idcontact=" + ShowFullList.ContactID;
            SqlCommand command = new SqlCommand(query);
            dataGridView1.DataSource = contact.SelectContactList(command);

            query = " select std.fname,std.lname,Score.student_score,Score.description from Course,mycontact,Score,std where mycontact.id=" + ShowFullList.ContactID + " and Course.idcontact=" + ShowFullList.ContactID +" and Course.Id=Score.course_id and std.Id = Score.student_id";
            command = new SqlCommand(query);
            dataGridView2.DataSource = contact.SelectContactList(command);
        }
    }
}
