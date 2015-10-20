using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;


namespace Inventory_Management_System.Models.EmployeeData
{
    public abstract class Employee
    {
        //public string Role { get; set; }

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
            if (name == null || password == null || username == null)
            {
                throw new Exception();
            }
            //Role = role;
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
