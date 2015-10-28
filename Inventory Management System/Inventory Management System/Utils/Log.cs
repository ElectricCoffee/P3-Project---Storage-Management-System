using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Utils
{
    public class Log
    {
        public Log()
        {

            Time = DateTime.Now;
        }

        public string LogId { get { return Guid.NewGuid().ToString(); } }
        public DateTime Time { get; private set; }
        
    }
}