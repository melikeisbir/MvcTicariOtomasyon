﻿using MvcTicariOtomasyon.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Schema;

namespace MvcTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departments.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Department d)
        {
            c.Departments.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departments.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dpt = c.Departments.Find(id);
            return View("DepartmanGetir", dpt);
        }
        public ActionResult DepartmanGuncelle(Department p)
        {
            var dept = c.Departments.Find(p.DepartmanID);
            dept.DepartmanAd = p.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Employees.Where(x => x.DepartmanID == id).ToList();
            var dpt = c.Departments.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SalesTransactions.Where(x=>x.PersonelID==id).ToList();
            var per = c.Employees.Where(x=>x.PersonelID == id).Select(y=>y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }
    }
}