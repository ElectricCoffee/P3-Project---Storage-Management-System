﻿using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Inventory_Management_System.Models.EmployeeData
{
    public class Accountant : Employee
    {
        public Accountant(string name, string password, string username)
            : base(name, password, username) 
        {
            if (/*Indsæt valid indput check her*/true)
            {
                
            }
        }
    }
}
