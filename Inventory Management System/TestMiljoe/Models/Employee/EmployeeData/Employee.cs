using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using ER = Inventory_Management_System.Models.EmployeeResponsibilities;
using Inventory_Management_System.Utils;

namespace Inventory_Management_System.Models.EmployeeData
{
    public abstract class Employee
    {
        /// <summary>
        /// List of an employee's responsibilities
        /// </summary>
        public List<ER.IResponsibility> Responsibilities { get; set; }

        /// <summary>
        /// First and lastname
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// til login
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// til login
        /// </summary>
        public string Username { get; set; }

        public Employee(string name, string password, string username)
        {
            if (Security.AnyNullOrEmpty(name, password, username))
            {
                throw new ArgumentNullException("Du det dårligste menneske jeg kender.");
            }
            Name = name;
            Password = password;
            Username = username;
        }
        
        
        /// <summary>
        /// Ved større ændringer - Indtast password
        /// </summary>
        public void SetPassword(string userinput)
        {
            Password = userinput;
        }

        public void SetUsername(string userinput)
        {
            Username = userinput;
        }

    }
}
