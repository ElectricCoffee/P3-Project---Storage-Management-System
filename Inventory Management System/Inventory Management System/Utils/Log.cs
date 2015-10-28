using Inventory_Management_System.Models.Product;
using Inventory_Management_System.Models.EmployeeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Utils
{
    public class Log
    {
        public Log(Product product,Employee employee,/* LogEvent event,*/ string comment)
        {
            try
            {
                LogId = Guid.CreateString();
            }
            catch (ApplicationException)
            {

                throw;
            }
            LogId = 
            Time = DateTime.Now;
            ProductId = product.ArticleNumber1;
            Employe = employee.ToString();
            Comment = comment;
        }

        public string LogId { get; private set;}
        public DateTime Time { get; private set; }
        public string Employe { get; set;}
        public int ProductId { get; set;}
        public string Comment { get; set;}

    }
}