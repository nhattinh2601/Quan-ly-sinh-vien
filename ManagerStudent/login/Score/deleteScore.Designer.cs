﻿namespace login
{
    partial class deleteScore
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
            this.ButtonRemove = new System.Windows.Forms.Button();
            this.TextBoxID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxCourseID = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonRemove
            // 
            this.ButtonRemove.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ButtonRemove.FlatAppearance.BorderSize = 0;
            this.ButtonRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonRemove.ForeColor = System.Drawing.Color.White;
            this.ButtonRemove.Location = new System.Drawing.Point(242, 112);
            this.ButtonRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonRemove.Name = "ButtonRemove";
            this.ButtonRemove.Size = new System.Drawing.Size(143, 33);
            this.ButtonRemove.TabIndex = 6;
            this.ButtonRemove.Text = "Remove";
            this.ButtonRemove.UseVisualStyleBackColor = false;
            this.ButtonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
            // 
            // TextBoxID
            // 
            this.TextBoxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxID.Location = new System.Drawing.Point(242, 17);
            this.TextBoxID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBoxID.Multiline = true;
            this.TextBoxID.Name = "TextBoxID";
            this.TextBoxID.Size = new System.Drawing.Size(337, 25);
            this.TextBoxID.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Enter The Student ID :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Enter The Course ID :";
            // 
            // TextBoxCourseID
            // 
            this.TextBoxCourseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxCourseID.Location = new System.Drawing.Point(242, 70);
            this.TextBoxCourseID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBoxCourseID.Multiline = true;
            this.TextBoxCourseID.Name = "TextBoxCourseID";
            this.TextBoxCourseID.Size = new System.Drawing.Size(337, 25);
            this.TextBoxCourseID.TabIndex = 8;
            this.TextBoxCourseID.TextChanged += new System.EventHandler(this.TextBoxCourseID_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(436, 112);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 33);
            this.button1.TabIndex = 9;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // deleteScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(610, 168);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TextBoxCourseID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonRemove);
            this.Controls.Add(this.TextBoxID);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "deleteScore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "deleteScore";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonRemove;
        private System.Windows.Forms.TextBox TextBoxID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxCourseID;
        private System.Windows.Forms.Button button1;
    }
}