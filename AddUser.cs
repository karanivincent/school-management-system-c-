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
using System.Globalization;
using System.IO;
using MetroFramework.Forms;
using MaterialSkin;
using MaterialSkin.Controls;


namespace Final_smis
{
    public partial class AddUser : MaterialForm
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=smsdb");
        MySqlCommand cmd;
        string imgpath = "";
        string filepath = "";
        string iName = "";
        string appPath = "";
        string userName = "";
        int id = 0;
        public AddUser()
        {
            InitializeComponent();
            UserIdIncrement();
        }
        public void UserIdIncrement()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=smsdb");
            MySqlCommand get_Id = new MySqlCommand("SELECT MAX(ID) AS ID FROM users", con);
            con.Open();

            MySqlDataReader readata = get_Id.ExecuteReader();
            if (readata.Read())
            {
                try
                {
                    id = Convert.ToInt32(readata["ID"]);
                    id = id + 1;
                }
                catch (InvalidCastException)
                {
                    id = 1;
                }

            }
            con.Close();

        }
        private void upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opFile = new OpenFileDialog();
            opFile.Title = "Select a Image";
            opFile.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (opFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    iName = opFile.SafeFileName;
                    filepath = opFile.FileName;
                    pictureBox1.Image = new Bitmap(opFile.FileName);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Unable to open file " + exp.Message);
                }
            }
            else
            {
                opFile.Dispose();
            }
        }

        public void insert()
        {
            string password = "";
            if (textBox2.Text == textBox3.Text)
            {
                password = textBox1.Text;
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=smsdb");
                MySqlCommand cmd = new MySqlCommand("INSERT INTO users (ID, username, password, fullname, picture) VALUES ('" + id + "', '" + textBox1.Text + "','" + password + "', '" + textBox4.Text + "', '" + imgpath + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                MessageBox.Show("Passwords are not similar");
            }

        }
        public void reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        private void clear_click(object sender, EventArgs e)
        {
            reset();
        }

        private void save_click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter UserName");
            }
            else
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Enter Password");
                }
                else
                {
                    if (textBox2.Text == "")
                    {
                        MessageBox.Show("Please Retype Password");
                    }
                    else
                    {
                        if (textBox2.Text == "")
                        {
                            MessageBox.Show("Enter Users Fullname");
                        }
                        else
                        {

                            string password = "";
                            if (textBox2.Text == textBox3.Text)
                            {
                                appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Images\Users\"; // <---
                                if (Directory.Exists(appPath) == false)                                              // <---
                                {                                                                                    // <---
                                    Directory.CreateDirectory(appPath);                                              // <---
                                }                                                                                    // <---
                                try
                                {
                                    File.Copy(filepath, appPath + iName); // <---
                                    imgpath = appPath + iName;
                                    password = textBox1.Text;
                                    MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=smsdb");
                                    MySqlCommand cmd = new MySqlCommand("INSERT INTO users (ID, username, password, fullname, picture) VALUES ('" + id + "', '" + textBox1.Text + "','" + password + "', '" + textBox4.Text + "', '" + imgpath + "')", con);
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    MessageBox.Show("Saved successfully");
                                    reset();
                                }
                                catch (IOException)
                                {
                                    MessageBox.Show("Picture already exists");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Passwords are not similar");
                            }
                        }
                    }
                }
            }
        }



    }
}
