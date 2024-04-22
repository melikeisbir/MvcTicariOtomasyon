using MvcTicariOtomasyon.Models.Class;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class GraphicController : Controller
    {
        // GET: Graphic
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[] { "Molbilya", "Ofis Eşyaları", "Bilgisayar" }, yValues: new[] { 85, 66, 98 }).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }

        Context c = new Context();
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = c.Products.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.UrunAd)); //her listeye ürünad ekle
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stok));
            var grafik = new Chart(width: 800, height: 800)
                .AddTitle("Stoklar")
                .AddSeries(chartType: "Pie", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }
        public List<Class2> UrunListesi()
        {
            List<Class2> snf= new List<Class2>();
            snf.Add(new Class2()
            {
                urunad = "Bilgisayar",
                stok = 120
            });
            snf.Add(new Class2()
            {
                urunad = "Beyaz Eşya",
                stok = 150
            });
            snf.Add(new Class2()
            {
                urunad = "Mobilya",
                stok = 70
            });
            snf.Add(new Class2()
            {
                urunad = "Küçük Ev Aletleri",
                stok = 180
            });
            snf.Add(new Class2()
            {
                urunad = "Mobil Cihazlar",
                stok = 90
            });
            return snf;
        }
    }
}