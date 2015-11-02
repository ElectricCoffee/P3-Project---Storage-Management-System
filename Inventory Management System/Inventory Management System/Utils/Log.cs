using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using Inventory_Management_System.Models.EmployeeData;
using Inventory_Management_System.Models.Product;

namespace Inventory_Management_System.Utils
{
    public class Log
    {
        /// <summary>
        /// instanciation of a dictionary for further methods
        /// </summary>
        public Dictionary<string, LogEntry> LogDic;

        /// <summary>
        /// creates method for adding entries to log.
        /// </summary>
        public void AddLog(Product product, Employee employee, LogEntryEvent logevent, string comment)
        {
            LogEntry logEntry = new LogEntry(product, employee, logevent, comment);
            LogDic.Add(logEntry.LogId,logEntry);
        }
    }
}