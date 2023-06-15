using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value + 1;
            label2.Text = progressBar1.Value.ToString() + "%";
            if (progressBar1.Value >= 99)
            {
                timer1.Enabled = false;
                FormMain main = new FormMain();
                main.Show();
                this.Hide();
            }
        }
    }
}
