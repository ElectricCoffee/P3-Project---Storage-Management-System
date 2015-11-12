using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Message
{
    public class ReceiverRegister
    {
        // return new instance if instance is null, otherwise return itself.
        private static ReceiverRegister instance = instance ?? new ReceiverRegister();
        private List<string> receivers;

        private ReceiverRegister() 
        {
            receivers = new List<string>();
        }

        public static ReceiverRegister Instance
        {
            get { return instance; }
        }

        public List<string> Receivers
        {
            get { return receivers; }
        }

        public bool ReceiverExists(string receiver)
        {
            return receivers.Exists(x => String.Equals(x, receiver));
        }

        public void AddReceiver(string receiver)
        {
            if (ReceiverExists(receiver) == false)
                receivers.Add(receiver);
        }
    }
}