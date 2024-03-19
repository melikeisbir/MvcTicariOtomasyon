using MvcTicariOtomasyon.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        Context c = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = c.Products.Where(X => X.UrunID == 1).ToList();
            cs.Deger2 = c.Details.Where(y => y.DetayID == 1).ToList();
            return View(cs);
        }
    }
}