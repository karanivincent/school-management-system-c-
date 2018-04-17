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
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Final_smis
{
    public partial class AddTeacher : MaterialForm
    {
        public AddTeacher()
        {
            InitializeComponent();
        }
        class teachers
        {
            int teacherID;
            string FullName = "";
            string gender = "";
            int age = 0;
            long ID = 0;
            long PhoneNo = 0;
            string email = "";
            string Location = "";
            string imagePath = "";
            string designation = "";
            public void getData(string tchID, string fn, string Age, string id, string sex, string phone, string mail, string location, string imgpath, string dsgnation)
            {
                teacherID = Int32.Parse(tchID);
                FullName = fn;
                gender = sex;
                age = Int32.Parse(Age);
                ID = Int64.Parse(id);
                PhoneNo = Int64.Parse(phone);
                email = mail;
                Location = location;
                imagePath = imgpath;
                designation = dsgnation;

            }
            public void insert()
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=smsdb");
                MySqlCommand cmd = new MySqlCommand("INSERT INTO teachers (teacherID, fullName, gender, age, ID, phone, email, Location, imagePath, designation) VALUES ('" + teacherID + "', '" + FullName + "','" + gender + "', '" + age + "', '" + ID + "', '" + PhoneNo + "', '" + email + "', '" + Location + "', '" + imagePath + "', '" + designation + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }

        }
        teachers teacher = new teachers();
        public class RegexUtilities
        {
            bool invalid = false;

            public bool IsValidEmail(string strIn)
            {
                invalid = false;
                if (String.IsNullOrEmpty(strIn))
                    return false;

                // Use IdnMapping class to convert Unicode domain names.
                try
                {
                    strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                          RegexOptions.None, TimeSpan.FromMilliseconds(200));
                }
                catch (RegexMatchTimeoutException)
                {
                    return false;
                }

                if (invalid)
                    return false;

                // Return true if strIn is in valid e-mail format.
                try
                {
                    return Regex.IsMatch(strIn,
                          @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                          @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                          RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                }
                catch (RegexMatchTimeoutException)
                {
                    return false;
                }
            }

            private string DomainMapper(Match match)
            {
                // IdnMapping class with default property values.
                IdnMapping idn = new IdnMapping();

                string domainName = match.Groups[2].Value;
                try
                {
                    domainName = idn.GetAscii(domainName);
                }
                catch (ArgumentException)
                {
                    invalid = true;
                }
                return match.Groups[1].Value + domainName;
            }
        }
        string imgpath = "";
        string filepath = "";
        string iName = "";
        string appPath = "";
        public void reset()
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Clear();
                }
            }

            foreach (Control y in this.Controls)

            {

                if (y is RadioButton)

                {
                    ((RadioButton)y).Checked = false;

                }

            }
            foreach (Control z in this.Controls)

            {

                if (z is ComboBox)

                {
                    ((ComboBox)z).Text = "";

                }

            }
            foreach (Control w in this.Controls)

            {

                if (w is NumericUpDown)

                {
                    ((NumericUpDown)w).Value = 0;

                }

            }
        }
        public void teacherID_Increment()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=smsdb");
            MySqlCommand get_adm = new MySqlCommand("SELECT MAX(teacherID) AS teacherID FROM teachers", con);
            con.Open();

            MySqlDataReader readata = get_adm.ExecuteReader();
            if (readata.Read())
            {
                try
                {
                    int x = Convert.ToInt32(readata["teacherID"]);
                    x = x + 1;
                    textBox5.Text = x.ToString();
                }
                catch (InvalidCastException)
                {
                    textBox5.Text = "1";
                }

            }
            con.Close();

        }
        private void digitonly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void clear_Click(object sender, EventArgs e)
        {
            reset();
            teacherID_Increment();
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

        private void save_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Enter Teachers Full Name");
            }
            else
            {
                if (radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    MessageBox.Show("Choose Gender");
                }
                else
                {
                    if (numericUpDown1.Value == 0)
                    {
                        MessageBox.Show("Choose Age");
                    }
                    else
                    {
                        if (textBox4.Text == "")
                        {
                            MessageBox.Show("Enter ID");
                        }
                        else
                        {
                            if (textBox7.Text == "")
                            {
                                MessageBox.Show("Enter Phone Number");
                            }
                            else
                            {
                                if (textBox8.Text == "")
                                {
                                    MessageBox.Show("Enter Email");
                                }
                                else
                                {
                                    if (textBox3.Text == "")
                                    {
                                        MessageBox.Show("Enter Location");
                                    }
                                    else
                                    {
                                        string sex = "";
                                        if (radioButton1.Checked == true)
                                        {
                                            sex = "male";
                                        }
                                        else if (radioButton2.Checked == true)
                                        {
                                            sex = "female";
                                        }


                                        RegexUtilities util = new RegexUtilities();
                                        if (util.IsValidEmail(textBox8.Text))
                                        {
                                            appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Images\Teachers\"; // <---
                                            if (Directory.Exists(appPath) == false)                                              // <---
                                            {                                                                                    // <---
                                                Directory.CreateDirectory(appPath);                                              // <---
                                            }                                                                                    // <---
                                            try
                                            {
                                                File.Copy(filepath, appPath + iName); // <---
                                                imgpath = appPath + iName;
                                        //       public void getData(string adm, string fn, string Age, string id, string sex, string phone, string mail, string location, string imgpath, string dsgnation)
                                                teacher.getData(textBox5.Text, textBox2.Text, numericUpDown1.Text, textBox4.Text, sex, textBox7.Text, textBox8.Text,  textBox3.Text, imgpath, textBox1.Text);
                                                teacher.insert();
                                                MessageBox.Show("Saved successfully");
                                                reset();
                                                teacherID_Increment();
                                            }
                                            catch (IOException)
                                            {
                                                MessageBox.Show("Picture already exists");
                                            }


                                        }
                                        else
                                        {
                                            MessageBox.Show("Invalid EmailAddress");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void AddTeacher_Load(object sender, EventArgs e)
        {
            teacherID_Increment();
        }
    }
}
