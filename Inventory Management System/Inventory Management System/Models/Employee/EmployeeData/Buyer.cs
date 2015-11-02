using System;
using System.Collections.Generic;
using ER = Inventory_Management_System.Models.EmployeeResponsibilities;

namespace Inventory_Management_System.Models.EmployeeData
{
    public class Buyer : Employee
    {
        public Buyer(string name, string password, string username, string role) //indkøber
            : base(name, password, username, role)
        {
            Responsibilities = new List<ER.IResponsibility>
            {
                new ER.ArticleNumber1       {ReadWrite = false},
                new ER.ArticleNumber2       {ReadWrite = false},
                new ER.Name                 {ReadWrite = true},
                new ER.SerialNumber         {ReadWrite = false},
                new ER.Amount               {ReadWrite = false},
                new ER.APrice               {ReadWrite = true},
                new ER.Tags                 {ReadWrite = true},
                new ER.Category             {ReadWrite = true},
                new ER.Model                {ReadWrite = true},
                new ER.ProductionYear       {ReadWrite = true}
            };


            if (/*ïndsæt indput valid check her*/true)
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