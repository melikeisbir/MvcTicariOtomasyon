﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class ToDoListController : Controller
    {
        // GET: ToDoList
        public ActionResult Index()
        {
            return View();
        }
    }
}