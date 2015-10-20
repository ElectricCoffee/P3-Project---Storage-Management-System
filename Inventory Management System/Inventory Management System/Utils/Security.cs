using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ER = Inventory_Management_System.Models.EmployeeResponsibilities;
using ED = Inventory_Management_System.Models.EmployeeData;

namespace Inventory_Management_System.Utils
{
    public static class Security
    {
        
        bool HasAccess(ED.Employee emp, ER.IResponsibilities res)
        {
            throw new NotImplementedException("TBD");
        }
        

    }
}