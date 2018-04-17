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
using MaterialSkin;
using MaterialSkin.Controls;

namespace Final_smis
{
    public partial class ManageTeachers : MaterialForm
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=smsdb");
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        string teacherid = "";
        public ManageTeachers()
        {
            InitializeComponent();
            //datagrid view
            dataGridView1.ColumnCount = 9;
            dataGridView1.Columns[0].Name = "Teacher ID";
            dataGridView1.Columns[1].Name = "Full Name";
            dataGridView1.Columns[2].Name = "Gender";
            dataGridView1.Columns[3].Name = "Age";
            dataGridView1.Columns[4].Name = "ID";
            dataGridView1.Columns[5].Name = "Phone";
            dataGridView1.Columns[6].Name = "Email";
            dataGridView1.Columns[7].Name = "Location";
            dataGridView1.Columns[8].Name = "Designation";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //SELECTION MODE
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void populate(string tid, string fname, string sex, string Age, string id, string phone, string email, string location, string designation)
        {
            dataGridView1.Rows.Add(tid, fname, sex, Age, id, phone, email, location, designation);
        }
        //Insert into database
        private void retrieve()
        {
            dataGridView1.Rows.Clear();
            //sql statement
            string sql = "SELECT * FROM teachers";
            cmd = new MySqlCommand(sql, con);
            //Open con, retrieve, fill datagrid view

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                //loop thr data
                foreach (DataRow row in dt.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString());
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
        private void update(string tichaid, string fname, string sex, string Age, string ID, string phone, string email, string location, string designation)
        {
            string sql = "UPDATE students SET fullname = '" + fname + "', gender ='" + sex + "', age ='" + Age + "', ID ='" + ID + "', phone ='" + phone + "', email ='" + email + "', location ='" + location + "', designation ='"+designation+"' WHERE admNo ='" + tichaid + "'";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
        private void delete(string TID)//DELETE FROM DATABASE
        {
            string sql = "DELETE FROM teachers WHERE teacherID=" + TID + "";
            cmd = new MySqlCommand(sql, con);
            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.DeleteCommand = con.CreateCommand();
                adapter.DeleteCommand.CommandText = sql;
                if (MessageBox.Show("Are you sure you want to delete", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Deleted Successfully");
                    }
                }

                con.Close();
                retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
        private void ManageTeachers_Load(object sender, EventArgs e)
        {
            retrieve();
        }

        private void retrieve_Click(object sender, EventArgs e)
        {
            retrieve();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            delete(teacherid);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            teacherid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }


        private void update_Click(object sender, EventArgs e)
        {
            update(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), dataGridView1.SelectedRows[0].Cells[2].Value.ToString(), dataGridView1.SelectedRows[0].Cells[3].Value.ToString(), dataGridView1.SelectedRows[0].Cells[4].Value.ToString(), dataGridView1.SelectedRows[0].Cells[5].Value.ToString(), dataGridView1.SelectedRows[0].Cells[6].Value.ToString(), dataGridView1.SelectedRows[0].Cells[7].Value.ToString(), dataGridView1.SelectedRows[0].Cells[8].Value.ToString());
        }

        private void addteacher_Click(object sender, EventArgs e)
        {
            AddTeacher frm = new AddTeacher();
            frm.Show();
        }
    }
}
