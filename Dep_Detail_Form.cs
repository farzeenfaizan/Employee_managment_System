using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project_EMS
{
    public partial class Dep_Detail_Form : Form
    {
        public Dep_Detail_Form()
        {
            InitializeComponent();
        }
        //Connection String
        //Data Source=DESKTOP-UMMS98B\SQLEXPRESS;Initial Catalog=Project_EMS;Integrated Security=True
        public string constring = (@"Data Source=DESKTOP-UMMS98B\SQLEXPRESS;Initial Catalog=Project_EMS;Integrated Security=True");


        //Search Button
        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Select the Department....");
            }
            else if (comboBox1.Text == "IT")
            {
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand("Search_Data_IT ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            else if(comboBox1.Text=="Marketing")
            {
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand("Search_Data_Marketing ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            else if (comboBox1.Text == "Engineering")
            {
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand("Search_Data_Engineering ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            else if (comboBox1.Text == "Production")
            {
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand("Search_Data_Production ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }
        //Method to display record in datagridview
        void FetchData()
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Display_Data", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void Dep_Detail_Form_Load(object sender, EventArgs e)
        {
            FetchData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //Exit Button
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Home Button
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Form mf = new Main_Form();
            mf.Show();
        }
    }
}
