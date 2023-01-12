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
    public partial class Emp_Main_Form : Form
    {
        public Emp_Main_Form()
        {
            InitializeComponent();
        }

        //Employee
        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Emp_Form ef = new Emp_Form();
            ef.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Emp_Salary_Form sf = new Emp_Salary_Form();
            sf.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form lf = new Login_Form();
            lf.Show();
        }
    }
}
