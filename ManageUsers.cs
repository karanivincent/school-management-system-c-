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
    public partial class ManageUsers : MaterialForm
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=smsdb");
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        string imgpath = "";
        string filepath = "";
        string iName = "";
        string appPath = "";
        string userName = "";
        int id = 0;
        ListBox lbox = new ListBox();
        public ManageUsers()
        {
            InitializeComponent();
            //datagrid view
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "User ID";
            dataGridView1.Columns[1].Name = "Full Name";
            DataGridViewColumn column = dataGridView1.Columns[0];
            column.Width = 60;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //SELECTION MODE
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            // fillListBox();


           
        }


        private void Form4_Load(object sender, EventArgs e)
        {
            retrieve();
        }
        private void populate(string ID, string fullname)
        {
            dataGridView1.Rows.Add(ID, fullname);
        }

        private void retrieve()
        {
            dataGridView1.Rows.Clear();
            //sql statement
            string sql = "SELECT  ID, fullName FROM users";
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
                    populate(row[0].ToString(), row[1].ToString());
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





        string userID;
        private void delete(string adm)//DELETE FROM DATABASE
        {
            string sql = "DELETE FROM users WHERE ID ='" + adm + "'";
            cmd = new MySqlCommand(sql, con);
            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.DeleteCommand = con.CreateCommand();
                adapter.DeleteCommand.CommandText = sql;
                if (MessageBox.Show("Are you sure you want to delete "+userName+"", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
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

        private void deleteuser_click(object sender, EventArgs e)
        {
            delete(userID);
            

        }




        private void dataGridView1_Click(object sender, EventArgs e)
        {
            userID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            userName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }
    }
}
