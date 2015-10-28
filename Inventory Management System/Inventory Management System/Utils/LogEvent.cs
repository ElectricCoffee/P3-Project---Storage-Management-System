using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_Management_System.Models.EmployeeData;

namespace Inventory_Management_System.Utils
{
    public abstract class LogEvent
    {
        public Employee Employee { get; protected set; }
        public DateTime Time { get; protected set; }


        public override abstract string ToString();

    }
}