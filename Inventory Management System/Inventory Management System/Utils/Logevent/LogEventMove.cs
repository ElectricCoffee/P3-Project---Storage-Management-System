using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_Management_System.Models.EmployeeData;

namespace Inventory_Management_System.Utils.LogEvent
{
    public class LogEventMove : LogEntryEvent
    {
        public string OldLocation { get; private set; }
        public string NewLocation { get; private set; }

        public override string ToString()
        {
           return base.ToString() + ", Old Location: " + OldLocation + ", New Location: " + NewLocation;
        }

        public LogEventMove(Employee employee, DateTime time, string oldLocation, string newLocation)
        {
            Employee = employee;
            Time = time;
            OldLocation = oldLocation;
            NewLocation = newLocation;
        }
    }
}