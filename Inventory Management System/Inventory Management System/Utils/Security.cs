﻿using System;
using System.Collections.Generic;
using System.Diagnostics; // adds Debug.WriteLine
using System.Linq; // adds Linq expressions
using System.Web;

// Aliases
using ED = Inventory_Management_System.Models.EmployeeData;
using ER = Inventory_Management_System.Models.EmployeeResponsibilities;

namespace Inventory_Management_System.Utils
{
    public static class Security
    {
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
    }
}