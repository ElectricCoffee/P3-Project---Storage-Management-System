using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Inventory_Management_System.Models.EmployeeData;
using Inventory_Management_System.Models.Message;

#warning replace this with concrete type!!
using Target = System.Object;

namespace Inventory_Management_System.Controllers
{
    public class MessageController : ApiController
    {

        public List<Queue<EmployeeMessage>> MessageQueue = new List<Queue<EmployeeMessage>>();  //en liste af køer af meddelser

        /// <summary>
        /// Send Message to the employee(s) and add's the message to the queue og the rolegroup.
        /// </summary>
        /// <param name="msg">The message, wich have the target employee.</param>
        /// <returns></returns>
        public EmployeeMessage SendMessage(EmployeeMessage msg)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add a message to the queue of the target rolegroup.
        /// </summary>
        /// <param name="msg">The message, wich have the target rolegroup.</param>
        /// <returns></returns>
        public Queue<Target> EnQueue(EmployeeMessage msg)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Dequeue the first added message to the queue.
        /// </summary>
        /// <returns>returns the first added message.</returns>
        public EmployeeMessage DeQueue()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Recive a message from the employee and make sure to resend the message to the right employee.
        /// </summary>
        /// <param name="msg">the message wich contain the target employee(s).</param>
        /// <returns></returns>
        public EmployeeMessage ReciveMessage(EmployeeMessage msg)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the hole queue of a rolegroup.
        /// </summary>
        /// <param name="target">the target rolegroup.</param>
        /// <returns>Returns the hole queue.</returns>
        Queue<Target> SendQueue(Target target)
        {
            throw new NotImplementedException();
        }
    }

    
}
