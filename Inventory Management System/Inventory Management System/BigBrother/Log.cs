using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_Management_System.BigBrother;
using Inventory_Management_System.Models.EmployeeData;
using Inventory_Management_System.Models.Product;



namespace Inventory_Management_System.BigBrother
{
    public class Log
    {
        enum Event {Created, Updated, Deleted};

        public Log(Employee e, Product p, string en)
        {
            this.employee = e;
            this.product = p;
            if (en == "Created")
            {
                _comment = "Product created with articlenumber: " + p.ArticleNumber1;
            }
            else if (en == "Updated")
            {
                _comment = "Product with articlenumber: " + p.ArticleNumber1 + " updated";
            }
            else if (en == "Deleted")
            {
                _comment = "Product with articlenumber: " + p.ArticleNumber1 + " was deleted"; 
            }
        }
        


        private Employee _employee;
        private Product _product;
        private string _comment;

        public Employee employee
        {
            get { return _employee; }
            set { _employee = value; }
        }

        public Product product
        {
            get { return _product; }
            set { _product = value;}
        }

        public string comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
    }
}