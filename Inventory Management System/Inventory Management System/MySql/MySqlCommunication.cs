using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Inventory_Management_System.Utils;

namespace Inventory_Management_System.MySql
{
    public static class MySqlCommunication
    {
        private static string connectionstring = "Server=localhost; Port=50309; Database=lbn_medical_db; Uid=root; Pwd=DS309e15LS;"; //fastkodning ikke en god ide
        private static MySqlConnection connection = new MySqlConnection(connectionstring);
        private static MySqlCommand cmd;


        

        public static string SendString(string text)
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

        public static string GetString(string text)
        {
            string readertext = "";
            try
            {
                connection.Open();
                cmd = connection.CreateCommand();
                cmd.CommandText = text;
                MySqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read())
                {
                    readertext = reader.GetString(0);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }

            }
            return readertext;
        }

        public static void CreateUser(string Username, string password, string role)
        {
            string text = "INSERT INTO employee_db (Username,Password,Role) VALUES('" + Username + "','" + Security.HashPassword(Username,password) + "','" + role + "')";
            SendString(text);
        }

        public static string GetHashedPassword(string Username)
        {
            string text = "SELECT Password FROM employee_db WHERE Username = '" + Username + "'";
            return GetString(text);
        }

        public static string Select(string table, string targetcollum, string keycollum, string key )
        {
            string text = "SELECT " + targetcollum + " FROM " + table + " WHERE " + keycollum + " = '" + key + "'";
            return GetString(text);
        }
            
        public static void Insert(string table, string collum, string value)
        {
            string text = "INSERT INTO " + table + " (" + collum + ") VALUES('" + value + "')";
            SendString(text);
        }

        public static void Update(string table, string targetCollum, string value, string keyCollum, string key)
        {
            string text = "UPDATE " + table + " SET " + targetCollum + "=" + value + " WHERE " + keyCollum + "=" + key;
            SendString(text);
        }

        


    }
}