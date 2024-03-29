﻿using MvcTicariOtomasyon.Models.Class;
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
        {//dropdown ile çekebilmemiz için listeleme komutları
            List<SelectListItem> deger1 = (from x in c.Products.ToList() //ürünler
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();


            List<SelectListItem> deger2 = (from x in c.Customers.ToList() //cariler
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Employees.ToList()  //personeller
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SalesTransaction s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortTimeString());
            c.SalesTransactions.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Products.ToList() //ürünler
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();


            List<SelectListItem> deger2 = (from x in c.Customers.ToList() //cariler
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Employees.ToList()  //personeller
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var deger = c.SalesTransactions.Find(id);
            return View("SatisGetir", deger);
        }
        public ActionResult SatisGuncelle(SalesTransaction p)
        {
            var deger = c.SalesTransactions.Find(p.SatisID);
            deger.CariID = p.CariID;
            deger.Adet = p.Adet;
            deger.Fiyat = p.Fiyat;
            deger.PersonelID = p.PersonelID;
            deger.Tarih = p.Tarih;
            deger.ToplamTutar = p.ToplamTutar;
            deger.UrunID = p.UrunID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var degerler = c.SalesTransactions.Where(x => x.SatisID == id).ToList();
            return View(degerler);
        }
    }
}