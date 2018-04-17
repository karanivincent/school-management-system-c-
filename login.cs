using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MetroFramework;
using MetroFramework.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Final_smis
{
    public partial class login : MaterialForm
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" || textBox2.Text=="")
            {
                MessageBox.Show("Please enter your Username and Password first");
            }
            else
            {
                MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=smsdb"); // making connection   
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT COUNT(*) FROM users WHERE username='" + textBox1.Text + "' AND password='" + textBox2.Text + "'", con);
                /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
                DataTable dt = new DataTable(); //this is creating a virtual table  
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */
                    this.Hide();
                    form2 maininterface = new main(textBox1.Text);
                    maininterface.Show();
                }
                else
                    MessageBox.Show("Invalid username or password");
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void login_Load(object sender, EventArgs e)
        {
           
        }
    }
}
