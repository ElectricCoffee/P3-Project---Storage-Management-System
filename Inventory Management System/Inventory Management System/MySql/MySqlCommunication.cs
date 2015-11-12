using Inventory_Management_System.Utils;
using Inventory_Management_System.Utils.Exceptions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory_Management_System.MySql
{
    public static class MySqlCommunication
    {
        private static string connectionstring = "Server=localhost; Port=50309; Database=lbn_medical_db; Uid=root; Pwd=DS309e15LS;"; //fastkodning ikke en god ide
        private static MySqlConnection connection = new MySqlConnection(connectionstring);
        private static MySqlCommand cmd;
        public static string EmployeeTable = "employee_db";
        public static string ProductTable = "product_db";
        public static string RoleTable = "role_db";

        /// <summary>
        /// Opens a connection to the Database, and send the text string
        /// </summary>
        /// <param name="text">the string to send to the database</param>
        /// <returns>the string that was send to the database</returns>
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
#warning throw something
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

        /// <summary>
        /// Gets a string back from the database by sending the text
        /// </summary>
        /// <param name="text">the text thats get send to the database</param>
        /// <returns>The return string from the database.</returns>
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
#warning needs to throw something
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

        /// <summary>
        /// Creats a user in the database
        /// </summary>
        /// <param name="Username">The Username</param>
        /// <param name="password">The password, not hashed</param>
        /// <param name="role">The role</param>
        /// <param name="name">The Name</param>
        public static void CreateUser(string Username, string password, string role, string name)
        {
            string text = "INSERT INTO " + EmployeeTable + " (Username,Password,Role, Name, ActivationDate) VALUES('" + Username + "','" + Security.HashPassword(Username, password) + "','" + role + "', '" + name + "', '" + DateTime.Now.ToString() + "')";
            SendString(text);
        }

        /// <summary>
        /// Gets the hashed password from the database
        /// </summary>
        /// <param name="Username">the Username you wants the password from</param>
        /// <returns>the hashed password</returns>
        public static string GetHashedPassword(string Username)
        {
            string text = "SELECT Password FROM " + EmployeeTable + " WHERE Username = '" + Username + "'";
            return GetString(text);
        }

        /// <summary>
        /// Select a singel collum, where keycollum = key
        /// </summary>
        /// <param name="table">the name of the table</param>
        /// <param name="targetColumn">The collum you wants data from</param>
        /// <param name="keyColumn">the collum you know</param>
        /// <param name="key">the value you know</param>
        /// <returns>Data from the database</returns>
        public static string Select(string table, string targetColumn, string keyColumn, string key )
        {
            string text = "SELECT " + targetColumn + " FROM " + table + " WHERE " + keyColumn + " = '" + key + "'";
            return GetString(text);
        }
           
        /// <summary>
        /// Inserts alle the data in alle the collum in the speciafic table
        /// </summary>
        /// <param name="table">the name of the table</param>
        /// <param name="column">a list of collums</param>
        /// <param name="value">a list of values</param>
        public static void Insert(string table, List<string> column, List<string> value)
        {
            string text = "INSERT INTO " + table + "(";
            for (int i = 0; i < column.Count(); i++)
            {
                text += column[i];

                if (i != column.Count() -1)
                {
                    text += ",";
                }
            }
            text += ") VALUES('";
            for (int i = 0; i < value.Count(); i++)
            {
                text += "'" + value[i] + "'";
                if (i != value.Count()-1)
                {
                    text += ",";
                }
            }
            text +="')";
            SendString(text);
        }

        /// <summary>
        /// Update a line in the database
        /// </summary>
        /// <param name="table">the name of the table</param>
        /// <param name="targetColumn">a list of collums you want to update values</param>
        /// <param name="value">a list of values you ants to update</param>
        /// <param name="keyColumn">the collums you know</param>
        /// <param name="key">the value you know</param>
        public static void Update(string table, List<string> targetColumn, List<string> value, string keyColumn, string key)
        {
            if(targetColumn.Count != value.Count())
            {
                throw new NotEqualException();
            }

            string text = "UPDATE " + table + " WHERE " + keyColumn + " = " + key + " SET ";
            for (int i = 0; i < value.Count(); i++)
            {
                text += targetColumn[i] + " = " + value[i];

                if(value.Count()-1 != i)
                {
                    text += ", ";
                }
            }
            SendString(text);
        }

        /// <summary>
        /// Gets a list of list of data from the database
        /// </summary>
        /// <param name="text">the text to send to the database</param>
        /// <param name="columnCount">the number of collums you want back</param>
        /// <returns>a list of list of data</returns>
        public static List<List<string>> GetList(string text, int columnCount)
        {
            List<List<string>> readerList = new List<List<string>>();
            try
            {
                connection.Open();
                cmd = connection.CreateCommand();
                cmd.CommandText = text;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < columnCount; i++)
                    {
                        readerList.Add(new List<string>());
                        readerList.Last().Add(reader.GetString(i));
                    }
                }
            }
            catch (Exception)
            {
#warning throw something, man
                throw; 
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return readerList;
        }
        

        /// <summary>
        /// Filter a list
        /// </summary>
        /// <param name="table">the name of the table</param>
        /// <param name="keyColumn">the know collum</param>
        /// <param name="key">the known value</param>
        /// <param name="numbersOfCollums">numbers of collums you want back</param>
        /// <returns></returns>
        public static List<List<string>> FilterList(string table, string keyColumn, string key, int numbersOfCollums)
        {
            string text = "SELECT * FROM " + table + "WHERE " + keyColumn + " = " + key;
            return GetList(text,numbersOfCollums);
        }

        /// <summary>
        /// Select all the data in the database
        /// </summary>
        /// <param name="table">the name of the table</param>
        /// <param name="columnCount">the numbes of collums you wants back</param>
        /// <returns></returns>
        public static List<List<string>> SelectAll(string table, int columnCount)
        {
            string text = "SELECT * FROM " + table;
            return GetList(text, columnCount);
        }

        /// <summary>
        /// Delete a row in the database
        /// </summary>
        /// <param name="table">the table where the row is</param>
        /// <param name="keyColumn"> the known collum</param>
        /// <param name="key">the known value</param>
        public static void Delete(string table, string keyColumn, string key)
        {
            string text = "DELETE FROM " + table + " WHERE " + keyColumn + " = " + key;
            SendString(text);
        }


        /// <summary>
        /// Get Coolumn Names
        /// </summary>
        /// <param name="table">the tabel you want names from</param>
        /// <returns></returns>
        public static List<string> GetColumnName(string table)
        {
            string text = "SHOW Columns FROM " + table;

            List<List<string>> columns = GetList(text, 1);
            List<string> ColumnNames = new List<string>();
            for (int i = 0; i < columns.Count(); i++)
            {
                ColumnNames.Add(columns[i][0]);
            }

            return ColumnNames;

        }
    }
}