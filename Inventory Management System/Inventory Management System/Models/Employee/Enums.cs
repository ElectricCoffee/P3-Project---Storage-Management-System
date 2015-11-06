using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Employee.Enums
{
    public enum DestinationType { Responsibility, Employee, Undefined }
    public enum AlertType
    {
        None,    // Grey
        Success, // Green
        Info,    // Blue
        Warning, // Yellow
        Danger   // Red
    }
}