using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryApp.Class;
using MySql.Data.MySqlClient;

namespace InventoryApp
{
    public partial class LogIn : Form
        
    {
        connection con = new connection();
        accounts acct = new accounts();
        public LogIn()
        {
            InitializeComponent();
           
        }
        public void checkstatus()
        {
            try
            {
                con.connectdb.Open();
                label1.Text = "ONLINE";
                label1.ForeColor = Color.Green;

            }
            catch
            {
                label1.Text = "OFFLINE";
                label1.ForeColor = Color.Red;
                txtUser.Text = "OFFLINE";
                txtUser.Enabled = false;
                txtPass.Enabled = false;
                btnRegister.Enabled = false;
                btnSignIn.Enabled = false;
            }
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            checkstatus();

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            acct.username = txtUser.Text;
            acct.userpass = txtPass.Text;
            bool verify = acct.Validate_User();

            if(verify)
            {
                MessageBox.Show("Welcome " + acct.username);
                Form1 form1 = new Form1();
                form1.ShowDialog();
                form1.Dispose();
                LogIn.ActiveForm.Close();
                
            }
            else
            {
                MessageBox.Show("Please Check your username and password!");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
            form1.Dispose();
            LogIn.ActiveForm.Close();
        }
    }
}
