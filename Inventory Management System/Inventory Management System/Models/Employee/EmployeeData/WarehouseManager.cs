using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Inventory_Management_System.Models.EmployeeData
{
    public class WarehouseManager : Employee, IMngr
    {
        public WarehouseManager(string name, string password, string username)
            : base(name, password, username)
        {
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
