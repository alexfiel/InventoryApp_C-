﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp
{
    public partial class MainPanel : Form
    {
        public MainPanel()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewInventory frmNewInv = new NewInventory() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, AutoScroll=true, AutoSize=true   };
            this.ContentPanel.Controls.Add(frmNewInv);
            frmNewInv.Show();
        }
    }
}
