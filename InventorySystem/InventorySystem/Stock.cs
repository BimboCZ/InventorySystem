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
 public partial class Stock : Form
 {
  public Stock()
  {
   InitializeComponent();
  }

  private void Label7_Click(object sender, EventArgs e)
  {

  }

  private void Stock_Load(object sender, EventArgs e)
  {
   this.ActiveControl = dateTimePicker1;
   comboBox1.SelectedIndex = 0;
   LoadData();
  }

  private void DateTimePicker1_KeyDown(object sender, KeyEventArgs e)
  {
   if (e.KeyCode == Keys.Enter)
   {
    textBox1.Focus();
   }
  }

  private void ComboBox1_KeyDown(object sender, KeyEventArgs e)
  {
   if (e.KeyCode == Keys.Enter)
   {
    if (comboBox1.SelectedIndex != -1)
    {
     button1.Focus();
    }
    else
    {
     comboBox1.Focus();
    }
   }
  }

  private void TextBox1_KeyDown(object sender, KeyEventArgs e)
  {
   if (e.KeyCode == Keys.Enter)
   {
    if (textBox1.Text.Length > 0)
    {
     textBox2.Focus();
    }
    else
    {
     textBox1.Focus();
    }
   }
  }

  private void TextBox2_KeyDown(object sender, KeyEventArgs e)
  {
   if (e.KeyCode == Keys.Enter)
   {
    if (textBox1.Text.Length > 0)
    {
     textBox3.Focus();
    }
    else
    {
     textBox2.Focus();
    }
   }
  }

  private void TextBox3_KeyDown(object sender, KeyEventArgs e)
  {
   if (e.KeyCode == Keys.Enter)
   {
    if (textBox1.Text.Length > 0)
    {
     comboBox1.Focus();
    }
    else
    {
     textBox3.Focus();
    }
   }
  }

  private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
  {
   if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
   {
    e.Handled = true;
   }
  }

  private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
  {
   if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
   {
    e.Handled = true;
   }
  }

  private void ResetRecords()
  {
   dateTimePicker1.Value = DateTime.Now;
   textBox1.Clear();
   textBox2.Clear();
   textBox3.Clear();
   comboBox1.SelectedIndex = -1;
   dateTimePicker1.Focus();
  }

  private void Button3_MouseClick(object sender, MouseEventArgs e)
  {
   ResetRecords();
  }

  private bool Validation()
  {
   bool result = false;
   if (string.IsNullOrEmpty(textBox1.Text))
   {
    errorProvider1.Clear();
    errorProvider1.SetError(textBox1, "Product Code is required !");
   }
   else if (string.IsNullOrEmpty(textBox2.Text))
   {
    errorProvider1.Clear();
    errorProvider1.SetError(textBox1, "Product Name is required !");
   }
   else if (string.IsNullOrEmpty(textBox3.Text))
   {
    errorProvider1.Clear();
    errorProvider1.SetError(textBox1, "Quantity is required !");
   }
   else if (comboBox1.SelectedIndex == -1)
   {
    errorProvider1.Clear();
    errorProvider1.SetError(textBox1, "Select a Status !");
   }
   else
   {
    errorProvider1.Clear();
    result = true;
   }
   return result;
  }

  private bool IfProductExists(SqlConnection con, string productCode)
  {
   SqlDataAdapter sda = new SqlDataAdapter("Select 1 from [Stock] Where [ProductCode]='" + productCode + "'", con);
   DataTable dt = new DataTable();
   sda.Fill(dt);
   if (dt.Rows.Count > 0)
    return true;
   else
    return false;
  }

  private void Button1_Click(object sender, EventArgs e)
  {
   if (Validation())
   {
    SqlConnection con = Connection.GetConnection("WebDev");
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
     sqlQuery = @"UPDATE [Stock] SET [ProductName] = '" + textBox2.Text + "' " +
      ",[Quantity] = '" + textBox3.Text + "',[ProductStatus] = '" + status + "' WHERE [ProductCode] = '" + textBox1.Text + "'";
    }
    else
    {
     sqlQuery = @"INSERT INTO Stock (ProductCode, ProductName, TransDate, Quantity, ProductStatus)
     VALUES  ('" + textBox1.Text + "'" +
     ",'" + textBox2.Text + "'" +
     ",'" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'" +
     ",'" + textBox3.Text + "','" + status + "')";
    }
    SqlCommand cmd = new SqlCommand(sqlQuery, con);
    cmd.ExecuteNonQuery();
    con.Close();
    MessageBox.Show("Record Saved Successfully");
    ResetRecords();
   }
  }

  public void LoadData()
  {
   SqlConnection con = Connection.GetConnection("WebDev");
   SqlDataAdapter sda = new SqlDataAdapter("Select * From [dbo].[Stock]", con);
   DataTable dt = new DataTable();
   sda.Fill(dt);
   dataGridView1.Rows.Clear();
   foreach (DataRow item in dt.Rows)
   {
    int n = dataGridView1.Rows.Add();
    dataGridView1.Rows[n].Cells["dgSno"].Value = n + 1;
    dataGridView1.Rows[n].Cells["dgProCode"].Value = item["ProductCode"].ToString();
    dataGridView1.Rows[n].Cells["dgProName"].Value = item["ProductName"].ToString();
    dataGridView1.Rows[n].Cells["dgQuantity"].Value = float.Parse(item["Quantity"].ToString());
    dataGridView1.Rows[n].Cells["dgDate"].Value = Convert.ToDateTime(item["TransDate"].ToString()).ToString("dd/MM/yyyy");
    if ((bool)item["ProductStatus"])
    {
     dataGridView1.Rows[n].Cells["dgStatus"].Value = "Active";
    }
    else
    {
     dataGridView1.Rows[n].Cells["dgStatus"].Value = "Deactive";
    }
   }
  }

  private void DataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
  {
   button1.Text = "Update";
   textBox1.Text = dataGridView1.SelectedRows[0].Cells["dgProCode"].Value.ToString();
   textBox2.Text = dataGridView1.SelectedRows[0].Cells["dgProName"].Value.ToString();
   textBox3.Text = dataGridView1.SelectedRows[0].Cells["dgQuantity"].Value.ToString();
   dateTimePicker1.Text = DateTime.Parse(dataGridView1.SelectedRows[0].Cells["dgDate"].Value.ToString()).ToString("dd/MM/yyyy");
   if (dataGridView1.SelectedRows[0].Cells["dgStatus"].Value.ToString() == "Active")
   {
    comboBox1.SelectedIndex = 0;
   }
   else
   {
    comboBox1.SelectedIndex = 1;
   }
  }

  private void Button2_Click(object sender, EventArgs e)
  {
   DialogResult dialogResult = MessageBox.Show("Are You Sure Want to Delete", "Message", MessageBoxButtons.YesNo);
   if (dialogResult == DialogResult.Yes)
   {
    if (Validation())
    {
     SqlConnection con = Connection.GetConnection("WebDev");
     var sqlQuery = "";
     if (IfProductExists(con, textBox1.Text))
     {
      con.Open();
      sqlQuery = @"DELETE FROM [Stock] WHERE [ProductCode] = '" + textBox1.Text + "'";
      SqlCommand cmd = new SqlCommand(sqlQuery, con);
      cmd.ExecuteNonQuery();
      con.Close();
      MessageBox.Show("Record Deleted Successfully...!");
     }
     else
     {
      MessageBox.Show("Record Not Exists...!");
     }
     LoadData();
     ResetRecords();
    }
   }
  }
 }
}
