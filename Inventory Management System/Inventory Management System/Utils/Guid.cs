using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;

namespace Inventory_Management_System.Utils
{
    public static class Guid
    {
        // importing required DLL for UUID generation
        [DllImport("rpcrt4.dll", SetLastError = true)]
        // creating new UUID in sequencial.
        static extern int UuidCreateSequential(out System.Guid guid);
   

        public static System.Guid NewGuid()
        {
            return CreateSequentialUuid();
        }

        public static System.Guid CreateSequentialUuid()
        {
            const int RPC_S_OK = 0;
            System.Guid g;
            int hr = UuidCreateSequential(out g);
            if (hr != RPC_S_OK)
                throw new ApplicationException("UuidCreateSequential failed: " + hr);
            return g;
        }
     }
}