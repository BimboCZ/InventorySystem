using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace InventorySystem
{
    class DA_adapter
    {
        public static string GetProduct(Int32 id)
        {

            SqlConnection con = Connection.GetConnection("WebDev");
            con.Open();

            //Příkaz
            SqlCommand command;
            command = new SqlCommand("SELECT ProductName FROM products WHERE id=@id", con);

            //Přidání parametru přes hodnotu
            command.Parameters.AddWithValue("@id", id);

            //Přidání parametru přes datový typ
            command.Parameters.Add("@type", SqlDbType.SmallInt);
            command.Parameters["@type"].Value = 2;

            //Vyvolání příkazu
            string returnValue = Convert.ToString(command.ExecuteScalar());

            return returnValue;
        }

        public static DataTable GetTable()
        {
            //Vytvořím si lokální tabulku
            DataTable localTable = new DataTable();

            try
            {
                SqlConnection con = Connection.GetConnection("WebDev");
                con.Open();

                //Vytvořím si data adapter
                SqlDataAdapter da = new SqlDataAdapter();

                //Přidám příkaz select do data adaptéru
                SqlCommand prikazSelect;
                prikazSelect = new SqlCommand("SELECT ProductCode,ProductName,ProductStatus FROM products", con);

                da.SelectCommand = prikazSelect;

                //Pomocí data adapteru  naplníme lokální tabulku
                da.Fill(localTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return localTable;

        }
    }
}
