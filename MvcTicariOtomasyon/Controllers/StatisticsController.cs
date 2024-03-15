using MvcTicariOtomasyon.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Customers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Products.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Employees.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.Categories.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = c.Products.Sum(x => x.Stok).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from x in c.Products select x.UrunMarka).Distinct().Count().ToString(); //tekrarsız olarak say
            ViewBag.d6 = deger6;
            var deger7 = c.Products.Count(x => x.Stok <= 20).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from x in c.Products orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = deger8;
            return View();
        }
    }
}