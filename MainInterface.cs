using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using MaterialSkin.Animations;

namespace Final_smis
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddStudent().Show();
        }

        private void manageStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ManageStudents().Show();
        }

        private void addTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddTeacher().Show();
        }

        private void manageTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ManageTeachers().Show();
        }

        private void enterExamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EnterExam().Show();
        }


        private void viewTeachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ViewTeacher().Show();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddUser().Show();
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ManageUsers().Show();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aDMNOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FindStudentAdm().Show();
        }

        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FindStudentName().Show();
        }

        private void westToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
            new login().Show();
        }

        private void manageExamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ViewExams().Show();
        }
    }
}
