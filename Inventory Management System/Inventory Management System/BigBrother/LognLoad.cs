using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_Management_System.BigBrother;
using Inventory_Management_System.Models.EmployeeData;
using Inventory_Management_System.Models.Product;

namespace Inventory_Management_System.BigBrother
{
    public class LognLoad
    {
        public string Username { get; set; }
        public string Comment { get; set; }
        public string Datetime { get; set; }


        public LognLoad(string username, string comment, string datetime) 
        {
            Username = username;
            Comment = comment;
            Datetime = datetime;
        }
    }
}