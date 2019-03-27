using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace InventorySystem
{
 class ProductManager
 {
  public static void DeleteProduct(bool ifProductExists)
  {

   SqlConnection con = Connection.GetConnection("WebDev");
   var sqlQuery = "";
   if (ifProductExists)
   {
    con.Open();
    sqlQuery = @"DELETE FROM [Products] WHERE [ProductCode] = '@ProductCode'";

    SqlCommand cmd = new SqlCommand(sqlQuery, con);
    cmd.Parameters.Add("@ProductCode", SqlDbType.Int);
    cmd.ExecuteNonQuery();

    con.Close();
   }
   else
   {
    MessageBox.Show("Record Not Exist...!!");
   }
  }

  public static bool IfProductExists(SqlConnection con, string ProductCode)
  {
   // TODO nefunguje update
   string query = @"select 1 from [Products] WHERE [ProductCode] =  @ProductCode";
   SqlCommand com = new SqlCommand(query, con);
   com.Parameters.AddWithValue("@ProductCode", ProductCode);
   SqlDataAdapter sda = new SqlDataAdapter();
   sda.SelectCommand = com;
   DataTable dt = new DataTable();
   sda.Fill(dt);
   return dt.Rows.Count > 0;
  }

  public static bool ProductStatus(bool isActive)
  {
   return isActive;
  }

  public static void InsertUpdate(SqlConnection con, string ProductCode, string ProductName, bool isActive, bool isUpdate)
  {
   
   var sqlQuery = "";
   SqlCommand com = new SqlCommand(sqlQuery, con);
   if (isUpdate)
   {
    com.CommandText = sqlQuery = @"UPDATE [Products] SET [ProductName] = @ProductName,[ProductStatus] = @Status WHERE [ProductCode] = @ProductCode;
Select 'ahoj' as scalar";

    com.Parameters.Add("@ProductCode", SqlDbType.Int);
    com.Parameters["@ProductCode"].Value = ProductCode;
    com.Parameters.Add("@ProductName", SqlDbType.NVarChar, 50);
    com.Parameters["@ProductName"].Value = ProductName;
    com.Parameters.Add("@Status", SqlDbType.Bit);
    com.Parameters["@Status"].Value = isActive;

    com.ExecuteNonQuery();
   }
   else
   {
    com.CommandText = sqlQuery = @"INSERT INTO [dbo].[Products] ([ProductCode] ,[ProductName] ,[ProductStatus])
                             VALUES (@ProductCode,@ProductName,@Status);";

    com.Parameters.Add("@ProductCode", SqlDbType.Int);
    com.Parameters["@ProductCode"].Value = ProductCode;
    com.Parameters.Add("@ProductName", SqlDbType.NVarChar, 50);
    com.Parameters["@ProductName"].Value = ProductName;
    com.Parameters.Add("@Status", SqlDbType.Bit);
    com.Parameters["@Status"].Value = isActive;

    com.ExecuteNonQuery();
   }
  }
  //Poor version
  public static void InsertOrDelete(SqlConnection con, bool isActive, string ProductCode, string ProductName)
  {
   bool status = false;
   if (isActive)
   {
    status = true;
   }
   else
   {
    status = false;
   }
   var sqlQuery = "";
   if (ProductManager.IfProductExists(con, ProductCode))
   {
    sqlQuery = @"UPDATE [Products] SET [ProductName] = '" + ProductName + "',[ProductStatus] = '" + status +
              "' WHERE [ProductCode] = '" + ProductCode + "'";
   }
   else
   {
    sqlQuery = @"INSERT INTO [dbo].[Products] ([ProductCode] ,[ProductName] ,[ProductStatus])
                             VALUES ('" + ProductCode + "','" + ProductName + "','" + status + "');";
   }
  }
 }
}
