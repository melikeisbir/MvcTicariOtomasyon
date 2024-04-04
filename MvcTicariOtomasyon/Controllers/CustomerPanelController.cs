using MvcTicariOtomasyon.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class CustomerPanelController : Controller
    {
        // GET: CustomerPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"]; //cari mailden gelenler session olarak tutulacak
            var degerler = c.Customers.FirstOrDefault(x=>x.CariMail == mail);
            ViewBag.m = mail;
            return View(degerler);
        }
    }
}