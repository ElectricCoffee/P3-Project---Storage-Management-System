using Inventory_Management_System.Models.Product;
using Inventory_Management_System.Models.EmployeeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace Inventory_Management_System.Utils
{
    public class LogEntry
    {
        public LogEntry(Product product,Employee employee, LogEntryEvent logevent, string comment)
        {
            LogId = Security.TryCreate<ApplicationException, string>(10, Guid.CreateString, x => Debug.WriteLine(x.Message));
            Time = DateTime.Now;
            ProductId = product.ArticleNumber1;
            Employe = employee.ToString();
            Event = logevent;
            Comment = comment;
        }

        public string LogId { get; private set;}
        public DateTime Time { get; private set; }
        public string Employe { get; set;}
        public int ProductId { get; set;}
        public LogEntryEvent Event { get; set; }
        public string Comment { get; set;}

    }
}