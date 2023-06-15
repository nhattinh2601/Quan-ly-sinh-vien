namespace login
{
    partial class NewUserForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ButtonRegister = new System.Windows.Forms.Button();
            this.ButtonUploadPicture = new System.Windows.Forms.Button();
            this.PictureBoxUser = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TextBoxID = new System.Windows.Forms.TextBox();
            this.TextBoxLName = new System.Windows.Forms.TextBox();
            this.TextBoxFName = new System.Windows.Forms.TextBox();
            this.TextBoxUsername = new System.Windows.Forms.TextBox();
            this.TextBoxPass = new System.Windows.Forms.TextBox();
            this.TextBoxEnterNewPass = new System.Windows.Forms.TextBox();
            this.ButtonLogin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxUser)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "First Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(80, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Last Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(80, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(80, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(80, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(193, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Enter New Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(80, 319);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Picture";
            // 
            // ButtonRegister
            // 
            this.ButtonRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonRegister.Location = new System.Drawing.Point(85, 528);
            this.ButtonRegister.Name = "ButtonRegister";
            this.ButtonRegister.Size = new System.Drawing.Size(479, 50);
            this.ButtonRegister.TabIndex = 7;
            this.ButtonRegister.Text = "Register";
            this.ButtonRegister.UseVisualStyleBackColor = true;
            this.ButtonRegister.Click += new System.EventHandler(this.ButtonRegister_Click);
            // 
            // ButtonUploadPicture
            // 
            this.ButtonUploadPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonUploadPicture.Location = new System.Drawing.Point(292, 457);
            this.ButtonUploadPicture.Name = "ButtonUploadPicture";
            this.ButtonUploadPicture.Size = new System.Drawing.Size(305, 40);
            this.ButtonUploadPicture.TabIndex = 8;
            this.ButtonUploadPicture.Text = "Upload Picture";
            this.ButtonUploadPicture.UseVisualStyleBackColor = true;
            this.ButtonUploadPicture.Click += new System.EventHandler(this.ButtonUploadPicture_Click);
            // 
            // PictureBoxUser
            // 
            this.PictureBoxUser.Location = new System.Drawing.Point(292, 319);
            this.PictureBoxUser.Name = "PictureBoxUser";
            this.PictureBoxUser.Size = new System.Drawing.Size(305, 132);
            this.PictureBoxUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxUser.TabIndex = 9;
            this.PictureBoxUser.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(182, 614);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(167, 25);
            this.label8.TabIndex = 10;
            this.label8.Text = "Have a Account ?";
            // 
            // TextBoxID
            // 
            this.TextBoxID.Location = new System.Drawing.Point(292, 40);
            this.TextBoxID.Name = "TextBoxID";
            this.TextBoxID.Size = new System.Drawing.Size(305, 26);
            this.TextBoxID.TabIndex = 11;
            // 
            // TextBoxLName
            // 
            this.TextBoxLName.Location = new System.Drawing.Point(292, 125);
            this.TextBoxLName.Name = "TextBoxLName";
            this.TextBoxLName.Size = new System.Drawing.Size(305, 26);
            this.TextBoxLName.TabIndex = 12;
            // 
            // TextBoxFName
            // 
            this.TextBoxFName.Location = new System.Drawing.Point(292, 84);
            this.TextBoxFName.Name = "TextBoxFName";
            this.TextBoxFName.Size = new System.Drawing.Size(305, 26);
            this.TextBoxFName.TabIndex = 13;
            // 
            // TextBoxUsername
            // 
            this.TextBoxUsername.Location = new System.Drawing.Point(292, 175);
            this.TextBoxUsername.Name = "TextBoxUsername";
            this.TextBoxUsername.Size = new System.Drawing.Size(305, 26);
            this.TextBoxUsername.TabIndex = 14;
            // 
            // TextBoxPass
            // 
            this.TextBoxPass.Location = new System.Drawing.Point(292, 218);
            this.TextBoxPass.Name = "TextBoxPass";
            this.TextBoxPass.Size = new System.Drawing.Size(305, 26);
            this.TextBoxPass.TabIndex = 15;
            // 
            // TextBoxEnterNewPass
            // 
            this.TextBoxEnterNewPass.Location = new System.Drawing.Point(292, 266);
            this.TextBoxEnterNewPass.Name = "TextBoxEnterNewPass";
            this.TextBoxEnterNewPass.Size = new System.Drawing.Size(305, 26);
            this.TextBoxEnterNewPass.TabIndex = 16;
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.AutoSize = true;
            this.ButtonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLogin.Location = new System.Drawing.Point(355, 614);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(75, 25);
            this.ButtonLogin.TabIndex = 17;
            this.ButtonLogin.Text = "Log in .";
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // NewUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 669);
            this.Controls.Add(this.ButtonLogin);
            this.Controls.Add(this.TextBoxEnterNewPass);
            this.Controls.Add(this.TextBoxPass);
            this.Controls.Add(this.TextBoxUsername);
            this.Controls.Add(this.TextBoxFName);
            this.Controls.Add(this.TextBoxLName);
            this.Controls.Add(this.TextBoxID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.PictureBoxUser);
            this.Controls.Add(this.ButtonUploadPicture);
            this.Controls.Add(this.ButtonRegister);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NewUserForm";
            this.Text = "NewUserForm";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ButtonRegister;
        private System.Windows.Forms.Button ButtonUploadPicture;
        private System.Windows.Forms.PictureBox PictureBoxUser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TextBoxID;
        private System.Windows.Forms.TextBox TextBoxLName;
        private System.Windows.Forms.TextBox TextBoxFName;
        private System.Windows.Forms.TextBox TextBoxUsername;
        private System.Windows.Forms.TextBox TextBoxPass;
        private System.Windows.Forms.TextBox TextBoxEnterNewPass;
        private System.Windows.Forms.Label ButtonLogin;
    }
}