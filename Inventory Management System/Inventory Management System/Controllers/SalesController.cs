using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Management_System.Controllers
{
    public class SalesEmpController : Controller
    {
        // GET: SalesEmp
        public ActionResult Employee()
        {
            return View();
        }
        public ActionResult Manager()
        {
            return View();
        }
        public ActionResult ManagerEdit()
        {
            return View();
        }
        public ActionResult EmployeeEdit()
        {
            return View();
        }
    }
}