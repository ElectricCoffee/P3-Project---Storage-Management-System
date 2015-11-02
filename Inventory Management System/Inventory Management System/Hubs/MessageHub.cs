using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Inventory_Management_System.Hubs
{
    [HubName("message")]
    public class MessageHub : Hub
    {
        public void SendMessage(String sender, String message)
        {
            // just relay the message to all the clients
            Clients.All.displayMessage(sender, message);
        }
    }
}