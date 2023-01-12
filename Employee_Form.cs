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
    public partial class Employee_Form : Form
    {
        public Employee_Form()
        {
            InitializeComponent();
        }
        //Connection String
        //Data Source=DESKTOP-UMMS98B\SQLEXPRESS;Initial Catalog=Project_EMS;Integrated Security=True
        public string constring = (@"Data Source=DESKTOP-UMMS98B\SQLEXPRESS;Initial Catalog=Project_EMS;Integrated Security=True");

        private void Employee_Form_Load(object sender, EventArgs e)
        {

        }

        //method
        public void Fetch_Employee_Data()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Employee Id.");
            }
            else
            {
                int empid = int.Parse(textBox1.Text);
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_Spec_Employee '" + empid + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    EmpName_lbl.Text = dr[1].ToString();
                    EmpAddress_lbl.Text = dr[2].ToString();
                    EmpPhone_lbl.Text = dr[3].ToString();
                    EmpGender_lbl.Text = dr[4].ToString();
                    EmpDOB_lbl.Text = dr[5].ToString();
                    EmpEdu_lbl.Text = dr[6].ToString();
                    EmpJD_lbl.Text = dr[7].ToString();
                    EmpDesig_lbl.Text = dr[8].ToString();
                    EmpDep_lbl.Text = dr[9].ToString();

                    EmpName_lbl.Visible = true;
                    EmpAddress_lbl.Visible = true;
                    EmpPhone_lbl.Visible = true;
                    EmpGender_lbl.Visible = true;
                    EmpDOB_lbl.Visible = true;
                    EmpEdu_lbl.Visible = true;
                    EmpJD_lbl.Visible = true;
                    EmpDesig_lbl.Visible = true;
                    EmpDep_lbl.Visible = true;
                }
                con.Close();
            }
        }

        //Fetch Data Button
        private void button2_Click(object sender, EventArgs e)
        {
            Fetch_Employee_Data();
        }

        //Home Button
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Form mf = new Main_Form();
            mf.Show();
        }

        //Exit Button
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
