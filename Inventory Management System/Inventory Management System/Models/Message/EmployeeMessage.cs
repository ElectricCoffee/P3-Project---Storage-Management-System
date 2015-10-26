using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_Management_System.Models.EmployeeData;

namespace Inventory_Management_System.Models.Message
{
    public class EmployeeMessage
    {
        public string TargetID {get; private set; }
        public string Message { get; private set; }
        public string ProductID { get; private set; }
        public string SenderID { get; private set; }


        public EmployeeMessage(string targetId, string senderId, string productId, string message)
        {
            TargetID = targetId;
            Message = message;
            ProductID = productId;
            SenderID = senderId;
        }
    }
}