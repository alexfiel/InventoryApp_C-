using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private string ImageUrlOrigin;
        public NewInventory()
        {
            InitializeComponent();
           
        }

        private void NewInventory_Load(object sender, EventArgs e)
        {
            lsbSearch.Visible = false;
            // ReadDataInventory();
            LoadSearchTables();
            crud.ShowCategory();
            crud.ShowExpenseCode();
            crud.ShowSupplier();
            cboCategory.DataSource = crud.datafill;
            cboExpenseCode.DataSource = crud.datafillExpense;
            cboSupplier.DataSource = crud.datafillSUpplier;
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
           // crud.ImageUrlLocation = pbProdImage.ImageLocation;
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
           // crud.ImageUrlLocation = pbProdImage.ImageLocation;
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
                string imageloc = (dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
            
                    
               pbProdImage.BackgroundImage = new Bitmap(imageloc);
               
                
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
            pbProdImage.BackgroundImage = null;
            dtDateReceived.Value = DateTime.Today;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            RandomCharacter();
            CreateNewInventory();
            ReadDataInventory();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateInventory();
            ReadDataInventory();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteInventory();
            ReadDataInventory();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadSearchTables()
        {
            dataGridView1.DataSource = null;
            crud.ReadDataInventory();
            dataGridView1.DataSource = crud.dt;
        }
        private void ShowListbox()
        {
            lsbSearch.DataSource = null;
            crud.search_list = txtSearch.Text;
            crud.LOAD_LISTBOX();

            lsbSearch.DataSource = crud.datafill;
            lsbSearch.Visible = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text == "")
            {
                lsbSearch.ClearSelected();

            }
            else
            {
                lsbSearch.ClearSelected();
                ShowListbox();
            }
        }

        private void txtSearch_MouseDown(object sender, MouseEventArgs e)
        {
            lsbSearch.DataSource = null;
            lsbSearch.ClearSelected();
            txtSearch.Text = "";
        }

        private void lsbSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.Text = lsbSearch.SelectedItem.ToString();
            lsbSearch.ClearSelected();
            lsbSearch.Visible = false;
            lsbSearch.DataSource = null;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text == "") 
            {
                ReadDataInventory();
            }
            else 
            {
                dataGridView1.DataSource = null;
                crud.search_text = txtSearch.Text;
                crud.Search_Table();
                dataGridView1.DataSource = crud.dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "C:\\";
            open.Filter = "Image Files (*.jpg)|*.jpg|All Files(*.*)|*.*";
            open.FilterIndex = 1;
            
            if(open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if(open.CheckFileExists)
                {
                    string paths = Application.StartupPath.Substring(0,(Application.StartupPath.Length - 10));
                    string CorrectFilename = System.IO.Path.GetFileName(open.FileName);
                    //System.IO.File.Copy(open.FileName, paths + "\\Images\\" + CorrectFilename);
                    ImageUrlOrigin = open.FileName;
                    System.IO.File.Copy(ImageUrlOrigin, paths + "\\Images\\" + CorrectFilename);
                    MessageBox.Show(ImageUrlOrigin);
                    //System.IO.File.Copy(open.FileName, )
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.png; *.bmp)|*.jpg; *.jpeg; *.gif; *.png; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display to picturebox
                //pbProdImage.BackgroundImage = new Bitmap(open.FileName);
                string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                string CorrectFilename = System.IO.Path.GetFileName(open.FileName);
                string ImageUrlLocation = null;
                //System.IO.File.Copy(open.FileName, paths + "\\Images\\" + CorrectFilename);
                ImageUrlOrigin = open.FileName;
                System.IO.File.Copy(ImageUrlOrigin, paths + "\\Images\\" + CorrectFilename,true);
                pbProdImage.BackgroundImage = new Bitmap(paths +"\\Images\\" + CorrectFilename);
                ImageUrlLocation = paths + "\\Images\\" + CorrectFilename;
                crud.ImageUrlLocation = ImageUrlLocation;

                MessageBox.Show(ImageUrlLocation);
                //System.IO.File.Copy(open.FileName, 

            }
        }

    
    }
}
