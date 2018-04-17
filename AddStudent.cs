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
    public partial class AddStudent : MaterialForm
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        class students
        {
            int admNo;
            string sFullName = "";
            string gender = "";
            int age = 0;
            public string Fom = "";
            public string Stream = "";
            public string pFullName = "";
            string PhoneNo = "";
            string email = "";
            string Location = "";
            string imagePath = "";
            public void getData(string adm, string sdfn, string Age, string sex, string frm, string stream,
                string pfn,  string phone, string mail, string location, string imgpath)
            {
                admNo = Int32.Parse(adm);
                sFullName = sdfn;
                gender = sex;
                age = Int32.Parse(Age);
                Fom = frm;
                Stream = stream;
                pFullName = pfn;
                PhoneNo = phone;
                email = mail;
                Location = location ;
                imagePath = imgpath;


            }
            public void insert()
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=smsdb");
                MySqlCommand cmd = new MySqlCommand("INSERT INTO students (admNo, FullName, gender, age, form, stream, imagePath, parentName, phone, email, Location) VALUES ('" + admNo + "', '" + sFullName + "','" + gender + "', '" + age + "','" + Fom + "',  '" + Stream + "', '" + imagePath + "', '" + pFullName + "',  '" + PhoneNo + "', '" + email + "', '" + Location + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }

        }
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


        private void AddStudent_Load(object sender, EventArgs e)
        {
            admIncrement();
        }
        students student = new students();

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
        public void admIncrement()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=smsdb");
            MySqlCommand get_adm = new MySqlCommand("SELECT MAX(admNo) AS admNo FROM students", con);
            con.Open();

            MySqlDataReader readata = get_adm.ExecuteReader();
            if (readata.Read())
            {
                try
                {
                    int x = Convert.ToInt32(readata["admNo"]);
                    x = x + 1;
                    textBox1.Text = x.ToString();
                }
                catch (InvalidCastException)
                {
                    textBox1.Text = "1";
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
            admIncrement();
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

        private void save_click(object sender, EventArgs e)
        {
          
            
            
            if (textBox2.Text == "")
            {
                MessageBox.Show("Enter Students Full Name");
            }
            else
            {
                if (radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    MessageBox.Show("Choose Gender");
                }
                else
                {
                    if (numericUpDown1.Value==0)
                    {
                        MessageBox.Show("Choose Age");
                    }
                    else
                    {
                        if (comboBox1.Text=="")
                        {
                            MessageBox.Show("Choose Form");
                        }
                        else
                        {
                            if(comboBox2.Text=="")
                            {
                                MessageBox.Show("Choose Stream");
                            }
                            else
                            {
                                if (textBox6.Text == "")
                                {
                                    MessageBox.Show("Enter Parents Full Name");
                                }
                                else
                                {
                                    if (textBox4.Text == "")
                                    {
                                        MessageBox.Show("Enter Parents Phone Number");
                                    }
                                    else
                                    {
                                        if (textBox3.Text == "")
                                        {
                                            MessageBox.Show("Enter Location");
                                        }
                                        else
                                        {
                                            if (textBox5.Text == "")
                                            {
                                                MessageBox.Show("Enter Email");
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
                                                if (util.IsValidEmail(textBox5.Text))
                                                {
                                                    appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Images\Students\"; // <---
                                                    if (Directory.Exists(appPath) == false)                                              // <---
                                                    {                                                                                    // <---
                                                        Directory.CreateDirectory(appPath);                                              // <---
                                                    }                                                                                    // <---
                                                    try
                                                    {
                                                        imgpath = filepath;
                                                        //public void getData(string adm, string sdfn, string Age, string sex, string frm, string stream,string pfn, string phone, string mail, string location, string imgpath)
                                                        student.getData(textBox1.Text, textBox2.Text, numericUpDown1.Text, sex, comboBox1.Text, comboBox2.Text, textBox6.Text, textBox4.Text, textBox5.Text, textBox3.Text, imgpath);
                                                        //student.display();
                                                        student.insert();
                                                        File.Copy(filepath, appPath + iName); // <---
                                                        
                                                        MessageBox.Show("Saved successfully");
                                                        reset();
                                                        admIncrement();
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
            }

        }
    }
}
