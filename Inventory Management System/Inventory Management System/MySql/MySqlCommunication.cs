using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Inventory_Management_System.MySql
{
    public class MySqlCommunication
    {
        private string connectionstring = "Server=localhost; Port=50309; Database=lbn_medical_db; Uid=root; Pwd=DS309e15LS;"; //fastkodning ikke en god ide
        private MySqlConnection connection;
        private MySqlCommand cmd;


        public MySqlCommunication()
        {
            connection = new MySqlConnection(connectionstring);
            
        }

        public string SendString(string text)
        {
            try
            {
                connection.Open();
                cmd = connection.CreateCommand();
                cmd.CommandText = text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                if(connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                
            }
            return text;

        }
    }
}