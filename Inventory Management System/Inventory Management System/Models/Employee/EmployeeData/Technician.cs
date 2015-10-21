using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using ER = Inventory_Management_System.Models.EmployeeResponsibilities;

namespace Inventory_Management_System.Models.EmployeeData
{
    public class Technician : Employee
    {
        public Technician(string name, string password, string username) 
            : base(name, password, username) 
        {
            Responsibilities = new List<ER.IResponsibility>
            {
                new ER.ArticleNumber1       {ReadWrite = false},
                new ER.ArticleNumber2       {ReadWrite = false},
                new ER.Name                 {ReadWrite = false},
                new ER.SerialNumber         {ReadWrite = false},
                new ER.InventoryLocation    {ReadWrite = true},
                new ER.Tags                 {ReadWrite = true},
                new ER.Images               {ReadWrite = true},
                new ER.Model                {ReadWrite = false},
                new ER.SpecSheet            {ReadWrite = true},
                new ER.Documents            {ReadWrite = true}
            };

            if (/* indsæt valid indput check her*/true)
            {
                
            }
               
        }
    }
}
