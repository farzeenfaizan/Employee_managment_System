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
    public partial class Emp_Salary_Form : Form
    {
        public Emp_Salary_Form()
        {
            InitializeComponent();
        }

        private void Emp_Salary_Form_Load(object sender, EventArgs e)
        {

        }
        //Connection String
        //Data Source=DESKTOP-UMMS98B\SQLEXPRESS;Initial Catalog=Project_EMS;Integrated Security=True
        public string constring = (@"Data Source=DESKTOP-UMMS98B\SQLEXPRESS;Initial Catalog=Project_EMS;Integrated Security=True");

        //method
        public void Fetch_Employee_Data()
        {
            if (EmpId_Tb.Text == "")
            {
                MessageBox.Show("Enter Employee Id.");
            }
            else
            {
                int empid = int.Parse(EmpId_Tb.Text);
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_Spec_Employee '" + empid + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    EmpName_lbl.Text = dr[1].ToString();
                    EmpDesig_lbl.Text = dr[8].ToString();

                    EmpName_lbl.Visible = true;
                    EmpDesig_lbl.Visible = true;
                }
                con.Close();
            }
        }

        //Fetch Data Button
        private void button1_Click(object sender, EventArgs e)
        {
            Fetch_Employee_Data();
        }

        public int DailyPay;
        //View Button
        private void button3_Click(object sender, EventArgs e)
        {

            if (EmpDesig_lbl.Text == "")
            {
                MessageBox.Show("Enter the Employee ID...");
            }
            else if (WorkDays_Tb.Text == "")
            {
                MessageBox.Show("Enter a Valid Number of Days.");
            }
            else if (WorkDays_Tb.Text == "" || Convert.ToInt32(WorkDays_Tb.Text) > 28)
            {
                MessageBox.Show("Enter a Valid Number of Days.");
            }
            else if (EmpDesig_lbl.Text == "Manager")
            {
                DailyPay = 2000;
            }
            else if (EmpDesig_lbl.Text == "Manager Assistant")
            {
                DailyPay = 1500;
            }
            else if (EmpDesig_lbl.Text == "Worker")
            {
                DailyPay = 1200;
            }
            else if (EmpDesig_lbl.Text == "Helper")
            {
                DailyPay = 1000;
            }
            else
            {
                DailyPay = 500;
            }

            int TotalPay = DailyPay * Convert.ToInt32(WorkDays_Tb.Text);
            richTextBox1.Text = "Employee Id:  " + EmpId_Tb.Text + "\n" + "Employee Name:  " + EmpName_lb.Text + "\n" + "Employee Designation:  " + EmpDesig_lbl + "\n" + "Days Worked:  " + WorkDays_Tb.Text + "\n" + "Daily Salary Rs:  " + Convert.ToString(DailyPay) + "\n" + "Total Amount Rs:  " + Convert.ToString(TotalPay);

            EmpName_lbl.Visible = true;
            EmpDesig_lbl.Visible = true;

        }

        //Home Button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Emp_Main_Form emf = new Emp_Main_Form();
            emf.Show();
        }

        //Exit Button
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
