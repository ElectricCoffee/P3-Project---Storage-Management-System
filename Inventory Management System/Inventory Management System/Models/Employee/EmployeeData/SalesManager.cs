using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Inventory_Management_System.Models.EmployeeData
{
    public class SalesManager : Salesmen, IMngr
    {
        public SalesManager(string name, string password, string username)
            : base(name, password, username)
        {
            if (/*indsæt valid indput check*/true)
            {

            }
        }

        public string SetRole(string userinput)
        {
            throw new NotImplementedException();
        }
    }
}
