using System;
using System.Collections.Generic;
using System.Diagnostics; // adds Debug.WriteLine
using System.Linq; // adds Linq expressions
using System.Web;
using System.Security.Cryptography;
using Inventory_Management_System.MySql;

// Aliases
using ED = Inventory_Management_System.Models.EmployeeData;
using ER = Inventory_Management_System.Models.EmployeeResponsibilities;
using System.Text;

namespace Inventory_Management_System.Utils
{
    public static class Security
    {
        public static string Salt = "srh91awac98sel23sjn8glc9dv2e1a8a6f";

        private static bool IsNullOrEmpty(object obj)
        {
            return obj is String ?
                String.IsNullOrEmpty(obj as String) :
                obj == null;
        }

        /// <summary>
        /// Throws an argument exception if any of the inputs are null or (if it's a string) empty
        /// </summary>
        /// <param name="input"></param>
        public static void ThrowIfAnyNullOrEmpty(params object[] input)
        {
            foreach (var obj in input)
                if(IsNullOrEmpty(obj))
                    throw new ArgumentException("Input was null or empty");
        }

        /// <summary>
        /// returns false if any of the inputs are null or (if it's a string) empty
        /// </summary>
        /// <param name="input"></param>
        public static bool AnyNullOrEmpty(params object[] input)
        {
            foreach (var obj in input) if (IsNullOrEmpty(obj)) return true;

            return false;
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

        /// <summary>
        /// Tries to create an object of the specified type a number of times
        /// </summary>
        /// <typeparam name="Ex">An Exception</typeparam>
        /// <typeparam name="Res">The result type</typeparam>
        /// <param name="body">The code body</param>
        /// <param name="exBody">The exception body</param>
        /// <returns></returns>
        public static Res TryCreate<Ex, Res>(int times, Func<Res> body, Action<Ex> exBody) where Ex : Exception
        {
            int i = 0;
            Func<Res, bool> isDefault = r => EqualityComparer<Res>.Default.Equals(r, default(Res));
            Res result = default(Res);

            do // attempt getting result a number of times
            {
                try { result = body(); } // try setting the result returned from body
                catch (Ex exception) { exBody(exception); } // if it fails do something with the result
            } while (isDefault(result) && i++ < times);

            if (isDefault(result)) // if the result is still the default value, throw 
                throw (Ex)Activator.CreateInstance(typeof(Ex), "Could not create");
            else return result;
        }

        /// <summary>
        /// Tries to create an object of the specified type
        /// </summary>
        /// <typeparam name="Ex">An Exception</typeparam>
        /// <typeparam name="Res">The result type</typeparam>
        /// <param name="body">The code body</param>
        /// <param name="exBody"></param>
        /// <returns></returns>
        public static Res TryCreate<Ex, Res>(Func<Res> body, Action<Ex> exBody) where Ex : Exception
        {
            return TryCreate<Ex, Res>(1, body, exBody);
        }


        /// <summary>
        /// Tries to create an object of the specified type, has logging built in
        /// </summary>
        /// <typeparam name="Ex">An Exception</typeparam>
        /// <typeparam name="Res">The result type</typeparam>
        /// <param name="body">The code body</param>
        /// <returns></returns>
        public static Res TryCreateWithLog<Ex, Res>(Func<Res> body) where Ex : Exception
        {
            return TryCreate<Ex, Res>(body, x => Debug.WriteLine(x.Message));
        }

        /// <summary>
        /// Checks that the username and password are correct
        /// </summary>
        /// <param name="Username">the username</param>
        /// <param name="password">the not hashed password</param>
        /// <returns>if the user and password are correct</returns>
        public static bool LogInCheck(string Username, string password)
        {
            if (Username != null && password != null && MySqlCommunication.GetHashedPassword(Username) == HashPassword(Username,password))
                return true;
            return false;
        }

        /// <summary>
        /// Hashes a text
        /// </summary>
        /// <param name="text">the text you want hashed</param>
        /// <returns>the hashed text</returns>
        public static string Hash(string text)
        {
            if (text == null) return "";
            var sha1 = new SHA1CryptoServiceProvider();
            sha1.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            StringBuilder sb = new StringBuilder();
            foreach(byte b in sha1.Hash)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// hashes a password
        /// </summary>
        /// <param name="Username">the username</param>
        /// <param name="password">the not hashed password</param>
        /// <returns>the hashed password with username and salt</returns>
        public static string HashPassword(string Username, string password)
        {
            return Hash(Salt + Hash(Username + Hash(password)));
        }

        /// <summary>
        /// Checks and change the password
        /// </summary>
        /// <param name="Username">the username</param>
        /// <param name="OldPassword">the old password</param>
        /// <param name="NewPassword">the new password</param>
        /// <returns></returns>
        public static bool ChangePassword(string Username, string OldPassword, string NewPassword)
        {
            if(LogInCheck(Username,OldPassword))
            {
                MySqlCommunication.Update(MySqlCommunication.EmployeeTable, new List<string> { "Password" }, new List<string> { NewPassword }, "Username", Username);
                return true;
            }
            return false;
        }

        public static Tuple<string, string> GetRole(string usr, string psw)
        {
            if (LogInCheck(usr,psw))
            {
                List<string> emp = MySqlCommunication.GetList("SELECT * FROM " + MySqlCommunication.EmployeeTable + " WHERE UserName = '" + usr + "'",5)[0];
                return new Tuple<string,string>(emp[4],emp[2] );
            }
            return null;
        }
    }
}