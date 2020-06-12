using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using InventoryApp.Class;
using System.Windows.Forms;

namespace InventoryApp.Class
{
    /*
    class DB
    {
        public MySqlConnection connectdb;

        public DB()
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
    */
    class CRUD :connection
    {
        //properties
        public string objid { set; get; }
        public string user { set; get; }
        public string pass { set; get; }
        public string email { set; get; }
        public string role { set; get; }

        //properties for newInventory
        public string invobjid { set; get; }
        public string name { set; get; }
        public string description { set; get; }
        public string serial { set; get; }
        public string category { set; get; }
        public string office { set; get; }
        public string assign_to { set; get; }
        public string property_no { set; get; }
        public string expensecode { set; get; }
        public bool working { set; get; }
        public DateTime DateReceived { set; get; }
        public string location { set; get; }
        public string group_id { set; get; }

        //read properties
        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();


       
        // createt function
        public void Create_data()
        {
            connectdb.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandText = "INSERT INTO `user`(`objid`,`username`,`password`,`email`,`role`)values(@objid,@user,@pass,@email,@role)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connectdb;

                    cmd.Parameters.Add("@objid", MySqlDbType.VarChar).Value = objid;
                    cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = user;
                    cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass;
                    cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("@role", MySqlDbType.VarChar).Value = role;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                
                connectdb.Close();

            }
        }

        //Update FUnction 
        public void Update_data()
        {
            connectdb.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandText = "UPDATE `user` set username=@user, password=@pass,email=@email,role=@role where objid=@objid";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connectdb;

                    cmd.Parameters.Add("@objid", MySqlDbType.VarChar).Value = objid;
                    cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = user;
                    cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass;
                    cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("@role", MySqlDbType.VarChar).Value = role;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
               
                connectdb.Close();

            }
        }

        //Delete Function
        public void Delete_data()
        {
            connectdb.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandText = "DELETE from user where objid=@objid";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connectdb;

                    cmd.Parameters.Add("@objid", MySqlDbType.VarChar).Value = objid;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                
                connectdb.Close();
                
            }
        }

        //Read Function
        public void Read_data()
        {
            dt.Clear();
            string query = "SELECT * FROM `user`";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, connectdb);
            MDA.Fill(ds);
            dt = ds.Tables[0];
        }

       
    }


}


