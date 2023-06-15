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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            customizeDesing();
        }
        private void customizeDesing()
        {
            PanelSubStudent.Visible = false;
            PanelSubCourse.Visible = false;
            PanelSubScore.Visible = false;
            PanelSubResult.Visible = false;
        }

        private void hideSubMenu()
        {
            if (PanelSubStudent.Visible == true)
                PanelSubStudent.Visible = false;
            if (PanelSubCourse.Visible == true)
                PanelSubCourse.Visible=false;
            if (PanelSubScore.Visible == true)
                PanelSubScore.Visible=false;
            if (PanelSubResult.Visible == true)
                PanelSubResult.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("../../images/Picture1.png");
            pictureBox2.Image = Image.FromFile("../../images/student-management-system-2.jpg");
        }

        private void ButtonAddStd_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudentForm = new AddStudentForm();
            addStudentForm.Show(this);
        }

        private void ButtonStdList_Click(object sender, EventArgs e)
        {
            studentListForm studentListForm = new studentListForm();
            studentListForm.Show(this);
        }

        private void ButtonStatics_Click(object sender, EventArgs e)
        {
            StaticsForm staticsForm = new StaticsForm();
            staticsForm.Show(this);
        }

        private void ButtonEditRemoveStd_Click(object sender, EventArgs e)
        {
            EditRemoveStudent editRemoveStudent = new EditRemoveStudent();
            editRemoveStudent.Show(this);
        }

        private void ButtonManagerStd_Click(object sender, EventArgs e)
        {
            ManageStudentForm manageStudentForm = new ManageStudentForm();
            manageStudentForm.Show(this);
        }

        private void ButtonPrintStd_Click(object sender, EventArgs e)
        {
            PrintStudentForm printStudentForm = new PrintStudentForm();
            printStudentForm.Show(this);
        }

        private void ButtonAddCourse_Click(object sender, EventArgs e)
        {
            AddCourse addCourse = new AddCourse();
            addCourse.Show(this);
        }

        private void ButtonRemoveCourse_Click(object sender, EventArgs e)
        {
            RemoveCourseForm removeCourseForm = new RemoveCourseForm();
            removeCourseForm.Show(this);
        }

        private void ButtonEditCourse_Click(object sender, EventArgs e)
        {
            editCourse edit = new editCourse();
            edit.Show(this);
        }

        private void ButtonManagerCourse_Click(object sender, EventArgs e)
        {
            ManagerCourseForm managerCourseForm = new ManagerCourseForm();
            managerCourseForm.Show(this);
        }

        private void ButtonStudent_Click(object sender, EventArgs e)
        {
            showSubMenu(PanelSubStudent);
        }

        private void ButtonCourse_Click(object sender, EventArgs e)
        {
            showSubMenu(PanelSubCourse);
        }

        private void ButtonScore_Click(object sender, EventArgs e)
        {
            showSubMenu(PanelSubScore);
        }

        private void ButtonPrintfCourse_Click(object sender, EventArgs e)
        {
            PrintCourse printCourse = new PrintCourse();
            printCourse.Show(this);
        }

        private void ButtonAddScore_Click(object sender, EventArgs e)
        {
            AddScore addScore = new AddScore();
            addScore.Show(this);
        }

        private void ButtonRemoveScore_Click(object sender, EventArgs e)
        {
            RemoveScore deleteScore = new RemoveScore();            
            deleteScore.Show(this);
            
        }
        

        private void ButtonResultSub_Click(object sender, EventArgs e)
        {
            showSubMenu(PanelSubResult);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StaticsResultForm staticsResultForm = new StaticsResultForm();
            staticsResultForm.Show(this);
        }

        private void ButtonManagerScore_Click(object sender, EventArgs e)
        {
            ManagerScore managerScore = new ManagerScore();
            managerScore.Show(this);
        }

        private void ResultByScore_Click(object sender, EventArgs e)
        {
            ResultForm resultForm = new ResultForm();
            resultForm.Show(this);
        }

        private void ButttonAvg_Click(object sender, EventArgs e)
        {
            AvarageScoreByCourse avarageScoreByCourse = new AvarageScoreByCourse();
            avarageScoreByCourse.Show(this);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            RegisterCourseForm registerCourseForm = new RegisterCourseForm();
            registerCourseForm.Show(this);
        }
    }
}
