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

        public static string InsertAddProduct(bool ifProductExists,string productCode,string productName,bool status)
        {
            var sqlQuery = "";
            string queryResult = "";
            SqlConnection con = Connection.GetConnection("WebDev");
            if (ifProductExists)
            {
                sqlQuery = @"UPDATE [Products] SET [ProductName] = '@ProductName',[ProductStatus] = '@Status' WHERE [ProductCode] = '@ProductCode';
Select 'ahoj' as scalar";
                SqlCommand com = new SqlCommand(sqlQuery, con);

                com.Parameters.Add("@ProductCode", SqlDbType.Int);
                com.Parameters["@ProductCode"].Value = productCode;
                com.Parameters.Add("@ProductName", SqlDbType.NVarChar, 50);
                com.Parameters["@ProductName"].Value = productName;
                com.Parameters.Add("@Status", SqlDbType.Bit);
                com.Parameters["@Status"].Value = status;

                con.Open();
                queryResult = (string)com.ExecuteScalar();
                con.Close();
                return queryResult;
            }
            else
            {
                sqlQuery = @"INSERT INTO [dbo].[Products] ([ProductCode] ,[ProductName] ,[ProductStatus])
                             VALUES (@ProductCode,@ProductName,@Status);";
                SqlCommand com = new SqlCommand(sqlQuery, con);
                com.Parameters.Add("@ProductCode", SqlDbType.Int);
                com.Parameters["@ProductCode"].Value = productCode;
                com.Parameters.Add("@ProductName", SqlDbType.NVarChar, 50);
                com.Parameters["@ProductName"].Value = productName;
                com.Parameters.Add("@Status", SqlDbType.Bit);
                com.Parameters["@Status"].Value = status;
                con.Open();
                queryResult = (string)com.ExecuteScalar();
                con.Close();
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

        public static bool ProductStatus(bool isActive)
        {
            return isActive;
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
