using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Inventory_Management_System.Models.EmployeeResponsibilities
{
    public class InventoryStatus : IResponsibility
    {
        public bool ReadWrite { get; set; }
    }
}
