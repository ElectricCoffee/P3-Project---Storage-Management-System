using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_Management_System.Models.Employee;
using Inventory_Management_System.Models.Message;

namespace Inventory_Management_System.Utils
{
    public static class TextParser
    {
        /// <summary>
        /// Checks if the Leading letter of a targetID is E or R
        /// Returns the corresponding DestinationType
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        DestinationType DetermineDestination(EmployeeMessage msg)
        {
            var destKey = Char.ToUpper(msg.TargetID[0]);
            return destKey == 'E'
                ?  DestinationType.Employee
                :  destKey == 'R' // if not E, check R
                ?  DestinationType.Responsibility
                :  DestinationType.Undefined; // if neither E or R, send undefined
        }
    }
}