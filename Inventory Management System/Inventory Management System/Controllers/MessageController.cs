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
        // get all the messages
        public void Get() { }
        // get all messages defined by a specific target
        public void Get([FromUri] Target target) { }
        public void Put() { }
        public void Post() { }
        public void Delete() { }

        //public EmployeeMessage SendMessage([FromBody] EmployeeMessage msg)
        //{
        //    throw new NotImplementedException();
        //}

        //public Queue<Target> EnQueue([FromBody] EmployeeMessage msg, [FromUri] Target target)
        //{
        //    throw new NotImplementedException();
        //}

        //public EmployeeMessage DeQueue()
        //{
        //    throw new NotImplementedException();
        //}

        //public EmployeeMessage ReciveMessage([FromBody] EmployeeMessage msg)
        //{
        //    throw new NotImplementedException();
        //}

        //Queue<Target> SendQueue([FromUri] Target target)
        //{
        //    throw new NotImplementedException();
        //}
    }

    
}
