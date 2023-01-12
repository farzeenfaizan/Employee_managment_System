using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_EMS
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Emp_Form aef = new Add_Emp_Form();
            aef.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form lf = new Login_Form();
            lf.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dep_Detail_Form ddf = new Dep_Detail_Form();
            ddf.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee_Form ef = new Employee_Form();
            ef.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Salary_Form sf = new Salary_Form();
            sf.Show();
        }
    }
}
