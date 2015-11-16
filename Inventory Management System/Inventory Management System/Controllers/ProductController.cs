using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Inventory_Management_System.Controllers
{
    public class ProductController : ApiController
    {
        // GET: api/Product
        public IEnumerable<string> Get()
        {
            return new string[] { "Svend", "Erik" };
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value with id: " + id;
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
