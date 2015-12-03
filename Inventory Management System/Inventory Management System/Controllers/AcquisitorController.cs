using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_Management_System.Models.Product;

namespace Inventory_Management_System.Controllers
{
    public class AcquisitorController : Controller
    {
        // GET: Acquisitor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(string articlenumber1)
        {
            return View(articlenumber1);
        }
        public ActionResult Add()
        {
            return View();
        }
    }
}