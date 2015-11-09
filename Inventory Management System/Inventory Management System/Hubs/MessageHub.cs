using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Inventory_Management_System.Models.Message;

namespace Inventory_Management_System.Hubs
{
    [HubName("message")]
    public class MessageHub : Hub
    {
        public void SendMessage(EmployeeMessage message)
        {
            if (message.Group == null)
                Clients.All.displayMessage(message);
            else
                Clients.Group(message.Group).displayMessage(message);
        }

        public void JoinGroup(string groupName)
        {
            Groups.Add(Context.ConnectionId, groupName);
        }
    }
}