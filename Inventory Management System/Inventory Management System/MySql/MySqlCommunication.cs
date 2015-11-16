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
        public static string ProductTable  = "product_db";
        public static string RoleTable     = "role_db";

        /// <summary>
        /// Wraps an SQL connection in a closure to allow minimal typing
        /// </summary>
        /// <param name="body"></param>
        private static void SqlConnection(Action<MySqlCommand> body)
        {
            // automatically opens and closes a connection
            using (var conn = new MySqlConnection(connectionstring))
            {
                var cmd = conn.CreateCommand();
                body(cmd); // the body of the lambda using the cmd (see use below)
            }
        }


        /// <summary>
        /// Opens a connection to the Database, and send the text string
        /// </summary>
        /// <param name="text">the string to send to the database</param>
        /// <returns>the string that was send to the database</returns>
        public static string SendString(string text)
        {
            // exposes the connection command in the lambda
            SqlConnection(cmd =>
            {
                cmd.CommandText = text;
                cmd.ExecuteNonQuery();
            });

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

            SqlConnection(cmd =>
            {
                cmd.CommandText = text;
                var reader = cmd.ExecuteReader();
                while (reader.Read()) readertext = reader.GetString(0);
            });

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
            var text = String.Format("INSERT INTO {0} (Username, Password, Role, Name, ActivationDate) VALUES('{1}','{2}','{3}', '{4}', '{5}')",
                EmployeeTable, Username, Security.HashPassword(Username, password), role, name, DateTime.Now.ToString());
            SendString(text);
        }

        /// <summary>
        /// Gets the hashed password from the database
        /// </summary>
        /// <param name="Username">the Username you wants the password from</param>
        /// <returns>the hashed password</returns>
        public static string GetHashedPassword(string Username)
        {
            string text = String.Format("SELECT Password FROM {0} WHERE Username = {1}",
                EmployeeTable, Username);
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
        public static string Select(string table, string targetColumn, string keyColumn, string key)
        {
            string text = String.Format("SELECT {0} FROM {1} WHERE {2} = {3}",
                targetColumn, table, keyColumn, key);
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
            var colStr = String.Join(",", column);
            var valStr = String.Join("','", value);
            var text = String.Format("INSERT INTO {0} ({1}) VALUES('{2}')", table, colStr, valStr);

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
            if (targetColumn.Count != value.Count) throw new NotEqualException();

            var lrSet = targetColumn.Zip(value, (lhs, rhs) => lhs + " = " + rhs);
            var resStr = String.Join(",", lrSet);

            String text = String.Format("Update {0} WHERE {1} = {2} SET {3}", table, keyColumn, key, resStr);

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
            var readerList = new List<List<string>>();

            SqlConnection(cmd =>
            {
                cmd.CommandText = text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    readerList.Add(new List<string>());
                for (int i = 0; i < columnCount; i++)
                    readerList.Last().Add(reader.GetString(i));
            });

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
            return GetList(text, numbersOfCollums);
        }

        /// <summary>
        /// Select all the data in the database
        /// </summary>
        /// <param name="table">the name of the table</param>
        /// <param name="columnCount">the numbes of collums you wants back</param>
        /// <returns></returns>
        public static List<List<string>> SelectAll(string table, int columnCount)
        {
            string text = String.Format("SELECT * FROM {0}", table);
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
            return GetList(text, 1).Select(e => e[0]).ToList();
        }
    }
}