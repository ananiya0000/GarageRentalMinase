using QuickFix_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace QuickFix_V1.Controllers
{
    public class GarageController : Controller
    {
        // GET: Garage
        int tempo;
        ApplicationDBContext _context = new ApplicationDBContext();
        public ActionResult Index(int id)
        {
            ViewBag.userid = id;
            return View();
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Garage garage)
        {

            if (ModelState.IsValid)
            {
                var existinggarage = _context.Garages.Where(temp=>temp.GarageName == garage.GarageName).FirstOrDefault();
                if (existinggarage == null)
                {
                    _context.Garages.Add(garage);
                    _context.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    MessageBox.Show("username should be unique");
                    return View();

                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(Garage garage)
        {
            try
            {
                var user = _context.Garages.Single(temp => temp.GarageName == garage.GarageName && temp.Password == garage.Password);

                if (garage != null)
                {
                    Session["UserID"] = garage.GarageId;
                    tempo = Convert.ToInt32(Session["UserID"]);
                    Session["Userid"] = garage.GarageId.ToString();
                    Session["Username"] = garage.GarageName.ToString();
                    tempo = user.GarageId;
                    string str = "Loggedin/" + tempo.ToString();
                    return RedirectToAction(str);

                }
                else
                {
                    ModelState.AddModelError("", "Username or  password is wrong");
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("IncorrecUsername or Password");
            }


            return View();
        }

        public ActionResult Loggedin(int id)
        {
            if (Session["Userid"] != null)
            {
                string str = "Index/" + id.ToString();
                return RedirectToAction(str);
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public ActionResult Edit(int id)
        {
            Garage garage = _context.Garages.Find(id);
            return View(garage);

        }
        [HttpPost]
        public ActionResult Edit(Garage garage)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _context.Entry(garage).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction("Index");

                }
                return View(garage);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            Garage garage = _context.Garages.Find(id);
            return View(garage);
        }
        [HttpPost]
        public ActionResult Delete(int id, Form form)
        {
            try
            {
                Garage garage = new Garage();
                if (ModelState.IsValid)
                {
                    garage = _context.Garages.Find(id);
                    if (garage == null)
                    {
                        return HttpNotFound();
                    }
                    _context.Garages.Remove(garage);
                    _context.SaveChanges();
                }
                return View(garage);



            }
            catch
            {
                return View();
            }

        }
        public ActionResult view(int id)
        {
            Garage garage = _context.Garages.Find(id);
            if (garage == null)
            {
                return HttpNotFound();
            }
            return View(garage);
        }
        public ActionResult SRList(int id)
        {
            var sp = _context.Servicerequireds.Where(temp => temp.Userid == id).ToList();
            return View(sp);
        }
        public ActionResult CrPayment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CrPayment(PaymentLog p)
        {
            if (ModelState.IsValid)
            {
                _context.PaymentLogs.Add(p);
                _context.SaveChanges();
            }
            return View();
        }
    }
}