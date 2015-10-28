using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_Management_System.Models.EmployeeData;

namespace Inventory_Management_System.Utils.logEvent
{
    public class LogEventSold : LogEntryEvent
    {
        public string Costumer { get; private set; }
        public string Price { get; private set; }

        public override string ToString()
        {
            return base.ToString() + " Costumer: " + Costumer + " Price: " + Price;
        }

        public LogEventSold (Employee employee, DateTime time, string costumer, string price)
        {
            Employee = employee;
            Time = time;
            Costumer = costumer;
            Price = price;
        }
    }
}