﻿using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Inventory_Management_System.Models.EmployeeResponsibilities
{
    public class Buyer : IResponsibilities
    {
        public bool ReadWrite { get; set; }
    }
}
