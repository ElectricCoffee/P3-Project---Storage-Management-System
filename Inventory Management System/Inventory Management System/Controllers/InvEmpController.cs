using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Management_System.Controllers
{
    public class InvEmpController : Controller
    {
        // GET: InvEmp
        public ActionResult InventoryEmployee()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult InventoryManager()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Log()
        {
            return View();
        }
    }
}