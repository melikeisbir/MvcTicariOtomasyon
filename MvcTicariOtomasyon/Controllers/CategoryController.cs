using MvcTicariOtomasyon.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Categories.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]  
        public ActionResult AddCategory(Category k)
        {
            c.Categories.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}