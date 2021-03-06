﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using InventoryApp.Class;
using System.Windows.Forms;
using System.Security.Cryptography;

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
    class CRUD : connection
    {
        //properties
        public string objid { set; get; }
        public string user { set; get; }
        public string pass { set; get; }
        public string email { set; get; }
        public string role { set; get; }

        //properties for newInventory
        public List<string> datafill = new List<string>();
        public List<string> datafillExpense = new List<string>();
        public List<string> datafillSUpplier = new List<string>();
        public List<string> datafillSearch = new List<string>();
        public string invobjid { set; get; }
        public string prodname { set; get; }
        public string description { set; get; }
        public string propertyno { set; get; }
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
        public string supplier { set; get; }
        public string ImageUrlLocation { set; get; }

     
        public string search_list { set; get; }
        public string search_text { set; get; }


        //read properties
        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();

        #region CRUD function Inventory

        //create function for the newInventory
        public void CreateInventory()
        {
            connectdb.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    propertyno = "Null";
                    cmd.CommandText = "INSERT INTO `tagb_inventory`.`property` (`objid`, `name`, `description`, `serial`, `category`, `supplier`, `property_no`, `expensecode`, `date_received`,`imageUrl`) VALUES (@invobjid, @name, @description, @serial, @category, @supplier,@propertyno, @expensecode, @DateReceived, @imageurl)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connectdb;

                    cmd.Parameters.Add("@invobjid", MySqlDbType.VarChar).Value = invobjid;
                    cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = prodname;
                    cmd.Parameters.Add("@description", MySqlDbType.VarChar).Value = description;
                    cmd.Parameters.Add("@serial", MySqlDbType.VarChar).Value = serial;
                    cmd.Parameters.Add("@category", MySqlDbType.VarChar).Value = category;
                    cmd.Parameters.Add("@supplier", MySqlDbType.VarChar).Value = supplier;
                    cmd.Parameters.Add("@propertyno", MySqlDbType.VarChar).Value = propertyno;
                    cmd.Parameters.Add("@expensecode", MySqlDbType.VarChar).Value = expensecode;
                    cmd.Parameters.Add("@DateReceived", MySqlDbType.DateTime).Value = DateReceived;
                    cmd.Parameters.Add("@imageurl", MySqlDbType.VarChar).Value = ImageUrlLocation;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                connectdb.Close();
            }
        }

        //update function newInventory
        public void UpdateInventory()
        {
            connectdb.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandText = "Update `tagb_inventory`.`property` set name=@name, description=@description, serial=@serial, category=@category, supplier=@supplier, expensecode=@expensecode, date_received=@DateReceived, imageurl=@imageurl where objid=@invobjid";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connectdb;

                    cmd.Parameters.Add("@invobjid", MySqlDbType.VarChar).Value = invobjid;
                    cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = prodname;
                    cmd.Parameters.Add("@description", MySqlDbType.VarChar).Value = description;
                    cmd.Parameters.Add("@serial", MySqlDbType.VarChar).Value = serial;
                    cmd.Parameters.Add("@category", MySqlDbType.VarChar).Value = category;
                    cmd.Parameters.Add("@supplier", MySqlDbType.VarChar).Value = supplier;
                    cmd.Parameters.Add("@expensecode", MySqlDbType.VarChar).Value = expensecode;
                    cmd.Parameters.Add("@DateReceived", MySqlDbType.DateTime).Value = DateReceived;
                    cmd.Parameters.Add("@imageurl", MySqlDbType.VarChar).Value = ImageUrlLocation;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                connectdb.Close();
            }
        }
        //delete function newInventory
        public void DeleteInventory()
        {
            connectdb.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandText = "DELETE from `tagb_inventory`.`property` where objid=@invobjid";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connectdb;

                    cmd.Parameters.Add("@invobjid", MySqlDbType.VarChar).Value = invobjid;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

                connectdb.Close();
            }
        }


        #endregion

        #region CRUD function User
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
        public void ShowCategory()
        {
            datafill.Clear();
            MySqlDataReader rd;

            string query = "Select * from category";
            using (var cmd = new MySqlCommand())
            {
                connectdb.Open();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    datafill.Add(rd[1].ToString());

                }
                connectdb.Close();
            }

        }
        public void ShowExpenseCode()
        {
            datafillExpense.Clear();
            MySqlDataReader rd;

            string query = "Select * from expensecode";
            using (var cmd = new MySqlCommand())
            {
                connectdb.Open();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    datafillExpense.Add(rd[1].ToString());

                }
                connectdb.Close();
            }

        }
        public void ShowSupplier()
        {
            datafillSUpplier.Clear();
            MySqlDataReader rd;

            string query = "Select * from supplier";
            using (var cmd = new MySqlCommand())
            {
                connectdb.Open();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    datafillSUpplier.Add(rd[1].ToString());

                }
                connectdb.Close();
            }

        }
        #endregion

        //Read Function
        public void Read_data()
        {
            dt.Clear();
            string query = "SELECT * FROM `user`";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, connectdb);
            MDA.Fill(ds);
            dt = ds.Tables[0];
        }

        public void ReadDataInventory()
        {
            dt.Clear();
            string query = "Select objid,name,description,serial,category,supplier,expensecode,date_received, imageurl from  `tagb_inventory`.`property`";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, connectdb);
            MDA.Fill(ds);
            dt = ds.Tables[0];
        }

        public void LOAD_LISTBOX() //load in the searchListbox
        {
            datafill.Clear();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                connectdb.Open();
                cmd.CommandText = "Select objid,name,description,serial,category,supplier,expensecode,date_received, imageurl from  `tagb_inventory`.`property` where name like '%" + search_list + "%'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                try 
                {
                    rd = cmd.ExecuteReader();
                    while (rd.Read()) 
                    {
                        datafill.Add(rd[1].ToString());
                    }
                    connectdb.Close();
                }
                catch
                {

                }
            }
        }
        
        public void Search_Table()
        {
            string query_filter = "Select objid,name,description,serial,category,supplier,expensecode,date_received, imageurl from  `tagb_inventory`.`property` where name ='"+  search_list + "'";
            dt.Clear();
            MySqlDataAdapter MDA = new MySqlDataAdapter(query_filter, connectdb);
            MDA.Fill(ds);
            dt = ds.Tables[0];
        }

       
    }


}


