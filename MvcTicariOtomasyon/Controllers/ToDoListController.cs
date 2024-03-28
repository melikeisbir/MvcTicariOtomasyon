using MvcTicariOtomasyon.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class ToDoListController : Controller
    {
        // GET: ToDoList
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Customers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Products.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Categories.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = (from x in c.Customers select x.CariSehir).Distinct().Count().ToString();
            ViewBag.d4 = deger4;
            return View();
        }
    }
}