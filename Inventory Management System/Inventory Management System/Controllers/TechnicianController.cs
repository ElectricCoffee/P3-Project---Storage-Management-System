using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Management_System.Controllers
{
    public class TechnicianController : Controller
    {
        // GET: Technician
        public ActionResult Technician()
        {
            return View();
        }
        public ActionResult TechnicianEdit()
        {
            return View();
        }
    }
}