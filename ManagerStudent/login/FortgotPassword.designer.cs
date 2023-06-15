namespace login
{
    partial class FortgotPassword
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
            this.button1 = new System.Windows.Forms.Button();
            this.labelTestMai = new System.Windows.Forms.Label();
            this.textBoxEmai = new System.Windows.Forms.TextBox();
            this.buttonResetpassword = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxConfirmpassword = new System.Windows.Forms.TextBox();
            this.textBoxCodeFG = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTestpasword = new System.Windows.Forms.Label();
            this.labelUserNameEmail = new System.Windows.Forms.Label();
            this.labelTestcode = new System.Windows.Forms.Label();
            this.labelTestForgotPassword = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TextBoxUserName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(575, 26);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 41);
            this.button1.TabIndex = 4;
            this.button1.Text = "Send Email";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelTestMai
            // 
            this.labelTestMai.AutoSize = true;
            this.labelTestMai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelTestMai.ForeColor = System.Drawing.Color.White;
            this.labelTestMai.Location = new System.Drawing.Point(633, 506);
            this.labelTestMai.Name = "labelTestMai";
            this.labelTestMai.Size = new System.Drawing.Size(83, 22);
            this.labelTestMai.TabIndex = 5;
            this.labelTestMai.Text = "Kết Quả";
            this.labelTestMai.Visible = false;
            // 
            // textBoxEmai
            // 
            this.textBoxEmai.Location = new System.Drawing.Point(266, 32);
            this.textBoxEmai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxEmai.Name = "textBoxEmai";
            this.textBoxEmai.Size = new System.Drawing.Size(296, 26);
            this.textBoxEmai.TabIndex = 6;
            this.textBoxEmai.Leave += new System.EventHandler(this.textBoxEmai_Leave);
            // 
            // buttonResetpassword
            // 
            this.buttonResetpassword.ForeColor = System.Drawing.Color.Black;
            this.buttonResetpassword.Location = new System.Drawing.Point(290, 415);
            this.buttonResetpassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonResetpassword.Name = "buttonResetpassword";
            this.buttonResetpassword.Size = new System.Drawing.Size(170, 52);
            this.buttonResetpassword.TabIndex = 7;
            this.buttonResetpassword.Text = "Reset Password";
            this.buttonResetpassword.UseVisualStyleBackColor = true;
            this.buttonResetpassword.Click += new System.EventHandler(this.buttonResetpassword_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(266, 284);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(296, 26);
            this.textBoxPassword.TabIndex = 10;
            // 
            // textBoxConfirmpassword
            // 
            this.textBoxConfirmpassword.Location = new System.Drawing.Point(266, 344);
            this.textBoxConfirmpassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxConfirmpassword.Name = "textBoxConfirmpassword";
            this.textBoxConfirmpassword.Size = new System.Drawing.Size(296, 26);
            this.textBoxConfirmpassword.TabIndex = 11;
            this.textBoxConfirmpassword.Enter += new System.EventHandler(this.textBoxConfirmpassword_Enter);
            // 
            // textBoxCodeFG
            // 
            this.textBoxCodeFG.Location = new System.Drawing.Point(266, 135);
            this.textBoxCodeFG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxCodeFG.Name = "textBoxCodeFG";
            this.textBoxCodeFG.Size = new System.Drawing.Size(296, 26);
            this.textBoxCodeFG.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 30);
            this.label1.TabIndex = 15;
            this.label1.Text = "Enter your Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(230, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(332, 23);
            this.label4.TabIndex = 16;
            this.label4.Text = "This Email is not exist in data base";
            this.label4.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(29, 135);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 30);
            this.label6.TabIndex = 25;
            this.label6.Text = "Four Digit Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(29, 278);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 30);
            this.label2.TabIndex = 29;
            this.label2.Text = "New Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(13, 344);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 30);
            this.label3.TabIndex = 30;
            this.label3.Text = "Conform Password";
            // 
            // labelTestpasword
            // 
            this.labelTestpasword.AutoSize = true;
            this.labelTestpasword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelTestpasword.ForeColor = System.Drawing.Color.White;
            this.labelTestpasword.Location = new System.Drawing.Point(31, 427);
            this.labelTestpasword.Name = "labelTestpasword";
            this.labelTestpasword.Size = new System.Drawing.Size(106, 25);
            this.labelTestpasword.TabIndex = 8;
            this.labelTestpasword.Text = "Password";
            this.labelTestpasword.Visible = false;
            // 
            // labelUserNameEmail
            // 
            this.labelUserNameEmail.AutoSize = true;
            this.labelUserNameEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelUserNameEmail.ForeColor = System.Drawing.Color.White;
            this.labelUserNameEmail.Location = new System.Drawing.Point(31, 471);
            this.labelUserNameEmail.Name = "labelUserNameEmail";
            this.labelUserNameEmail.Size = new System.Drawing.Size(166, 25);
            this.labelUserNameEmail.TabIndex = 14;
            this.labelUserNameEmail.Text = "UserNameEmail";
            this.labelUserNameEmail.Visible = false;
            // 
            // labelTestcode
            // 
            this.labelTestcode.AutoSize = true;
            this.labelTestcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelTestcode.ForeColor = System.Drawing.Color.White;
            this.labelTestcode.Location = new System.Drawing.Point(123, 427);
            this.labelTestcode.Name = "labelTestcode";
            this.labelTestcode.Size = new System.Drawing.Size(101, 25);
            this.labelTestcode.TabIndex = 12;
            this.labelTestcode.Text = "Testcode";
            this.labelTestcode.Visible = false;
            this.labelTestcode.Click += new System.EventHandler(this.labelTestcode_Click);
            // 
            // labelTestForgotPassword
            // 
            this.labelTestForgotPassword.AutoSize = true;
            this.labelTestForgotPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelTestForgotPassword.ForeColor = System.Drawing.Color.White;
            this.labelTestForgotPassword.Location = new System.Drawing.Point(24, 496);
            this.labelTestForgotPassword.Name = "labelTestForgotPassword";
            this.labelTestForgotPassword.Size = new System.Drawing.Size(227, 25);
            this.labelTestForgotPassword.TabIndex = 9;
            this.labelTestForgotPassword.Text = "re- enter the password";
            this.labelTestForgotPassword.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(31, 228);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 30);
            this.label5.TabIndex = 31;
            this.label5.Text = "User name";
            // 
            // TextBoxUserName
            // 
            this.TextBoxUserName.Location = new System.Drawing.Point(266, 234);
            this.TextBoxUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBoxUserName.Name = "TextBoxUserName";
            this.TextBoxUserName.Size = new System.Drawing.Size(296, 26);
            this.TextBoxUserName.TabIndex = 32;
            // 
            // FortgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(729, 566);
            this.Controls.Add(this.TextBoxUserName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelUserNameEmail);
            this.Controls.Add(this.textBoxCodeFG);
            this.Controls.Add(this.labelTestcode);
            this.Controls.Add(this.textBoxConfirmpassword);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelTestForgotPassword);
            this.Controls.Add(this.labelTestpasword);
            this.Controls.Add(this.buttonResetpassword);
            this.Controls.Add(this.textBoxEmai);
            this.Controls.Add(this.labelTestMai);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FortgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quên_MK";
            this.Load += new System.EventHandler(this.Quên_MK_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelTestMai;
        private System.Windows.Forms.TextBox textBoxEmai;
        private System.Windows.Forms.Button buttonResetpassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxConfirmpassword;
        private System.Windows.Forms.TextBox textBoxCodeFG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTestpasword;
        private System.Windows.Forms.Label labelUserNameEmail;
        private System.Windows.Forms.Label labelTestcode;
        private System.Windows.Forms.Label labelTestForgotPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TextBoxUserName;
    }
}