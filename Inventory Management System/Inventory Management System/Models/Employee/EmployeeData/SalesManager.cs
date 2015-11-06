using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using ER = Inventory_Management_System.Models.EmployeeResponsibilities;

namespace Inventory_Management_System.Models.EmployeeData
{
    public class SalesManager : Salesmen, IMngr
    {
        public SalesManager(string name, string password, string username, string role)
            : base(name, password, username, role)
        {
            Responsibilities = new List<ER.IResponsibility> 
            {
                new ER.ArticleNumber1 {ReadWrite = false},
                new ER.ArticleNumber2 {ReadWrite = false},
                new ER.Name           {ReadWrite = false},
                new ER.SerialNumber   {ReadWrite = false},
                new ER.Amount         {ReadWrite = false},
                new ER.SalesStatus    {ReadWrite = true},
                new ER.Tags           {ReadWrite = false},
                new ER.Category       {ReadWrite = false},
                new ER.Images         {ReadWrite = false},
                new ER.Model          {ReadWrite = false},
                new ER.ProductionYear {ReadWrite = false},
                new ER.SpecSheet      {ReadWrite = false},
                new ER.Documents      {ReadWrite = false},
                new ER.SalesPrice     {ReadWrite = true}
            };

            if (/*indsæt valid indput check*/true)
            {

            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public string SetRole(string userinput)
        {
            throw new NotImplementedException();
        }
    }
}
