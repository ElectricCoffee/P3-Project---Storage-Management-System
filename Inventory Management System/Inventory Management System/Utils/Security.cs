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
        /// <summary>
        /// Throws an argument exception if any of the inputs are null or (if it's a string) empty
        /// </summary>
        /// <param name="input"></param>
        public static void ThrowIfAnyNullOrEmpty(params object[] input)
        {
            Func<object, bool> isNullOrEmpty = obj => 
                obj is String ? 
                String.IsNullOrEmpty(obj as String) : 
                obj == null;

            foreach (var obj in input)
                if(isNullOrEmpty(obj))
                    throw new ArgumentException("Input was null or empty");
        }

        /// <summary>
        /// returns false if any of the inputs are null or (if it's a string) empty
        /// </summary>
        /// <param name="input"></param>
        public static bool AnyNullOrEmpty(params object[] input)
        {
            Func<object, bool> isNullOrEmpty = obj =>
                obj is String ?
                String.IsNullOrEmpty(obj as String) :
                obj == null;

            foreach (var obj in input) if (isNullOrEmpty(obj)) return false;

            return true;
        }

        /// <summary>
        /// Returns the input if it's not empty or null, otherwise throws an argument exception
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string AddIfNotEmpty(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("The input was empty");
            else
                return input;
        }

        /// <summary>
        /// Checks if the employee has the responsibility or not (may not be necessary)
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public static bool HasAccess(ED.Employee emp, ER.IResponsibility res)
        {
            return emp.Responsibilities.Contains(res);
        }
    }
}