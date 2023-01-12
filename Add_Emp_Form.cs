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
    public partial class Add_Emp_Form : Form
    {
        public Add_Emp_Form()
        {
            InitializeComponent();
        }

        //Connection String
        //Data Source=DESKTOP-UMMS98B\SQLEXPRESS;Initial Catalog=Project_EMS;Integrated Security=True
        public string constring = (@"Data Source=DESKTOP-UMMS98B\SQLEXPRESS;Initial Catalog=Project_EMS;Integrated Security=True");

        //Exit Label
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        //Exit Button
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Form mf = new Main_Form();
            mf.Show();
        }

        //method 
        
        //Insert Button
        private void button1_Click(object sender, EventArgs e)
        {
            int empId = int.Parse(EmpId_Tb.Text);
            string empName = EmpName_Tb.Text;
            string empEmail = EmpEmail_Tb.Text;
            string empPhone = EmpPhone_Tb.Text;
            string empGen = "";
            if (radioButton1.Checked == true)
            {
                empGen = "Male";
            }
            else
            {
                empGen = "Female";
            }
            string empEdu = EmpEdu_Tb.Text;
            string empDesig = EmpDesig_Tb.Text;
            string empDep = EmpDep_Tb.Text;

            //string my_format = "yyyy/mm/dd";
            DateTime empDob = DateTime.Parse(dateTimePicker1.Text);
            DateTime empJd = DateTime.Parse(dateTimePicker1.Text);


            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Insert_Employee '" + empId + "', '" + empName + "','" + empEmail + "','" + empPhone + "','" + empGen + "','" + empDob + "','" + empEdu + "','" + empJd + "','" + empDesig + "','" + empDep + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Employee Added/Inserted Successfully !", "Data Inserted...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Get_Emp_Rec();
            Clearr();
        }
        //Method to display record in datagridview
        void Get_Emp_Rec()
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Display_Employee", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        //Clear method
        public void Clearr()
        {
            EmpId_Tb.Clear();
            EmpName_Tb.Clear();
            EmpEmail_Tb.Clear();
            EmpPhone_Tb.Clear();
            EmpEdu_Tb.Clear();
            EmpDesig_Tb.Clear();
            EmpDep_Tb.Clear();
            if(radioButton1.Checked==true)
            {
                radioButton1.Checked = false;
            }
            else
            {
                radioButton2.Checked = false;
            }

        }

        private void Add_Emp_Form_Load(object sender, EventArgs e)
        {
            Get_Emp_Rec();
        }

        //Update Button
        private void button2_Click(object sender, EventArgs e)
        {
            int empId = int.Parse(EmpId_Tb.Text);
            string empName = EmpName_Tb.Text;
            string empEmail = EmpEmail_Tb.Text;
            string empPhone = EmpPhone_Tb.Text;
            string empGen = "";
            if (radioButton1.Checked == true)
            {
                empGen = "Male";
            }
            else
            {
                empGen = "Female";
            }
            string empEdu = EmpEdu_Tb.Text;
            string empDesig = EmpDesig_Tb.Text;
            string empDep = EmpDep_Tb.Text;

            DateTime empDob = DateTime.Parse(dateTimePicker1.Text);
            DateTime empJd = DateTime.Parse(dateTimePicker1.Text);

            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Update_Employees '" + empId + "', '" + empName + "','" + empEmail + "','" + empPhone + "','" + empGen + "','" + empDob + "','" + empEdu + "','" + empJd + "','" + empDesig + "','" + empDep + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Employee Updated Successfully !", "Data Updated...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Get_Emp_Rec();
            Clearr();

        }

        //Delete Button
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete?", "Delete Info...", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int empid = int.Parse(EmpId_Tb.Text);

                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_Delete_Employees '" + empid + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Employee Deleted Successfully !", "Data Deletedted...", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Get_Emp_Rec();
                Clearr();
            }
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            EmpId_Tb.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            EmpName_Tb.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            EmpEmail_Tb.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            EmpPhone_Tb.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            EmpEdu_Tb.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            EmpDesig_Tb.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            EmpDep_Tb.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
        }

        //Search Button
        private void button6_Click(object sender, EventArgs e)
        {
            int empid = int.Parse(EmpId_Tb.Text);

            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("SP_Search_Employees '" + empid + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        
    }
}
