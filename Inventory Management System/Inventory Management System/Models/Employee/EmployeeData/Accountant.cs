using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using ER = Inventory_Management_System.Models.EmployeeResponsibilities;

namespace Inventory_Management_System.Models.EmployeeData
{
    public class Accountant : Employee
    {
        public Accountant(string name, string password, string username)
            : base(name, password, username) 
        {
            Responsibilities = new List<ER.IResponsibility> 
            {
                new ER.ArticleNumber1 {ReadWrite = false}, // readwrite = false means it's only read
                new ER.ArticleNumber2 {ReadWrite = false},
                new ER.Name           {ReadWrite = false},
                new ER.SerialNumber   {ReadWrite = false},
                new ER.APrice         {ReadWrite = false},
                new ER.SalesStatus    {ReadWrite = true},
                new ER.Category       {ReadWrite = false},
                new ER.Model          {ReadWrite = false},
                new ER.Buyer          {ReadWrite = false},
                new ER.SalesPrice     {ReadWrite = false}
            };

            if (/*Indsæt valid indput check her*/true)
            {
                
            }
        }
    }
}
