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

        public static string InsertAddProduct(bool ifProductExists)
        {
            var sqlQuery = "";
            if (ifProductExists)
            {
                sqlQuery = @"UPDATE [Products] SET [ProductName] = '@ProductName',[ProductStatus] = '@Status' WHERE [ProductCode] = '@ProductCode'";
                SqlCommand com = new SqlCommand(sqlQuery);
                com.Parameters.Add("@ProductCode", SqlDbType.Int);
                com.Parameters.Add("@ProductName", SqlDbType.NVarChar, 50);
                com.Parameters.Add("@Status", SqlDbType.Bit);
                string queryResult = Convert.ToString(com.ExecuteScalar());
                return queryResult;
            }
            else
            {
                sqlQuery = @"INSERT INTO [dbo].[Products] ([ProductCode] ,[ProductName] ,[ProductStatus])
                             VALUES ('@ProductCode','@ProductName','@Status');";
                SqlCommand com = new SqlCommand(sqlQuery);
                com.Parameters.Add("@ProductCode", SqlDbType.Int);
                com.Parameters.Add("@ProductName", SqlDbType.NVarChar, 50);
                com.Parameters.Add("@Status", SqlDbType.Bit);
                string queryResult = Convert.ToString(com.ExecuteScalar());
                return queryResult;
            }
        }

        public static bool IfProductExists(SqlConnection Connection, string ProductCode)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select 1 from [Products] WHERE [ProductCode]='" + ProductCode + "'", Connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt.Rows.Count > 0;
        }
    }
}
