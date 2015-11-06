using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_Management_System.Models.Employee.Enums;
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
        /// <returns>Corresponding DestinationType</returns>
        public static DestinationType DetermineDestination(EmployeeMessage msg)
        {
            var destKey = Char.ToUpper(msg.TargetID[0]);
            return destKey == 'E'
                ? DestinationType.Employee
                : destKey == 'R' // if not E, check R
                ? DestinationType.Responsibility
                : DestinationType.Undefined; // if neither, send undefined
        }

        public static Tuple<String, String> SplitMessage(string message)
        {
            var seperator = new[] {' '}; // this is stupid..
            var msgBody   = message.Split(seperator, 2);
            var keyword   = (msgBody[0][0] == '#' ? msgBody[0] : "#info").Substring(1);
            var rest      = msgBody[1];

            return Tuple.Create(keyword, rest);
        }

        public static EmployeeMessage ParseMessage(string message, string target)
        {
            var split   = SplitMessage(message);
            var keyword = (AlertType) Enum.Parse(typeof(AlertType), split.Item1, ignoreCase: true);
            var msgBody = split.Item2;

            return new EmployeeMessage(keyword, target, msgBody);
        }
    }
}