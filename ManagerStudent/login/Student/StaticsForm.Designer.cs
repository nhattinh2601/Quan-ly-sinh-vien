namespace login
{
    partial class StaticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelTotal = new System.Windows.Forms.Panel();
            this.LabelTotal = new System.Windows.Forms.Label();
            this.PanelMale = new System.Windows.Forms.Panel();
            this.LabelMale = new System.Windows.Forms.Label();
            this.PanelFemale = new System.Windows.Forms.Panel();
            this.LabelFemale = new System.Windows.Forms.Label();
            this.ButtonChart = new System.Windows.Forms.Button();
            this.PanelTotal.SuspendLayout();
            this.PanelMale.SuspendLayout();
            this.PanelFemale.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTotal
            // 
            this.PanelTotal.BackColor = System.Drawing.Color.Teal;
            this.PanelTotal.Controls.Add(this.LabelTotal);
            this.PanelTotal.Location = new System.Drawing.Point(12, 12);
            this.PanelTotal.Name = "PanelTotal";
            this.PanelTotal.Size = new System.Drawing.Size(666, 142);
            this.PanelTotal.TabIndex = 0;
            this.PanelTotal.MouseEnter += new System.EventHandler(this.PanelTotal_MouseEnter);
            // 
            // LabelTotal
            // 
            this.LabelTotal.BackColor = System.Drawing.Color.Blue;
            this.LabelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotal.Location = new System.Drawing.Point(0, 0);
            this.LabelTotal.Name = "LabelTotal";
            this.LabelTotal.Size = new System.Drawing.Size(668, 142);
            this.LabelTotal.TabIndex = 0;
            this.LabelTotal.Text = "Total Student : 100%";
            this.LabelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelTotal.MouseEnter += new System.EventHandler(this.LabelTotal_MouseEnter_1);
            this.LabelTotal.MouseLeave += new System.EventHandler(this.LabelTotal_MouseLeave_1);
            // 
            // PanelMale
            // 
            this.PanelMale.Controls.Add(this.LabelMale);
            this.PanelMale.Location = new System.Drawing.Point(12, 158);
            this.PanelMale.Name = "PanelMale";
            this.PanelMale.Size = new System.Drawing.Size(333, 182);
            this.PanelMale.TabIndex = 1;
            // 
            // LabelMale
            // 
            this.LabelMale.BackColor = System.Drawing.Color.Silver;
            this.LabelMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMale.Location = new System.Drawing.Point(0, 3);
            this.LabelMale.Name = "LabelMale";
            this.LabelMale.Size = new System.Drawing.Size(333, 182);
            this.LabelMale.TabIndex = 0;
            this.LabelMale.Text = "Male : 50%";
            this.LabelMale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelMale.MouseEnter += new System.EventHandler(this.LabelMale_MouseEnter);
            this.LabelMale.MouseLeave += new System.EventHandler(this.LabelMale_MouseLeave);
            // 
            // PanelFemale
            // 
            this.PanelFemale.Controls.Add(this.LabelFemale);
            this.PanelFemale.Location = new System.Drawing.Point(351, 158);
            this.PanelFemale.Name = "PanelFemale";
            this.PanelFemale.Size = new System.Drawing.Size(328, 182);
            this.PanelFemale.TabIndex = 2;
            // 
            // LabelFemale
            // 
            this.LabelFemale.BackColor = System.Drawing.Color.Yellow;
            this.LabelFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFemale.Location = new System.Drawing.Point(-2, 0);
            this.LabelFemale.Name = "LabelFemale";
            this.LabelFemale.Size = new System.Drawing.Size(327, 182);
            this.LabelFemale.TabIndex = 1;
            this.LabelFemale.Text = "Female : 50%";
            this.LabelFemale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelFemale.MouseEnter += new System.EventHandler(this.LabelFemale_MouseEnter);
            this.LabelFemale.MouseLeave += new System.EventHandler(this.LabelFemale_MouseLeave);
            // 
            // ButtonChart
            // 
            this.ButtonChart.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ButtonChart.FlatAppearance.BorderSize = 0;
            this.ButtonChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonChart.Location = new System.Drawing.Point(243, 369);
            this.ButtonChart.Name = "ButtonChart";
            this.ButtonChart.Size = new System.Drawing.Size(200, 40);
            this.ButtonChart.TabIndex = 3;
            this.ButtonChart.Text = "Chart";
            this.ButtonChart.UseVisualStyleBackColor = false;
            this.ButtonChart.Click += new System.EventHandler(this.ButtonChart_Click);
            // 
            // StaticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(692, 430);
            this.Controls.Add(this.ButtonChart);
            this.Controls.Add(this.PanelFemale);
            this.Controls.Add(this.PanelMale);
            this.Controls.Add(this.PanelTotal);
            this.Name = "StaticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StaticsForm";
            this.Load += new System.EventHandler(this.StaticsForm_Load);
            this.PanelTotal.ResumeLayout(false);
            this.PanelMale.ResumeLayout(false);
            this.PanelFemale.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelTotal;
        private System.Windows.Forms.Label LabelTotal;
        private System.Windows.Forms.Panel PanelMale;
        private System.Windows.Forms.Panel PanelFemale;
        private System.Windows.Forms.Label LabelMale;
        private System.Windows.Forms.Label LabelFemale;
        private System.Windows.Forms.Button ButtonChart;
    }
}