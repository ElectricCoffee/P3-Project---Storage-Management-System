using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using ER = Inventory_Management_System.Models.EmployeeResponsibilities;

namespace Inventory_Management_System.Models.EmployeeData
{
    public class WarehouseManager : Employee, IMngr
    {
        public WarehouseManager(string name, string password, string username)
            : base(name, password, username)
        {
            Responsibilities = new List<ER.IResponsibility>
            {
                new ER.ArticleNumber1       {ReadWrite = false},
                new ER.ArticleNumber2       {ReadWrite = false},
                new ER.SerialNumber         {ReadWrite = false},
                new ER.WorldLocation        {ReadWrite = false},
                new ER.InventoryLocation    {ReadWrite = false},
                new ER.Transit              {ReadWrite = false},
                new ER.Amount               {ReadWrite = false},
                new ER.APrice               {ReadWrite = false},
                new ER.InventoryStatus      {ReadWrite = false},
                new ER.Tags                 {ReadWrite = false},
                new ER.Category             {ReadWrite = false},
                new ER.Images               {ReadWrite = false},
                new ER.Model                {ReadWrite = false},
                new ER.ProductionYear       {ReadWrite = false},
                new ER.Buyer                {ReadWrite = false},
                new ER.SpecSheet            {ReadWrite = false},
                new ER.Documents            {ReadWrite = false}
            };


            if (/*ïndsæt indput valid check her*/true)
            {
                
            }
        }



        public string SetRole(string userinput)
        {
            throw new NotImplementedException();
        }
    }
}
