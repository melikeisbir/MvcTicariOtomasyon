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
            var deger9 = (from x in c.Products orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = c.Products.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;
            var deger11 = c.Products.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.d11 = deger11;
            var deger12 = c.Products.GroupBy(x => x.UrunMarka).OrderByDescending(z=>z.Count()).Select(y=>y.Key).FirstOrDefault(); 
            ViewBag.d12 = deger12;
            var deger13 = c.Products.Where (u=>u.UrunID == (c.SalesTransactions.GroupBy(x => x.UrunID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k=>k.UrunAd).FirstOrDefault();
            ViewBag.d13 = deger13;
            var deger14 = c.SalesTransactions.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;

            DateTime bugun = DateTime.Today;
            var deger15 = c.SalesTransactions.Count(x => x.Tarih == bugun).ToString();
            ViewBag.d15 = deger15;
            var deger16 = c.SalesTransactions.Where(x => x.Tarih == bugun).Sum(y => (decimal?)y.ToplamTutar).ToString();
            ViewBag.d16 = deger16;
            return View();
        }
        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Customers
                        group x by x.CariSehir into g
                        select new ClassGroup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }
        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Employees
                         group x by x.Department.DepartmanAd into g
                         select new ClassGroup2
                         {
                             Departman = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var sorgu = c.Customers.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial3()
        {
            var sorgu = c.Products.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial4()
        {
            var sorgu = from x in c.Products
                         group x by x.UrunMarka into g
                         select new ClassGroup3
                         {
                             Marka = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu.ToList());
        }
    }
}