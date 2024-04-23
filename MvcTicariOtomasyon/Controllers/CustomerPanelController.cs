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
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Customers.Where(x=>x.CariMail == mail.ToString()).Select(y=>y.CariID).FirstOrDefault();
            var degerler = c.SalesTransactions.Where(x => x.CariID == id).ToList();
            return View(degerler);
        }
        
        public ActionResult GelenMesajlar()
        {
            var mesajlar = c.Messages.ToList();
            return View(mesajlar);
        }
        //[HttpGet]
        //public ActionResult YeniMesaj()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult YeniMesaj()
        //{
        //    return View();
        //}
    }
}