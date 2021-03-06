﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem
{
    public partial class StockMain : Form
    {
        bool close = true;

        public StockMain()
        {
            InitializeComponent();
        }

        private void ProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products pro = new Products
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            pro.Show();
        }

        private void StockMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close)
            {
                DialogResult result = MessageBox.Show("Do you want to exit ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    close = false;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

  private void StockToolStripMenuItem_Click(object sender, EventArgs e)
  {
   Stock stk = new Stock();
   stk.MdiParent = this;
   stk.StartPosition = FormStartPosition.CenterScreen;
   stk.Show();
  }
 }
}
