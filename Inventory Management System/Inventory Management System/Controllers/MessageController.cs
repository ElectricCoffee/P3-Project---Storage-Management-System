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
        public EmployeeMessage SendMessage(EmployeeMessage msg)
        {
            throw new NotImplementedException();
        }

        public Queue<Target> EnQueue(EmployeeMessage msg)
        {
            throw new NotImplementedException();
        }

        public EmployeeMessage DeQueue()
        {
            throw new NotImplementedException();
        }

        public EmployeeMessage ReciveMessage(EmployeeMessage msg)
        {
            throw new NotImplementedException();
        }

        Queue<Target> SendQueue(Target target)
        {
            throw new NotImplementedException();
        }
    }

    
}
