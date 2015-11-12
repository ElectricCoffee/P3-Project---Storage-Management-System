using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using ER = Inventory_Management_System.Models.EmployeeResponsibilities;
using Inventory_Management_System.Utils;
using Inventory_Management_System.MySql;

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

        public string Role { get; private set; }

        public Employee(string name, string password, string username, string role)
        {
            if (Security.AnyNullOrEmpty(name, password, username))
            {
                throw new ArgumentNullException("Du det dårligste menneske jeg kender.");
            }
            Name = name;
            Password = password;
            Username = username;
            Role = role;
            MySqlCommunication.CreateUser(username, password, role, name);
        }

        public override string ToString()
        {
            return "Name: " + Name + "Username: " + Username;
        }

        /// <summary>
        /// Ved større ændringer - Indtast password
        /// </summary>
        public void SetPassword(string oldPassword, string newPassword)
        {
            if (Security.LogInCheck(this.Username, oldPassword))
            {
                Password = newPassword;
                Security.ChangePassword(this.Username, oldPassword, newPassword);
            }
        }

        public void SetUsername(string newUsername, string password)
        {
            if (Security.LogInCheck(this.Username, password))
            {
                MySqlCommunication.Update(MySqlCommunication.EmployeeTable, new List<string> { "UserName", "Password" }, new List<string> { newUsername, Security.HashPassword(newUsername, password) }, "UserName", this.Username);
                
                Username = newUsername;
            }
        }

    }
}