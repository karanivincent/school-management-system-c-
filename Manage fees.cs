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
using MetroFramework.Forms;


namespace Final_smis
{
    public partial class Manage_fees : MaterialForm
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=smsdb");
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();

        int adm = 0;
        int feesPaid = 0;
        int totalfees = 0;
        int balance = 0;
        public Manage_fees()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "ADM";
            dataGridView1.Columns[1].Name = "Full Name";
            dataGridView1.Columns[2].Name = "Total Fees";
            dataGridView1.Columns[3].Name = "Fees Paid";
            dataGridView1.Columns[4].Name = "Balance";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //SELECTION MODE
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }
        private void update_click(object sender, EventArgs e)
        {
            adm = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            if (textBox1.Text=="")
            {
                MessageBox.Show("Please Enter amount before Updating");
            }
            else
            {
                getfees();
                feesPaid = feesPaid + Int32.Parse(textBox1.Text);
                balance = totalfees - feesPaid;
                if (MessageBox.Show("Update for " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "?","CONFIRM UPDATE", MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    update();
                    textBox1.Text = "";
                }
                retrieve();
            }

        }

        public void getfees()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=smsdb");
            MySqlCommand get_paid;
            MySqlCommand get_balance;
            MySqlCommand get_fees;
            if (comboBox3.Text == "1")
            {
                get_paid = new MySqlCommand("SELECT feesPaid1 FROM fees WHERE admNo =" + adm + "", con);
                get_balance = new MySqlCommand("SELECT balance1 FROM fees WHERE admNo =" + adm + "", con);
                get_fees = new MySqlCommand("SELECT term1fees FROM fees WHERE admNo =" + adm + "", con);
                con.Open();

                MySqlDataReader readpaid = get_paid.ExecuteReader();
                if (readpaid.Read())
                {
                    try
                    {
                        feesPaid = Convert.ToInt32(readpaid["feesPaid1"]);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                con.Close();

                con.Open();
                MySqlDataReader readbalance = get_balance.ExecuteReader();
                if (readbalance.Read())
                {
                    try
                    {
                        balance = Convert.ToInt32(readbalance["balance1"]);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                con.Close();

                con.Open();
                MySqlDataReader readfees = get_fees.ExecuteReader();
                if (readfees.Read())
                {
                    try
                    {
                        totalfees = Convert.ToInt32(readfees["term1fees"]);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                con.Close();
            }
            else if (comboBox3.Text=="2")
            {
                get_paid = new MySqlCommand("SELECT feesPaid2 FROM fees WHERE admNo =" + adm + "", con);
                get_balance = new MySqlCommand("SELECT balance2 FROM fees WHERE admNo =" + adm + "", con);
                get_fees = new MySqlCommand("SELECT term2fees FROM fees WHERE admNo =" + adm + "", con);
                con.Open();

                MySqlDataReader readpaid = get_paid.ExecuteReader();
                if (readpaid.Read())
                {
                    try
                    {
                        feesPaid = Convert.ToInt32(readpaid["feesPaid2"]);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                con.Close();

                con.Open();
                MySqlDataReader readbalance = get_balance.ExecuteReader();
                if (readbalance.Read())
                {
                    try
                    {
                        balance = Convert.ToInt32(readbalance["balance2"]);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                con.Close();

                con.Open();
                MySqlDataReader readfees = get_fees.ExecuteReader();
                if (readfees.Read())
                {
                    try
                    {
                        totalfees = Convert.ToInt32(readfees["term2fees"]);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                con.Close();
            }
            else if (comboBox3.Text=="3")
            {
                get_paid = new MySqlCommand("SELECT feesPaid3 FROM fees WHERE admNo =" + adm + "", con);
                get_balance = new MySqlCommand("SELECT balance3 FROM fees WHERE admNo =" + adm + "", con);
                get_fees = new MySqlCommand("SELECT term3fees FROM fees WHERE admNo =" + adm + "", con);
                con.Open();

                MySqlDataReader readpaid = get_paid.ExecuteReader();
                if (readpaid.Read())
                {
                    try
                    {
                        feesPaid = Convert.ToInt32(readpaid["feesPaid3"]);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                con.Close();

                con.Open();
                MySqlDataReader readbalance = get_balance.ExecuteReader();
                if (readbalance.Read())
                {
                    try
                    {
                        balance = Convert.ToInt32(readbalance["balance3"]);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                con.Close();

                con.Open();
                MySqlDataReader readfees = get_fees.ExecuteReader();
                if (readfees.Read())
                {
                    try
                    {
                        totalfees = Convert.ToInt32(readfees["term3fees"]);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                con.Close();
            }
           



        }
        private void digitonly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }


        private void update()
        {
            if(comboBox3.Text=="1")
            {
                string sql = "UPDATE fees SET feesPaid1 = " + feesPaid + ",  balance1=" + balance + " WHERE admNo =" + adm + "";
                cmd = new MySqlCommand(sql, con);
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
            else if(comboBox3.Text=="2")
            {
                string sql = "UPDATE fees SET feesPaid2 = " + feesPaid + ",  balance2=" + balance + " WHERE admNo =" + adm + "";
                cmd = new MySqlCommand(sql, con);
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
            else if(comboBox3.Text=="3")
            {
                string sql = "UPDATE fees SET feesPaid3 = " + feesPaid + ",  balance3=" + balance + " WHERE admNo =" + adm + "";
                cmd = new MySqlCommand(sql, con);
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
            
        }
        private void populate(string adm, string fname, string fees, string feepaid, string balance)
        {
            dataGridView1.Rows.Add(adm, fname, fees, feepaid, balance);
        }

        private void retrieve()
        {

            dataGridView1.Rows.Clear();



            //sql statement
            string sql = "";
            if (comboBox3.Text=="1")
            {
                sql = "SELECT admNo, fullName, term1fees, feesPaid1, balance1 FROM fees WHERE form ='" + comboBox1.Text + "' AND stream='" + comboBox2.Text + "' ";
            }
            if (comboBox3.Text == "2")
            {
                sql = "SELECT admNo, fullName, term2fees, feesPaid2, balance2 FROM fees WHERE form ='" + comboBox1.Text + "' AND stream='" + comboBox2.Text + "' ";
            }
            if (comboBox3.Text == "3")
            {
                sql = "SELECT admNo, fullName, term3fees, feesPaid3, balance3 FROM fees WHERE form ='" + comboBox1.Text + "' AND stream='" + comboBox2.Text + "' ";
            }
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
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
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

        private void retrieve_click(object sender, EventArgs e)
        {
            
            if(comboBox1.Text==""||comboBox2.Text==""||comboBox3.Text=="")
            {
                MessageBox.Show("Please select Form, Stream and Term to continue ");
            }
            else
            {
                retrieve();
            }
        }
    }
}
