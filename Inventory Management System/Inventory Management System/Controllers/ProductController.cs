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
        public IEnumerable<Object> Get()
        {
            var dummy = new
            {
                ArticleNumber = "f42",
                Name = "Michael",
                SerialNumber = "daniel19",
                SalesPrice = 1234,
                SalesStatus = "sold",
                Amount = 4,
                Acquisitor = "Mads",
                AcquisitionPrice = 1111,
                Category = "CT",
                Model = "Hoomin",
                Tags = "Briller"
            };

            var dummy2 = new
            {
                ArticleNumber = "e234",
                Name = "Jakob",
                SerialNumber = "morten22",
                SalesPrice = 2345,
                SalesStatus = "available",
                Amount = 3,
                Acquisitor = "Daniel",
                AcquisitionPrice = 2222,
                Category = "MRI",
                Model = "Animul",
                Tags = "Hoars"
            };

            return new Object[] { dummy, dummy2 };
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
