using ShopDuongSon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopDuongSon.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        public ActionResult Category()
        {
            var model = db.Categories;
            return PartialView("_CategoryPartial", model);
        }

        public ActionResult Supplier()
        {
            var model = db.Suppliers;
            return PartialView("_SupplierPartial", model);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}