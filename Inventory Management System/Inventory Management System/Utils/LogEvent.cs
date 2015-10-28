using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_Management_System.Models.EmployeeData;

namespace Inventory_Management_System.Utils
{
    public abstract class LogEntryEvent
    {
        public virtual Employee Employee { get; protected set; }
        public virtual DateTime Time { get; protected set; }

        public override string ToString()
        {
            return "Employee: " + Employee + ", Date: " + Time;
        }
    }
}