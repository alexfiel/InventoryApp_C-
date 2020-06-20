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
    public partial class NewInventory : Form
    {
        CRUD crud = new CRUD();
        private string InvObjid; 
        public NewInventory()
        {
            InitializeComponent();
           
        }

        private void NewInventory_Load(object sender, EventArgs e)
        {

        }

        public void CreateNewInventory()
        {
            RandomCharacter();
            crud.invobjid = InvObjid;
            crud.category = cboCategory.Text;
            crud.prodname = txtxName.Text;
            crud.description = txtDescription.Text;
            crud.expensecode = cboExpenseCode.Text;
            crud.serial = txtSerial.Text;
            crud.supplier = cboSupplier.Text;
            crud.DateReceived = dtDateReceived.Value;
            crud.CreateInventory();

            
        }
        public void UpdateInventory() 
        {
            crud.invobjid = InvObjid;
            crud.category = cboCategory.Text;
            crud.prodname = txtxName.Text;
            crud.description = txtDescription.Text;
            crud.expensecode = cboExpenseCode.Text;
            crud.serial = txtSerial.Text;
            crud.supplier = cboSupplier.Text;
            crud.DateReceived = dtDateReceived.Value;
            crud.UpdateInventory();
        }
        public void DeleteInventory()
        {
            crud.invobjid = InvObjid;
            crud.DeleteInventory();
        }
        public void ReadDataInventory()
        {
            dataGridView1.DataSource = null;
            crud.ReadDataInventory();
            dataGridView1.DataSource = crud.dt;
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

            InvObjid = "INV-" + str_build.ToString() + numRandom.Next(500);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null) 
            {
                InvObjid = (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                cboCategory.Text = (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                txtxName.Text = (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                txtDescription.Text = (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                txtSerial.Text = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                cboSupplier.Text= (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                cboExpenseCode.Text = (dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                dtDateReceived.Text = (dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cboCategory.Text = "";
            txtxName.Text = "";
            txtDescription.Text = "";
            txtSerial.Text = "";
            cboExpenseCode.Text = "";
            cboExpenseCode.Text = "";
            cboSupplier.Text = "";
            dtDateReceived.Value = DateTime.Today;

        }
    }
}
