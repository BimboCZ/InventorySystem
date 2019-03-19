using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace InventorySystem
{
    public static class Connection
    {
        public static SqlConnection GetConnection(string AppConfigName)
        {
            SqlConnection con = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings[AppConfigName].ConnectionString
            };
            return con;
        }
    }
}
