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
    public partial class ManageStudents : MaterialForm
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=smsdb");
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        string adm = "";
        public ManageStudents()
        {
            InitializeComponent();
            //datagrid view
            dataGridView1.ColumnCount = 10;
            dataGridView1.Columns[0].Name = "ADM";
            dataGridView1.Columns[1].Name = "Full Name";
            dataGridView1.Columns[2].Name = "Gender";
            dataGridView1.Columns[3].Name = "Age";
            dataGridView1.Columns[4].Name = "Form";
            dataGridView1.Columns[5].Name = "Stream";
            dataGridView1.Columns[6].Name = "Parent Name";
            dataGridView1.Columns[7].Name = "Phone";
            dataGridView1.Columns[8].Name = "Email";
            dataGridView1.Columns[9].Name = "Location";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //SELECTION MODE
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }
        private void populate(string adm, string fname, string sex, string Age, string fom, string strm, string pname, string phone, string email, string location)
        {
            dataGridView1.Rows.Add(adm, fname, sex, Age, fom, strm, pname, phone, email, location);
        }
        //Insert into database
        private void retrieve()
        {
            dataGridView1.Rows.Clear();
            //sql statement
            string sql = "SELECT * FROM students";
            cmd = new MySqlCommand(sql, con);
            //Open con, retrieve, fill datagrid view

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                //loop thr data
                foreach(DataRow row in dt.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString());
                }

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
        private void update(string admnum, string fname, string sex, string Age, string fom, string strm, string pname, string phone, string email, string location)
        {
            string sql = "UPDATE students SET fullname = '"+ fname +"', gender ='" + sex + "', age ='" + Age + "', form ='" + fom + "', stream ='" + strm + "', parentName ='" + pname + "', phone ='" + phone + "', email ='" + email + "', location ='" + location + "' WHERE admNo ='"+admnum+"'" ;
            cmd = new MySqlCommand(sql, con);
            //
            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.UpdateCommand = con.CreateCommand();
                adapter.UpdateCommand.CommandText = sql;

                if (adapter.UpdateCommand.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Update Successful");
                }
                con.Close();
                retrieve();
            }  
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();  
            }
        }
        private void delete(string adm)//DELETE FROM DATABASE
        {
            string sql = "DELETE FROM students WHERE admNO=" + adm + "";
            cmd = new MySqlCommand(sql, con);
            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.DeleteCommand = con.CreateCommand();
                adapter.DeleteCommand.CommandText = sql;
                if(MessageBox.Show("Are you sure you want to delete","DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Deleted Successfully");
                    }
                }

                con.Close();
                retrieve();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
        private void ManageStudents_Load(object sender, EventArgs e)
        {
            retrieve();
        }

        private void retrieve_Click(object sender, EventArgs e)
        {
            retrieve();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            delete(adm);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            adm = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

 

        private void update_Click(object sender, EventArgs e)
        {
            update(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), dataGridView1.SelectedRows[0].Cells[2].Value.ToString(), dataGridView1.SelectedRows[0].Cells[3].Value.ToString(), dataGridView1.SelectedRows[0].Cells[4].Value.ToString(), dataGridView1.SelectedRows[0].Cells[5].Value.ToString(), dataGridView1.SelectedRows[0].Cells[6].Value.ToString(), dataGridView1.SelectedRows[0].Cells[7].Value.ToString(), dataGridView1.SelectedRows[0].Cells[8].Value.ToString(), dataGridView1.SelectedRows[0].Cells[9].Value.ToString());
        }

        private void addstudent_click(object sender, EventArgs e)
        {
            AddStudent frm = new AddStudent();
            frm.Show();
        }
    }
}
