using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Inventory_Management_System.Models.EmployeeData
{
    public class Technician : Employee
    {
        public Technician(string name, string password, string username) 
            : base(name, password, username) 
        {
            if (/* indsæt valid indput check her*/true)
            {
                
            }
               
        }
    }
}
