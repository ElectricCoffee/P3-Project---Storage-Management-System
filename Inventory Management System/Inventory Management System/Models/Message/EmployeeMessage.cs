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
        public string TargetID { get; private set; }
        public string Message { get; private set; }
        public Enums.AlertType MessageType { get; private set; }

        public EmployeeMessage(Enums.AlertType messageType, string targetId, string message)
        {
            TargetID = targetId;
            Message = message;
            MessageType = messageType;
        }

        public EmployeeMessage(string targetId, string message)
            : this(Enums.AlertType.Info, targetId, message) { }

    }
}