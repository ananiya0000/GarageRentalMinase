using QuickFix_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickFix_V1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

    }
}