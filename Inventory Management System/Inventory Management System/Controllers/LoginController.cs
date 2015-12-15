using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Inventory_Management_System.Models;
using Inventory_Management_System.Utils;

namespace Inventory_Management_System.Controllers
{
    public class LoginController : ApiController
    {
        private Dictionary<string, string> roleMap = new Dictionary<string, string> 
        { 
            {"Accountant", "Accountant/Index"},
            {"Acquisitor", "Acquisitor/Index"},
            {"InvEmp", "InvEmp/InventoryEmployee"},
            {"InvMan", "InvEmp/InventoryManager"},
            {"SalesEmp", "SalesEmp/Employee"},
            {"SalesMan", "SalesEmp/Manager"},
            {"Technician", "Technician/Index"},
        };

        //// GET: api/Login
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Login/5
        //public string Get([FromUri] Login value)
        //{
        //    return "value";
        //}

        //// POST: api/Login
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT: api/Login/5
        public IEnumerable<String> Put([FromBody] Login value)
        {
            var resTpl = Security.GetRole(value.Username, value.Password); // (role, name)
            var role = resTpl.Item1;
            var name = resTpl.Item2;
            var roleUri = roleMap[role];

            return new[] { roleUri, name };
        }

        //// DELETE: api/Login/5
        //public void Delete(int id)
        //{
        //}
    }
}
