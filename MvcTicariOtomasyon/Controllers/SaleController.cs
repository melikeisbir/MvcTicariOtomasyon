using MvcTicariOtomasyon.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SalesTransactions.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SalesTransaction s)
        {
            c.SalesTransactions.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}