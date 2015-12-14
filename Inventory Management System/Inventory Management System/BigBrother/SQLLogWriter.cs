using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_Management_System.MySql;
using Inventory_Management_System.Models.EmployeeData;
using Inventory_Management_System.Models.Product;

namespace Inventory_Management_System.BigBrother
{
    public static class SQLLogWriter
    {
        public static string temp = "temp";

        public static void CreateProductLog(Employee e, Product p)
        {
            var log = new Log(e, p, "Created");
            MySqlCommunication.CreateLog(log);
        }
        public static void CreateUserLog(Employee e, Employee newEmp)
        {
            //string tempstr = "User created with username: " + newEmp.Username;
            //MySqlCommunication.CreateLog(e, tempstr);
        }

        public static void tempCreateProductLog(Product p)
        {
            var e = new Accountant(temp, temp, temp, temp);
            var log = new Log(e,p,"Created");
            MySqlCommunication.CreateLog(log);
        }

        public static void tempCreateUserLog(Employee newEmp)
        {
            //var e = new Accountant(temp, temp, temp, temp);
            //string tempstr = "User created with username: " + newEmp.Username;
            //MySqlCommunication.CreateLog(e, tempstr);
        }


        public static void tempUpdateProductLog(Product p)
        {
            var e = new Accountant(temp, temp, temp, temp);
            var log = new Log(e, p, "Updated");
            MySqlCommunication.CreateLog(log);
        }

        public static void tempdeleteProductLog(string articlenumber)
        {
            var e = new Accountant(temp, temp, temp, temp);
            var p = new Product();
            p.ArticleNumber1 = articlenumber;
            var log = new Log(e, p, "Deleted");
            MySqlCommunication.CreateLog(log);
        }

    }
}