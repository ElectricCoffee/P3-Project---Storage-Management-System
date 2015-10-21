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
        public static void ThrowIfAnyEmpty(params string[] input)
        {
            foreach (var str in input)
            {
                if (String.IsNullOrEmpty(str)) throw new ArgumentException("Input was null or empty");
            }
        }

        public static string AddIfNotEmpty(string input)
        {
            if (String.IsNullOrEmpty(input)) 
                throw new ArgumentException("The input was empty");
            else 
                return input;
        }

        public static bool HasAccess(ED.Employee emp, ER.IResponsibility res)
        {
            return emp.Responsibilities.Contains(res);
        }
    }
}