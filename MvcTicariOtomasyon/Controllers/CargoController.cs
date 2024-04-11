using MvcTicariOtomasyon.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo
        Context c = new Context();
        public ActionResult Index()
        {
            var kargolar = c.CargoDetails.ToList();
            return View(kargolar);
        }
        public ActionResult YeniKargo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKargo(CargoDetail d)
        {
            c.CargoDetails.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}