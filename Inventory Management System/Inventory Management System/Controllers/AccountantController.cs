using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Management_System.Controllers
{
    public class AccountantController : Controller
    {
        // GET: Accountant
        public ActionResult Accountant()
        {
            return View();
        }
        public ActionResult AccountantEdit()
        {
            return View();
        }
    }
}