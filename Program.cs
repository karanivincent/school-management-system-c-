using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_smis
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          //  Application.Run(new AddUser());
           // Application.Run(new FindStudentAdm());
            Application.Run(new main());
      // Application.Run(new login());
          // Application.Run(new EnterExam());
         //   Application.Run(new MainInterface());
         //Application.Run(new ManageTeachers());
           // Application.Run(new ManageUsers());
         // Application.Run(new ManageStudents());
         // Application.Run(new Manage_fees());
            
        }
    }
}
