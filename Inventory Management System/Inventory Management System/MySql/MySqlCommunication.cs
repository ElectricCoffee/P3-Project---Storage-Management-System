using Inventory_Management_System.Utils;
using Inventory_Management_System.Utils.Exceptions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using Inventory_Management_System.Models.Product;
using System.Diagnostics;
using Inventory_Management_System.Models.EmployeeData;
using Inventory_Management_System.BigBrother;

namespace Inventory_Management_System.MySql
{
    public static class MySqlCommunication
    {
        private static string connectionstring = "Server=localhost; Port=4000; Database=lbn_medical_db; Uid=root; Pwd=DS309e15LS;"; //fastkodning ikke en god ide
        //private static MySqlConnection connection = new MySqlConnection(connectionstring);
        //private static MySqlCommand cmd;
        public static string EmployeeTable = "employee_db";
        public static string ProductTable = "product_db";
        public static string RoleTable = "role_db";
        public static string LogTable = "log_table";

        /// <summary>
        /// Wraps an SQL connection in a closure to allow minimal typing
        /// </summary>
        /// <param name="body"></param>
        private static void SqlConnection(Action<MySqlCommand> body)
        {
            var conn = new MySqlConnection(connectionstring);
            conn.Open();
            Debug.WriteLine(conn.State);

            var cmd = conn.CreateCommand();
            body(cmd); // the body of the lambda using the cmd (see use below)
            conn.Close();
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
                try
                {
                    cmd.CommandText = text;
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    Debug.WriteLine("Det Virker");
                }
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
            var text = String.Format("INSERT INTO {0} (UserName, Password, Role, Name, ActivationDate) VALUES('{1}','{2}','{3}', '{4}', '{5}')",
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
            string text = String.Format("SELECT Password FROM {0} WHERE UserName = '{1}'",
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
            string text = String.Format("SELECT {0} FROM {1} WHERE {2} = '{3}'",
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

            var lrSet = targetColumn.Zip(value, (lhs, rhs) => lhs + " = '" + rhs + "'");
            var resStr = String.Join(",", lrSet);

            String text = String.Format("UPDATE {0} SET {1} WHERE {2} = '{3}'", table, resStr, keyColumn, key);

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
                {
                    readerList.Add(new List<string>());
                    for (int i = 0; i < columnCount; i++)
                    {
                        readerList.Last().Add(reader.GetString(i));
                    }
                }
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
            string text = "SELECT * FROM " + table + " WHERE " + keyColumn + " = '" + key + "'";
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
            string text = "DELETE FROM " + table + " WHERE " + keyColumn + " = '" + key + "'";
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

        public static List<PSystem> GetAllProduct()
        {
            var ProductList = new List<PSystem>();
            List<List<string>> DbList = SelectAll(ProductTable, 19);
            foreach (List<string> item in DbList)
            {
                ProductList.Add(new PSystem(
                    new Id()
                    {
                        ArticleNumber1 = item[0],
                        Name = item[1],
                        //ArticleNumber2 = item[?]
                        SerialNumber = item[2],
                        Model = item[13],
                        ProductionYear = Convert.ToInt32(item[14]),
                        Tags = item[10],
                        Category = item[11],
                        Acquisitor = item[15]

                    },
                    new Location()
                    {
                        WorldLocation = item[3],
                        InventoryLocation = item[4],
                        Amount = Convert.ToInt32(item[6]),
                        Transit = item[5]
                    },
                    new Price()
                    {
                        AcquisitionPrice = Convert.ToInt32(item[7]),
                        SalesPrice = item[18]
                    },
                    new Status()
                    {
                        InventoryStatus = item[8],
                        SalesStatus = item[9]
                    },
                    new Directories()
                    {
                        ////documentDirectory = item[],
                        //documentName = item[],
                        //specsheetDirectory = item[],
                        //specsheetName = item[],
                        //imageDirectory = item[],
                        //imageName = item[]
                    }
                    ));
            }

            return ProductList;
        }

        //ArticleNumber1 = q.ArticleNumber1;
        //    Name = q.Name;
        //    SerialNumber = q.SerialNumber;
        //    Amount = q.Amount;
        //    AcquisitionPrice = q.AcquisitionPrice;
        //    Model = q.model;
        //    Category = q.Category;
        //    Tags = q.Tags;
        //    Comment = q.comments;

        public static void Create(PSystem data)
        {
            Debug.WriteLine("Mysql comm create functon + " + data.ArticleNumber1);
            List<string> col = GetColumnName(ProductTable);
            List<string> val = new List<string>
            {
                  data.ArticleNumber1
                , data.Name
                , data.SerialNumber
                , data.WorldLocation
                , data.InventoryLocation
                , data.Transit
                , data.Amount.ToString()
                , data.AcquisitionPrice.ToString()
                , data.InventoryStatus
                , data.SalesStatus
                , data.Tags
                , data.Category
                , "" //image
                , data.Model
                , data.ProductionYear.ToString()
                , data.Acquisitor
                , "" //Specsheet
                , "" //documents
                , data.SalesPrice.ToString()
            };
            SQLLogWriter.tempCreateProductLog(data);
            Insert(ProductTable, col, val);
        }

        public static void Update(PSystem data)
        {
            List<string> col = GetColumnName(ProductTable);
            List<string> val = new List<string>
            {
                  data.ArticleNumber1
                , data.Name
                , data.SerialNumber
                , data.WorldLocation
                , data.InventoryLocation
                , data.Transit
                , data.Amount.ToString()
                , data.AcquisitionPrice.ToString()
                , data.InventoryStatus 
                , data.SalesStatus 
                , data.Tags
                , data.Category
                , "" //image
                , data.Model 
                , data.ProductionYear.ToString() 
                , data.Acquisitor
                , "" //Specsheet
                , "" //documents
                , data.SalesPrice
            };
            SQLLogWriter.tempUpdateProductLog(data);
            Update(ProductTable, col, val, "ArticleNumber", data.ArticleNumber1);
        }

        public static void Delete(string ArticleNumber)
        {
            SQLLogWriter.tempdeleteProductLog(ArticleNumber);
            Delete(ProductTable, "ArticleNumber", ArticleNumber);
        }

        public static PSystem Read(string articleNumber)
        {
            List<string> item = GetList("SELECT * FROM " + ProductTable + " WHERE ArticleNumber = '" + articleNumber + "'", GetColumnName(ProductTable).Count())[0];
            return new PSystem(
                new Id()
                    {
                        ArticleNumber1 = item[0],
                        Name = item[1],
                        //ArticleNumber2 = item[?]
                        SerialNumber = item[2],
                        Model = item[13],
                        ProductionYear = Convert.ToInt32(item[14]),
                        Tags = item[10],
                        Category = item[11],
                        Acquisitor = item[15]

                    },
                    new Location()
                    {
                        WorldLocation = item[3],
                        InventoryLocation = item[4],
                        Amount = Convert.ToInt32(item[6]),
                        Transit = item[5]
                    },
                    new Price()
                    {
                        AcquisitionPrice = Convert.ToInt32(item[7]),
                        SalesPrice = item[18]
                    },
                    new Status()
                    {
                        InventoryStatus = item[8],
                        SalesStatus = item[9]
                    },
                    new Directories()
                    {
                        ////documentDirectory = item[],
                        //documentName = item[],
                        //specsheetDirectory = item[],
                        //specsheetName = item[],
                        //imageDirectory = item[],
                        //imageName = item[]
                    }
            );
        }

        public static void CreateLog(Log e)
        {
            Insert(LogTable, new List<string> { "employee", "comment", "date" }, new List<string> { e.employee.Username, e.comment, DateTime.Now.ToString() });
        }

        public static List<LognLoad> GetAllLogs()
        {
            //return GetList("SELECT * FROM log_table", 4);
            var loglist = new List<LognLoad>();
            List<List<string>> dblist = SelectAll(LogTable, 4);
            foreach (List<string> item in dblist)
            {
                loglist.Add(new LognLoad(item[1], item[2], item[3]));
            };
            return loglist;
        }
    }
}
