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
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        //Connection String
        //Data Source=DESKTOP-UMMS98B\SQLEXPRESS;Initial Catalog=Project_EMS;Integrated Security=True
        public string constring = (@"Data Source=WASIQ\SQLEXPRESS;Initial Catalog=Project_EMS;Integrated Security=True");

        //Exit Button
        private void Exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {

        }

        //Login Button
        private void login_button_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string username = un_textBox.Text;
            string password = pass_textBox.Text;
            SqlCommand cmd = new SqlCommand("select UserName,UserPass from Login_tbl where UserName='" + un_textBox.Text + "'and UserPass='" + pass_textBox.Text + " ' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Check_Function();

            }
            else
            {
                MessageBox.Show("Invalid Login please check username and password!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                un_textBox.Clear();
                pass_textBox.Clear();
            }
            con.Close();
        }

        //Function
        public void Check_Function()
        {

            if (un_textBox.Text == "Admin" && pass_textBox.Text == "123admin")
            {
                MessageBox.Show("Login sucessfully !", "Logged in!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Main_Form mf = new Main_Form();
                mf.Show();
            }
            else
            {
                MessageBox.Show("Login sucessfully !", "Logged in!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Emp_Main_Form empmf = new Emp_Main_Form();
                empmf.Show();
            }
        }
    }
}
