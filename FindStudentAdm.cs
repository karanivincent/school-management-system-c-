using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;

namespace Final_smis
{
    public partial class FindStudentAdm : MaterialForm
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=smsdb");
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        public FindStudentAdm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            //sql statement
            string sql = "SELECT * FROM students WHERE admNo = '"+textBox1.Text+"'";
            cmd = new MySqlCommand(sql, con);
            //Open con, retrieve, fill datagrid view

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                //loop thr data
                string pic = "";
                
                foreach (DataRow row in dt.Rows)
                {
                    textBox2.Text = row[1].ToString(); textBox3.Text = row[2].ToString(); textBox4.Text = row[3].ToString();  textBox5.Text = row[4].ToString(); textBox6.Text = row[5].ToString(); textBox7.Text = row[6].ToString();  textBox8.Text = row[7].ToString();  textBox9.Text = row[8].ToString(); textBox10.Text = row[9].ToString(); pic = row[10].ToString();
                }
                pictureBox1.Image = new Bitmap(pic);
                con.Close();
                //Clear datatable
                dt.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
    }
}
