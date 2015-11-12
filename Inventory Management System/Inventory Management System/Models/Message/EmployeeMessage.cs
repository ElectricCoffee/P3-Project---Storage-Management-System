using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_Management_System.Models.EmployeeData;
using Enums = Inventory_Management_System.Models.Employee.Enums;

namespace Inventory_Management_System.Models.Message
{
    public class EmployeeMessage
    {
        public string Group { get; set; }
        public string Message { get; set; }
        public string Sender { get; set; }
        public Enums.AlertType MessageType { get; set; }

        public EmployeeMessage(Enums.AlertType messageType, string targetId, string message)
        {
            Group = targetId;
            Message = message;
            MessageType = messageType;
        }
    }
}