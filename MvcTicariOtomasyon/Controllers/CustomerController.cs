using MvcTicariOtomasyon.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Customers.Where(x=>x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Customer p)
        {
            p.Durum = true;
            c.Customers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cr = c.Customers.Find(id);
            cr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}