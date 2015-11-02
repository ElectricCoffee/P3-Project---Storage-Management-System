using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_Management_System.Models.EmployeeData;

namespace Inventory_Management_System.Utils.LogEvent
{
    public class LogEventStatusChange : LogEntryEvent
    {
        public string OldStatus { get; private set; }
        public string NewStatus { get; private set; }

        public override string ToString()
        {
            return String.Format("{0} Old Status: {1} New Status: {2}", base.ToString(), OldStatus, NewStatus);
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