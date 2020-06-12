using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace InventoryApp.Class
{
    class connection
    {
        public MySqlConnection connectdb;
        public connection()
        {
            string host = "localhost";
            string db = "tagb_inventory";
            string port = "3306";
            string user = "admin_alex";
            string pass = "pass123";
            string constring = "datasource=" + host + ";database=" + db + ";port=" + port + ";username=" + user + ";password=" + pass + "; SslMode=none";
            connectdb = new MySqlConnection(constring);

          
        }
    }
}
