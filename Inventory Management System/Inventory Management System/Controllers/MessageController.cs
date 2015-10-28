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
        /// <summary>
        /// Gets the complete queue of all pending messages
        /// </summary>
        /// <returns></returns>
        [Route("api/messages")]
        [HttpGet]
        public Queue<EmployeeMessage> AllMessages()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the queue for a specific target
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        [Route("api/messages/{id:alpha}")]
        [HttpGet]
        public Queue<EmployeeMessage> TargetMessages(Target target)
        {
            throw new NotImplementedException();
        }
    }


}
