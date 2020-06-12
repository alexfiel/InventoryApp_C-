using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryApp.Class;
using MySql.Data.MySqlClient;

namespace InventoryApp
{
    public partial class Form1 : Form
    {
        CRUD crud = new CRUD();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //create
            RandomCharacter();
            CREATE();
            READ();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //update
            UPDATE();
            READ();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //delete
            DELETE();
            READ();
        }
        
        //Read
        public void READ()
        {
            dataGridView1.DataSource = null;
            crud.Read_data();
            dataGridView1.DataSource = crud.dt;
        }
        //create
        public void CREATE()
        {
            crud.objid = txtobjid.Text;
            crud.user = txtUsername.Text;
            crud.pass = txtPassword.Text;
            crud.email = txtEmail.Text;
            crud.role = cboRole.Text;
            crud.Create_data();

        }
        public void UPDATE()
        {
            crud.objid = txtobjid.Text;
            crud.user = txtUsername.Text;
            crud.pass = txtPassword.Text;
            crud.email = txtEmail.Text;
            crud.role = cboRole.Text;
            crud.Update_data();
        }
        public void DELETE()
        {
            crud.objid = txtobjid.Text;
            crud.Delete_data();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //get data
            DataGridView senderGrid = (DataGridView)sender;
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    txtobjid.Text = (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    txtUsername.Text = (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    txtPassword.Text = (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    txtEmail.Text = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    cboRole.Text = (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                }   
            }
            catch 
            {
                MessageBox.Show("You did something I don't know!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            READ();
        }

        //GENERATE RANDOM STRING
        private void RandomCharacter()

        {
            int length = 8;
            System.Random numRandom = new System.Random();

            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);

            }
            
            txtobjid.Text = "USER-" + str_build.ToString() + numRandom.Next(500) ;

        }

    }
}
