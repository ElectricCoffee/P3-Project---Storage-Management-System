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


        public static void CreateProductLog(Employee e, Product p)
        {
            string tempstr = "Product created with articlenumber: " + p.ArticleNumber1;
            MySqlCommunication.CreateLog(e, tempstr);
        }
        public static void CreateUserLog(Employee e, Employee newEmp)
        {
            string tempstr = "User created with username: " + newEmp.Username;
            MySqlCommunication.CreateLog(e, tempstr);
        }
        public static void tempCreateProductLog(Product p)
        {
            string temp = "temp. untill login has been implemented";
            var e = new Accountant(temp,temp,temp,temp);
            string tempstr = "Product created with articlenumber: " + p.ArticleNumber1;
            MySqlCommunication.CreateLog(e, tempstr);
        }

        public static void tempCreateUserLog(Employee newEmp)
        {
            string temp = "temp. untill login has been implemented";
            var e = new Accountant(temp, temp, temp, temp);
            string tempstr = "User created with username: " + newEmp.Username;
            MySqlCommunication.CreateLog(e, tempstr);
        }


        public static void tempUpdateProductLog(Product p)
        {
            string temp = "temp. untill login has been implemented";
            var e = new Accountant(temp, temp, temp, temp);
            string tempstr = "Product with articlenumber: " + p.ArticleNumber1 + " updated";
            MySqlCommunication.CreateLog(e, tempstr);
        }

        public static void tempdeleteProductLog(string articlenumber)
        {
            string temp = "temp. untill login has been implemented";
            var e = new Accountant(temp, temp, temp, temp);
            string tempstr = "Product with articlenumber: " + articlenumber + " was deleted";
            MySqlCommunication.CreateLog(e, tempstr);
        }

    }
}