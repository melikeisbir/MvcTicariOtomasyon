using MvcTicariOtomasyon.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Employees.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle() 
        {
            List<SelectListItem> deger1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Employee p)
        {
            c.Employees.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var prs = c.Employees.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult PersonelGuncelle(Employee p)
        {
            var prsn = c.Employees.Find(p.PersonelID);
            prsn.PersonelAd = p.PersonelAd;
            prsn.PersonelGorsel = p.PersonelGorsel;
            prsn.PersonelSoyad = p.PersonelSoyad;
            prsn.DepartmanID = p.DepartmanID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}