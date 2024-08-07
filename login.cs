using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_Assignment
{
    public partial class login : Form
    {

        private int value = 0;
        private int dotCount = 0;
        private string[] dots = { " .", " ..", " ...", " ...." };

        public login()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            int steps = 100;
            int durationInSeconds = 3;
            int increment = steps / (durationInSeconds * 1000 / timer1.Interval);

            //Progrss bar
            value += increment;
            ProgressBar.Value = Math.Min(value, 100);
            if (ProgressBar.Value == 100)
            {
                label1.ForeColor = Color.Black;
                timer1.Stop();
                label1.Text = "Loading complete !";
            }
            else
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Loading data" + dots[dotCount];
                dotCount = (dotCount + 1) % dots.Length;
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            POS_dbDataContext DB_POS = new POS_dbDataContext();
            var user = DB_POS.tblStaffs.FirstOrDefault(m => m.username == txtUsername.Text && m.password == txtPassword.Text);

            //Expand and Unexpand Menu 
            if (user != null)
            {
                this.Hide();
                POS POSFrm = new POS(user.username);
                POSFrm.Show();
            }
            else if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please input your information !");
            }
            else
            {
                MessageBox.Show("Wrong Credentials !");
                txtUsername.Clear(); 
                txtPassword.Clear();
            }
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

