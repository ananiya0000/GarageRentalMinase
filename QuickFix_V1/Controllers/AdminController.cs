using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuickFix_V1.Models;
using System.ComponentModel.DataAnnotations;

namespace QuickFix_V1.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        ApplicationDBContext _context = new ApplicationDBContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List_Garages()
        {
            var garage = _context.Garages.ToList();
            return View(garage);
        }

        public ActionResult List_Drivers()
        {
            var driver = _context.Drivers.ToList();
            return View(driver);
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}