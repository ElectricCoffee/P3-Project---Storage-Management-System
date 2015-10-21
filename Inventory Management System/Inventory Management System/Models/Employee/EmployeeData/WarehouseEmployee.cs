using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using ER = Inventory_Management_System.Models.EmployeeResponsibilities;

namespace Inventory_Management_System.Models.EmployeeData
{
    public class WarehouseEmployee
        : Employee
    {
        public WarehouseEmployee (string name, string password, string username) 
            : base(name, password, username) 
        {
            Responsibilities = new List<ER.IResponsibility>
            {
                new ER.ArticleNumber1       {ReadWrite = true},
                new ER.ArticleNumber2       {ReadWrite = true},
                new ER.Name                 {ReadWrite = false},
                new ER.SerialNumber         {ReadWrite = true},
                new ER.WorldLocation        {ReadWrite = true},
                new ER.InventoryLocation    {ReadWrite = true},
                new ER.Transit              {ReadWrite = true},
                new ER.InventoryStatus      {ReadWrite = true},
                new ER.Tags                 {ReadWrite = true},
                new ER.Category             {ReadWrite = true},
                new ER.Images               {ReadWrite = true},
                new ER.Model                {ReadWrite = true},
                new ER.Buyer                {ReadWrite = false},
                new ER.Documents            {ReadWrite = true}
            };
            if (/* valid indput check her*/true)
            {
                
            }
               
        }
    }
}
