using MvcTicariOtomasyon.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departments.ToList();
            return View(degerler);
        }
    }
}