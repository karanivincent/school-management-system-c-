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
using MetroFramework.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Final_smis
{
    public partial class EnterExam : MaterialForm
    {


        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=smsdb");
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        string tbl = "";
        string subject = "";
        string truesubject = "";
        string updatetext = "";


        public EnterExam()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "ADM";
            dataGridView1.Columns[1].Name = "Full Name";
            dataGridView1.Columns[2].Name = "Class";
            dataGridView1.Columns[3].Name = "Stream";
            dataGridView1.Columns[4].Name = "Marks";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //SELECTION MODE
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

        }
        private string sqltextupdate(string admnum, string marks)
        {

            string sqlupdate = "";

            if(comboBox3.Text=="1")
            {
                if (tbl == "examform1" && subject == "mathematics")
                {
                    sqlupdate = "UPDATE examform1 SET mathematics1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "mathematics")
                {
                    sqlupdate = "UPDATE examform2 SET mathematics1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "mathematics")
                {
                    sqlupdate = "UPDATE examform3 SET mathematics1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "mathematics")
                {
                    sqlupdate = "UPDATE examform4 SET mathematics1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "english")
                {
                    sqlupdate = "UPDATE examform1 SET english1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "english")
                {
                    sqlupdate = "UPDATE examform2 SET english1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "english")
                {
                    sqlupdate = "UPDATE examform3 SET english1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "english")
                {
                    sqlupdate = "UPDATE examform4 SET english1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "kiswahili")
                {
                    sqlupdate = "UPDATE examform1 SET kiswahili1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "kiswahili")
                {
                    sqlupdate = "UPDATE examform2 SET kiswahili1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "kiswahili")
                {
                    sqlupdate = "UPDATE examform3 SET kiswahili1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "kiswahili")
                {
                    sqlupdate = "UPDATE examform4 SET kiswahili1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "chemistry")
                {
                    sqlupdate = "UPDATE examform1 SET chemistry1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "chemistry")
                {
                    sqlupdate = "UPDATE examform2 SET chemistry1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "chemistry")
                {
                    sqlupdate = "UPDATE examform3 SET chemistry1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "chemistry")
                {
                    sqlupdate = "UPDATE examform4 SET chemistry1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "biology")
                {
                    sqlupdate = "UPDATE examform1 SET biology1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "biology")
                {
                    sqlupdate = "UPDATE examform2 SET biology1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "biology")
                {
                    sqlupdate = "UPDATE examform3 SET biology1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "biology")
                {
                    sqlupdate = "UPDATE examform4 SET biology1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "physics")
                {
                    sqlupdate = "UPDATE examform1 SET physics1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "physics")
                {
                    sqlupdate = "UPDATE examform2 SET physics1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "physics")
                {
                    sqlupdate = "UPDATE examform3 SET physics1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "physics")
                {
                    sqlupdate = "UPDATE examform4 SET physics1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "geography")
                {
                    sqlupdate = "UPDATE examform1 SET geography1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "geography")
                {
                    sqlupdate = "UPDATE examform2 SET geography1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "geography")
                {
                    sqlupdate = "UPDATE examform3 SET geography1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "geography")
                {
                    sqlupdate = "UPDATE examform4 SET geography1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "history")
                {
                    sqlupdate = "UPDATE examform1 SET history1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "history")
                {
                    sqlupdate = "UPDATE examform2 SET history1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "history")
                {
                    sqlupdate = "UPDATE examform3 SET history1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "history")
                {
                    sqlupdate = "UPDATE examform4 SET history1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "CRE")
                {
                    sqlupdate = "UPDATE examform1 SET CRE1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "CRE")
                {
                    sqlupdate = "UPDATE examform2 SET CRE1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "CRE")
                {
                    sqlupdate = "UPDATE examform3 SET CRE1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "CRE")
                {
                    sqlupdate = "UPDATE examform4 SET CRE1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "BS")
                {
                    sqlupdate = "UPDATE examform1 SET BS1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "BS")
                {
                    sqlupdate = "UPDATE examform2 SET BS1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "BS")
                {
                    sqlupdate = "UPDATE examform3 SET BS1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "BS")
                {
                    sqlupdate = "UPDATE examform4 SET BS1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "agriculture")
                {
                    sqlupdate = "UPDATE examform1 SET agriculture1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "agriculture")
                {
                    sqlupdate = "UPDATE examform2 SET agriculture1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "agriculture")
                {
                    sqlupdate = "UPDATE examform3 SET agriculture1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "agriculture")
                {
                    sqlupdate = "UPDATE examform4 SET agriculture1 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }

            }
            else if(comboBox3.Text=="2")
            {
                if (tbl == "examform1" && subject == "mathematics")
                {
                    sqlupdate = "UPDATE examform1 SET mathematics2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "mathematics")
                {
                    sqlupdate = "UPDATE examform2 SET mathematics2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "mathematics")
                {
                    sqlupdate = "UPDATE examform3 SET mathematics2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "mathematics")
                {
                    sqlupdate = "UPDATE examform4 SET mathematics2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "english")
                {
                    sqlupdate = "UPDATE examform1 SET english2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "english")
                {
                    sqlupdate = "UPDATE examform2 SET english2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "english")
                {
                    sqlupdate = "UPDATE examform3 SET english2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "english")
                {
                    sqlupdate = "UPDATE examform4 SET english2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "kiswahili")
                {
                    sqlupdate = "UPDATE examform1 SET kiswahili2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "kiswahili")
                {
                    sqlupdate = "UPDATE examform2 SET kiswahili2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "kiswahili")
                {
                    sqlupdate = "UPDATE examform3 SET kiswahili2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "kiswahili")
                {
                    sqlupdate = "UPDATE examform4 SET kiswahili2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "chemistry")
                {
                    sqlupdate = "UPDATE examform1 SET chemistry2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "chemistry")
                {
                    sqlupdate = "UPDATE examform2 SET chemistry2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "chemistry")
                {
                    sqlupdate = "UPDATE examform3 SET chemistry2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "chemistry")
                {
                    sqlupdate = "UPDATE examform4 SET chemistry2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "biology")
                {
                    sqlupdate = "UPDATE examform1 SET biology2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "biology")
                {
                    sqlupdate = "UPDATE examform2 SET biology2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "biology")
                {
                    sqlupdate = "UPDATE examform3 SET biology2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "biology")
                {
                    sqlupdate = "UPDATE examform4 SET biology2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "physics")
                {
                    sqlupdate = "UPDATE examform1 SET physics2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "physics")
                {
                    sqlupdate = "UPDATE examform2 SET physics2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "physics")
                {
                    sqlupdate = "UPDATE examform3 SET physics2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "physics")
                {
                    sqlupdate = "UPDATE examform4 SET physics2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "geography")
                {
                    sqlupdate = "UPDATE examform1 SET geography2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "geography")
                {
                    sqlupdate = "UPDATE examform2 SET geography2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "geography")
                {
                    sqlupdate = "UPDATE examform3 SET geography2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "geography")
                {
                    sqlupdate = "UPDATE examform4 SET geography2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "history")
                {
                    sqlupdate = "UPDATE examform1 SET history2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "history")
                {
                    sqlupdate = "UPDATE examform2 SET history2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "history")
                {
                    sqlupdate = "UPDATE examform3 SET history2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "history")
                {
                    sqlupdate = "UPDATE examform4 SET history2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "CRE")
                {
                    sqlupdate = "UPDATE examform1 SET CRE2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "CRE")
                {
                    sqlupdate = "UPDATE examform2 SET CRE2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "CRE")
                {
                    sqlupdate = "UPDATE examform3 SET CRE2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "CRE")
                {
                    sqlupdate = "UPDATE examform4 SET CRE2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "BS")
                {
                    sqlupdate = "UPDATE examform1 SET BS2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "BS")
                {
                    sqlupdate = "UPDATE examform2 SET BS2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "BS")
                {
                    sqlupdate = "UPDATE examform3 SET BS2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "BS")
                {
                    sqlupdate = "UPDATE examform4 SET BS2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "agriculture")
                {
                    sqlupdate = "UPDATE examform1 SET agriculture2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "agriculture")
                {
                    sqlupdate = "UPDATE examform2 SET agriculture2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "agriculture")
                {
                    sqlupdate = "UPDATE examform3 SET agriculture2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "agriculture")
                {
                    sqlupdate = "UPDATE examform4 SET agriculture2 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }

            }
            else if(comboBox3.Text=="3")
            {
                if (tbl == "examform1" && subject == "mathematics")
                {
                    sqlupdate = "UPDATE examform1 SET mathematics3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "mathematics")
                {
                    sqlupdate = "UPDATE examform2 SET mathematics3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "mathematics")
                {
                    sqlupdate = "UPDATE examform3 SET mathematics3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "mathematics")
                {
                    sqlupdate = "UPDATE examform4 SET mathematics3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "english")
                {
                    sqlupdate = "UPDATE examform1 SET english3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "english")
                {
                    sqlupdate = "UPDATE examform2 SET english3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "english")
                {
                    sqlupdate = "UPDATE examform3 SET english3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "english")
                {
                    sqlupdate = "UPDATE examform4 SET english3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "kiswahili")
                {
                    sqlupdate = "UPDATE examform1 SET kiswahili3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "kiswahili")
                {
                    sqlupdate = "UPDATE examform2 SET kiswahili3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "kiswahili")
                {
                    sqlupdate = "UPDATE examform3 SET kiswahili3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "kiswahili")
                {
                    sqlupdate = "UPDATE examform4 SET kiswahili3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "chemistry")
                {
                    sqlupdate = "UPDATE examform1 SET chemistry3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "chemistry")
                {
                    sqlupdate = "UPDATE examform2 SET chemistry3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "chemistry")
                {
                    sqlupdate = "UPDATE examform3 SET chemistry3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "chemistry")
                {
                    sqlupdate = "UPDATE examform4 SET chemistry3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "biology")
                {
                    sqlupdate = "UPDATE examform1 SET biology3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "biology")
                {
                    sqlupdate = "UPDATE examform2 SET biology3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "biology")
                {
                    sqlupdate = "UPDATE examform3 SET biology3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "biology")
                {
                    sqlupdate = "UPDATE examform4 SET biology3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "physics")
                {
                    sqlupdate = "UPDATE examform1 SET physics3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "physics")
                {
                    sqlupdate = "UPDATE examform2 SET physics3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "physics")
                {
                    sqlupdate = "UPDATE examform3 SET physics3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "physics")
                {
                    sqlupdate = "UPDATE examform4 SET physics3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "geography")
                {
                    sqlupdate = "UPDATE examform1 SET geography3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "geography")
                {
                    sqlupdate = "UPDATE examform2 SET geography3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "geography")
                {
                    sqlupdate = "UPDATE examform3 SET geography3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "geography")
                {
                    sqlupdate = "UPDATE examform4 SET geography3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "history")
                {
                    sqlupdate = "UPDATE examform1 SET history3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "history")
                {
                    sqlupdate = "UPDATE examform2 SET history3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "history")
                {
                    sqlupdate = "UPDATE examform3 SET history3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "history")
                {
                    sqlupdate = "UPDATE examform4 SET history3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "CRE")
                {
                    sqlupdate = "UPDATE examform1 SET CRE3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "CRE")
                {
                    sqlupdate = "UPDATE examform2 SET CRE3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "CRE")
                {
                    sqlupdate = "UPDATE examform3 SET CRE3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "CRE")
                {
                    sqlupdate = "UPDATE examform4 SET CRE3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "BS")
                {
                    sqlupdate = "UPDATE examform1 SET BS3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "BS")
                {
                    sqlupdate = "UPDATE examform2 SET BS3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "BS")
                {
                    sqlupdate = "UPDATE examform3 SET BS3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "BS")
                {
                    sqlupdate = "UPDATE examform4 SET BS3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform1" && subject == "agriculture")
                {
                    sqlupdate = "UPDATE examform1 SET agriculture3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform2" && subject == "agriculture")
                {
                    sqlupdate = "UPDATE examform2 SET agriculture3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform3" && subject == "agriculture")
                {
                    sqlupdate = "UPDATE examform3 SET agriculture3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }
                else if (tbl == "examform4" && subject == "agriculture")
                {
                    sqlupdate = "UPDATE examform4 SET agriculture3 = '" + marks + "' WHERE regNumber = '" + admnum + "'";
                }

            }

            return sqlupdate;
        }

        private void update()
        {
            
            string sql = updatetext;
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

        private void populate(string adm, string fname, string Class, string strm, string marks)
        {
            dataGridView1.Rows.Add(adm, fname, Class, strm, marks);
        }

        private void retrieve()
        {

            dataGridView1.Rows.Clear();
            

            subject = textBox2.Text;
            //sql statement
            string sql = "SELECT regNumber, fullName, class, stream, "+truesubject+"  FROM "+tbl+" WHERE stream ='"+comboBox2.Text+"'";
           
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

        private void loadRecords_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox3.Text=="")
            {
                MessageBox.Show("Please select a subject to proceed");
            }
            else
            {

                subject = textBox2.Text;
                if (comboBox3.Text == "1")
                {
                    truesubject = textBox2.Text + "1";
                }
                else if (comboBox3.Text == "2")
                {
                    truesubject = textBox2.Text + "2";
                }
                else if (comboBox3.Text == "3")
                {
                    truesubject = textBox2.Text + "3";
                }

                if (comboBox1.Text == "1")
                {
                    tbl = "examform1";
                }

                else if (comboBox1.Text == "2")
                {
                    tbl = "examform2";
                }
                 else if (comboBox1.Text == "3")
                    {
                        tbl = "examform3";
                    }
                     else if (comboBox1.Text == "4")
                        {
                            tbl = "examform4";
                        }
                retrieve();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updatetext=sqltextupdate(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            MessageBox.Show(updatetext);
            update();
        }
    }
}
