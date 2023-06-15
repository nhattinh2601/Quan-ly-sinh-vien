namespace login
{
    partial class AddGroupForm
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
            this.TextBoxID = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.Label();
            this.TextBoxFName = new System.Windows.Forms.TextBox();
            this.TextBoxLName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextBoxID
            // 
            this.TextBoxID.Location = new System.Drawing.Point(319, 77);
            this.TextBoxID.Name = "TextBoxID";
            this.TextBoxID.Size = new System.Drawing.Size(305, 26);
            this.TextBoxID.TabIndex = 43;
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID.Location = new System.Drawing.Point(107, 76);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(31, 25);
            this.ID.TabIndex = 42;
            this.ID.Text = "ID";
            // 
            // TextBoxFName
            // 
            this.TextBoxFName.Location = new System.Drawing.Point(319, 122);
            this.TextBoxFName.Name = "TextBoxFName";
            this.TextBoxFName.Size = new System.Drawing.Size(305, 26);
            this.TextBoxFName.TabIndex = 41;
            // 
            // TextBoxLName
            // 
            this.TextBoxLName.Location = new System.Drawing.Point(319, 163);
            this.TextBoxLName.Name = "TextBoxLName";
            this.TextBoxLName.Size = new System.Drawing.Size(305, 26);
            this.TextBoxLName.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(107, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 25);
            this.label3.TabIndex = 39;
            this.label3.Text = "Last Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(107, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 38;
            this.label2.Text = "Name";
            // 
            // AddGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(776, 301);
            this.Controls.Add(this.TextBoxID);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.TextBoxFName);
            this.Controls.Add(this.TextBoxLName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "AddGroupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddGroupForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxID;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.TextBox TextBoxFName;
        private System.Windows.Forms.TextBox TextBoxLName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}