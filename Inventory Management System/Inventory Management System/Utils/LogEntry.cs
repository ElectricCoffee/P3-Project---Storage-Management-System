﻿using Inventory_Management_System.Models.Product;
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
        /// <summary>
        /// instanciation of a dictionary for further methods
        /// </summary>
       

        public LogEntry(Product product,Employee employee, LogEntryEvent logevent, string comment)
        {
            /// <summary>
            /// LogID calls a generic try/catch method from security on the Generalized user ID method.
            /// </summary>
            LogId = Security.TryCreate<ApplicationException, string>(10, Guid.CreateString, x => Debug.WriteLine(x.Message));
            Time = DateTime.Now;
            ProductId = product.ArticleNumber1;
            Employee = employee.Username;
            Event = logevent;
            Comment = comment;
        }

        /// <summary>
        /// instanciating properties
        /// </summary>
        public string LogId { get; private set;}
        public DateTime Time { get; private set; }
        public string Employee { get; set;}
        public int ProductId { get; set;}
        public LogEntryEvent Event { get; set; }
        public string Comment { get; set;}

       

    }
}