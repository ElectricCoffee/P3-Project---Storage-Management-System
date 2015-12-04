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
        public IEnumerable<PSystem> Get()
        {
            Debug.WriteLine("Getting product WITHOUT article number");
            return MySqlCommunication.GetAllProduct();
        }

        // GET: api/Product/5
        public PSystem Get(string id)
        {
            Debug.WriteLine("Getting product by article number");
            return MySqlCommunication.Read(id);
        }

        // POST: api/Product
        public void Post([FromBody]PSystem value)
        {
            Debug.WriteLine("Post function in productController");
            //var temp = new Product(value); 
            MySqlCommunication.Create(value);
        }
        //public void Post([FromBody]inventoryEmployeeProduct value)
        //{
        //    var temp = new Product(value);
        //    MySqlCommunication.Create(temp);
        //}

        //PUT: api/Product/foo
        public void Put([FromBody]PSystem value)
        {
            MySqlCommunication.Update(value);
        }


        // DELETE: api/Product/foobar
        public void Delete(string id)
        {
            MySqlCommunication.Delete(id);
        }
    }
}
