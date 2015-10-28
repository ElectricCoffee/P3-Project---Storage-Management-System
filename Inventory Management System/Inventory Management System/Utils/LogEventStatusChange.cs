using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_Management_System.Models.EmployeeData;

namespace Inventory_Management_System.Utils
{
    public class LogEventStatusChange : LogEvent
    {
        public string OldStatus { get; private set; }
        public string NewStatus { get; private set; }

        public override string ToString()
        {
            return "Employee: " + Employee + " Time: " + Time + " Old Status: " + OldStatus + " New Status: " + NewStatus;
        }

        public LogEventStatusChange(Employee employee, DateTime time, string oldStatus, string newStatus)
        {
            Employee = employee;
            Time = time;
            OldStatus = oldStatus;
            NewStatus = newStatus;
        }
    }
}