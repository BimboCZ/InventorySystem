using System;
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
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Products]
           ([ProductCode]
           ,[ProductName]
           ,[ProductStatus])
     VALUES
           ('" + textBox1.Text + "','" + textBox2.Text + "','" + status + "');", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
