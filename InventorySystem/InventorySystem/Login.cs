﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Clear_Button(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox1.Focus();
        }

        private void Login_Button(object sender, EventArgs e)
        {
            SqlConnection con = Connection.GetConnection("WebDev");
            // pozadat ucitele o opravu
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT *
                FROM[dbo].[Login] Where UserName = '" + textBox1.Text + "' and Password = '" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                this.Hide();
                StockMain main = new StockMain();
                main.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password... or both !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clear_Button(sender, e);
            }
        }
    }
}
