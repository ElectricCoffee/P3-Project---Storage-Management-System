using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;
using MsGuid = System.Guid;

namespace Inventory_Management_System.Utils
{
    public static class Guid
    {
        /// <summary>
        /// importing required DLL for UUID generation
        /// creating new UUID in sequencial order.
        /// </summary>
        /// <param name="guid">GUID output</param>
        /// <returns></returns>
        [DllImport("rpcrt4.dll", SetLastError = true)]
        private static extern int UuidCreateSequential(out MsGuid guid);

        /// <summary>
        /// Creates a string-version of the GUID
        /// </summary>
        /// <returns></returns>
        public static String CreateString()
        {
            return CreateSequential().ToString();
        }

        /// <summary>
        /// Creates a new sequential GUID
        /// </summary>
        /// <returns></returns>
        public static MsGuid CreateSequential()
        {
            MsGuid g;
            int ok = 0, hr = UuidCreateSequential(out g);
            if (hr != ok)
                throw new ApplicationException("UuidCreateSequential failed: " + hr);
            return g;
        }
     }
}