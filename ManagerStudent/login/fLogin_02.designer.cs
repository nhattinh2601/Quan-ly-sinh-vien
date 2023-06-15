namespace login
{
    partial class fLogin_02
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxUsername = new System.Windows.Forms.TextBox();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_cancel = new System.Windows.Forms.Label();
            this.bt_login = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.rdbStudent = new System.Windows.Forms.RadioButton();
            this.rdbHumanResource = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "User name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password : ";
            // 
            // TextBoxUsername
            // 
            this.TextBoxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxUsername.Location = new System.Drawing.Point(174, 139);
            this.TextBoxUsername.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.TextBoxUsername.Multiline = true;
            this.TextBoxUsername.Name = "TextBoxUsername";
            this.TextBoxUsername.Size = new System.Drawing.Size(473, 35);
            this.TextBoxUsername.TabIndex = 1;
            this.toolTip1.SetToolTip(this.TextBoxUsername, "Input your username");
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxPassword.Location = new System.Drawing.Point(174, 209);
            this.TextBoxPassword.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.TextBoxPassword.Multiline = true;
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.PasswordChar = '*';
            this.TextBoxPassword.Size = new System.Drawing.Size(473, 35);
            this.TextBoxPassword.TabIndex = 2;
            this.toolTip2.SetToolTip(this.TextBoxPassword, "Input your Password");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(127, 425);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Don\'t have an account?";
            // 
            // bt_cancel
            // 
            this.bt_cancel.AutoSize = true;
            this.bt_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_cancel.Location = new System.Drawing.Point(390, 425);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(101, 29);
            this.bt_cancel.TabIndex = 5;
            this.bt_cancel.Text = "Sign up ";
            this.toolTip4.SetToolTip(this.bt_cancel, "Click to Sign in a new account");
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // bt_login
            // 
            this.bt_login.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_login.FlatAppearance.BorderSize = 0;
            this.bt_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_login.ForeColor = System.Drawing.Color.White;
            this.bt_login.Location = new System.Drawing.Point(526, 298);
            this.bt_login.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.bt_login.Name = "bt_login";
            this.bt_login.Size = new System.Drawing.Size(111, 52);
            this.bt_login.TabIndex = 3;
            this.bt_login.Text = "Login";
            this.toolTip3.SetToolTip(this.bt_login, "Click to login to main program");
            this.bt_login.UseVisualStyleBackColor = false;
            this.bt_login.Click += new System.EventHandler(this.bt_login_Click);
            this.bt_login.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bt_login_KeyPress);
            // 
            // rdbStudent
            // 
            this.rdbStudent.AutoSize = true;
            this.rdbStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbStudent.Location = new System.Drawing.Point(174, 252);
            this.rdbStudent.Name = "rdbStudent";
            this.rdbStudent.Size = new System.Drawing.Size(105, 29);
            this.rdbStudent.TabIndex = 8;
            this.rdbStudent.TabStop = true;
            this.rdbStudent.Text = "Student";
            this.rdbStudent.UseVisualStyleBackColor = true;
            // 
            // rdbHumanResource
            // 
            this.rdbHumanResource.AutoSize = true;
            this.rdbHumanResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbHumanResource.Location = new System.Drawing.Point(333, 252);
            this.rdbHumanResource.Name = "rdbHumanResource";
            this.rdbHumanResource.Size = new System.Drawing.Size(188, 29);
            this.rdbHumanResource.TabIndex = 9;
            this.rdbHumanResource.TabStop = true;
            this.rdbHumanResource.Text = "Human Resource";
            this.rdbHumanResource.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(667, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(702, 649);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(340, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Forget PassWord";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // fLogin_02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1378, 511);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rdbHumanResource);
            this.Controls.Add(this.rdbStudent);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bt_login);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.TextBoxUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "fLogin_02";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.fLogin_02_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxUsername;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label bt_cancel;
        private System.Windows.Forms.Button bt_login;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip4;
        private System.Windows.Forms.RadioButton rdbStudent;
        private System.Windows.Forms.RadioButton rdbHumanResource;
        private System.Windows.Forms.Label label4;
    }
}