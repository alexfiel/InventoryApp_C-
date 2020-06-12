using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using InventoryApp.Class;
using System.Diagnostics.Eventing.Reader;

namespace InventoryApp.Class
{
    class accounts:connection
    {
        public string username { set; get; }
        public string userpass { set; get; }
        public string user_role { set; get; }

        public bool Validate_User()
        {
            bool check = false;
            connectdb.Open();
            MySqlDataReader rd;
            using(var cmd = new MySqlCommand())
            {
                cmd.CommandText = "Select * from `user` where username=@user and password=@pass";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                //parameters
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = userpass;

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    check = true;
                    user_role = rd.GetString("role");
                }
                connectdb.Close();
            }

            return check;
        }

    }
}
