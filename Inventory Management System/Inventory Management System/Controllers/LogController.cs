using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Inventory_Management_System.MySql;
using Inventory_Management_System.Models.Product;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Text;
using Inventory_Management_System.BigBrother;

namespace Inventory_Management_System.Controllers
{
    public class LogController : ApiController
    {
        // GET: api/Log
        public IEnumerable<LognLoad> Get()
        {
            return MySqlCommunication.GetAllLogs();
        }

        // GET: api/Log/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Log
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Log/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Log/5
        public void Delete(int id)
        {
        }
    }
}
