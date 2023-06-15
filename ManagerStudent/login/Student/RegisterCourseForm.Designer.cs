namespace login
{
    partial class RegisterCourseForm
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
            this.DataGridViewStudent = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.myDBDataSet = new login.myDBDataSet();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.courseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.courseTableAdapter = new login.myDBDataSetTableAdapters.CourseTableAdapter();
            this.ComboBoxSelectCourse = new System.Windows.Forms.ComboBox();
            this.stdTableAdapter = new login.myDBDataSetTableAdapters.stdTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewStudent
            // 
            this.DataGridViewStudent.AutoGenerateColumns = false;
            this.DataGridViewStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn});
            this.DataGridViewStudent.DataSource = this.stdBindingSource;
            this.DataGridViewStudent.Location = new System.Drawing.Point(390, 22);
            this.DataGridViewStudent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DataGridViewStudent.Name = "DataGridViewStudent";
            this.DataGridViewStudent.RowHeadersWidth = 51;
            this.DataGridViewStudent.RowTemplate.Height = 24;
            this.DataGridViewStudent.Size = new System.Drawing.Size(147, 247);
            this.DataGridViewStudent.TabIndex = 28;
            this.DataGridViewStudent.Click += new System.EventHandler(this.DataGridViewStudent_Click_1);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // stdBindingSource
            // 
            this.stdBindingSource.DataMember = "std";
            this.stdBindingSource.DataSource = this.myDBDataSet;
            // 
            // myDBDataSet
            // 
            this.myDBDataSet.DataSetName = "myDBDataSet";
            this.myDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ButtonAdd.FlatAppearance.BorderSize = 0;
            this.ButtonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonAdd.ForeColor = System.Drawing.Color.White;
            this.ButtonAdd.Location = new System.Drawing.Point(202, 136);
            this.ButtonAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(139, 35);
            this.ButtonAdd.TabIndex = 25;
            this.ButtonAdd.Text = "Add";
            this.ButtonAdd.UseVisualStyleBackColor = false;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 25);
            this.label3.TabIndex = 22;
            this.label3.Text = "Select Course :";
            // 
            // TextBoxID
            // 
            this.TextBoxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxID.Location = new System.Drawing.Point(180, 22);
            this.TextBoxID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBoxID.Name = "TextBoxID";
            this.TextBoxID.Size = new System.Drawing.Size(161, 31);
            this.TextBoxID.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "Studen ID :";
            // 
            // courseBindingSource
            // 
            this.courseBindingSource.DataMember = "Course";
            this.courseBindingSource.DataSource = this.myDBDataSet;
            // 
            // courseTableAdapter
            // 
            this.courseTableAdapter.ClearBeforeFill = true;
            // 
            // ComboBoxSelectCourse
            // 
            this.ComboBoxSelectCourse.FormattingEnabled = true;
            this.ComboBoxSelectCourse.Location = new System.Drawing.Point(181, 69);
            this.ComboBoxSelectCourse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComboBoxSelectCourse.Name = "ComboBoxSelectCourse";
            this.ComboBoxSelectCourse.Size = new System.Drawing.Size(160, 28);
            this.ComboBoxSelectCourse.TabIndex = 29;
            // 
            // stdTableAdapter
            // 
            this.stdTableAdapter.ClearBeforeFill = true;
            // 
            // RegisterCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.ClientSize = new System.Drawing.Size(621, 339);
            this.Controls.Add(this.DataGridViewStudent);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBoxID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ComboBoxSelectCourse);
            this.Name = "RegisterCourseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterCourseForm";
            this.Load += new System.EventHandler(this.RegisterCourseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource stdBindingSource;
        private myDBDataSet myDBDataSet;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource courseBindingSource;
        private myDBDataSetTableAdapters.CourseTableAdapter courseTableAdapter;
        private System.Windows.Forms.ComboBox ComboBoxSelectCourse;
        private myDBDataSetTableAdapters.stdTableAdapter stdTableAdapter;
    }
}