using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Inventory_Management_System.Models.EmployeeData;
using Inventory_Management_System.Models.Message;
using MySql = Inventory_Management_System.MySql;

#warning replace this with concrete type!!
using Target = System.Object;
using System.Diagnostics;

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

        [Route("api/message-group")]
        [HttpGet]
        public string GetMessageGroup()
        {
            Debug.WriteLine(">>> Getting Group");
            return "TestGroup";
        }

        [Route("api/message-group/{uname:alpha}")]
        [HttpGet]
        public string GetMessageGroup(string userName)
        {
            var tableName = MySql.MySqlCommunication.EmployeeTable;
            return MySql.MySqlCommunication.Select(tableName, "Role", "UserName", userName);
        }
    }
}
