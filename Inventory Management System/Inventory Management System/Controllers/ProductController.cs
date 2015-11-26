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

namespace Inventory_Management_System.Controllers
{
    public class ProductController : ApiController
    {
        // GET: api/Product
        public IEnumerable<Product> Get()
        {
            return MySqlCommunication.GetAllProduct();
        }

        //// GET: api/Product/5
        //public string Get(int id)
        //{
        //    return "value with id: " + id;
        //}

        // POST: api/Product
        public void Post([FromBody]acquisitorProduct value)
        {
            var temp = new Product(value); 
            
            MySqlCommunication.Create(temp);
           
        }

        // PUT: api/Product/foo
        //update
        //public void Put(string id, [FromBody]Product value)
        //{
        //    MySqlCommunication.Update();
        //}


        //// DELETE: api/Product/5
        //public void Delete(int id)
        //{
        //    MySqlCommunication.Delete(id);
        //}
    }
}
