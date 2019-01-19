﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TODO Check if valid login
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=InventorySystem;Integrated Security=True");
            // Insert Logic
            con.Open();
            bool status = false;
            if (comboBox1.SelectedIndex == 0)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            var sqlQuery = "";
            if (IfProductExists(con, textBox1.Text))
            {
                sqlQuery = @"UPDATE [Products] SET [ProductName] = '" + textBox2.Text + "',[ProductStatus] = '" + status +
                          "' WHERE [ProductCode] = '" + textBox1.Text + "'";
            }
            else
            {
                sqlQuery = @"INSERT INTO [dbo].[Products] ([ProductCode] ,[ProductName] ,[ProductStatus])
                             VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + status + "');";
            }

            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.ExecuteNonQuery();
            con.Close();

            //Reading Data
            LoadData();
        }

        private bool IfProductExists(SqlConnection Connection, string ProductCode)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select 1 from [Products] WHERE [ProductCode]='" + ProductCode + "'", Connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }else
            {
                return false;
            }
        }

        public void LoadData()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=InventorySystem;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select * from [dbo].[Products]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow items in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = items["ProductCode"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = items["ProductName"].ToString();
                if ((bool)items["ProductStatus"])
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Active";
                }
                else
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Inactive";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=InventorySystem;Integrated Security=True");
            var sqlQuery = "";
            if (IfProductExists(con, textBox1.Text))
            {
                con.Open();
                sqlQuery = @"DELETE FROM [Products] WHERE [ProductCode] = '" + textBox1.Text + "'";

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                MessageBox.Show("Record Not Exist...!!");
            }

            //Reading Data
            LoadData();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells[2].Value.ToString() == "Active")
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 1;
            }
        }
    }
}
