using QuickFix_V1.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Windows.Forms;

namespace QuickFix_V1.Controllers
{
    public class DriverController : Controller
    {
        // GET: Driver

        ApplicationDBContext _context = new ApplicationDBContext();
        int tempo;
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
        public ActionResult Create(Driver driver)
        {
            
                if (ModelState.IsValid)
                {
                    var existingdriver = _context.Drivers.Where(temp => temp.Username == driver.Username).FirstOrDefault();
                    if (existingdriver == null)
                    {
                        _context.Drivers.Add(driver);
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
           
            
              //return View();
        }

        public ActionResult PlaceOrder()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PlaceOrder(servicerequired sat)
        {
            int p=sat.GarageId;
            if (ModelState.IsValid)
            {
                _context.Servicerequireds.Add(sat);
                _context.SaveChanges();
                return View();
            }
            else
            {
                return View();
            }
        }

        public ActionResult listGarages()
        {
            var gars = _context.Garages.ToList();
            return View(gars);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(Driver driver)
        {

            try
            {
                var user = _context.Drivers.Single(temp => temp.Username == driver.Username && temp.Password == driver.Password);

                if (driver != null)
                {
                    Session["UserID"] = driver.Userid;
                    tempo = Convert.ToInt32(Session["UserID"]);
                    Session["Userid"] = driver.Userid.ToString();
                    Session["Username"] = driver.Username.ToString();
                    tempo = user.Userid;
                    string str = "Loggedin/" + tempo.ToString();
                    return RedirectToAction(str);

                }
                else
                {
                    ModelState.AddModelError("", "Username or  password is wrong");
                }
            }
            catch(InvalidOperationException )
            {
                MessageBox.Show("IncorrecUsername or Password");
            }


            return View();
        }
        public ActionResult Loggedin(int id)
        {
            if (Session["Userid"] != null)
            {
                int temporary = id;
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
            Driver Driver = _context.Drivers.Find(id);
            return View(Driver);

        }
        [HttpPost]
        public ActionResult Edit(Driver driver)
        {
            try {

                if (ModelState.IsValid)
                {
                    _context.Entry(driver).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction("Index");

                }
                return View(driver);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            Driver Driver = _context.Drivers.Find(id);
            return View(Driver);
        }
       [ HttpPost ]
        public ActionResult Delete(int id, Form form)
        {
            try
            {
                Driver driver = new Driver();
                if (ModelState.IsValid)
                {
                    driver = _context.Drivers.Find(id);
                    if(driver==null)
                    {
                        return HttpNotFound();
                    }
                    _context.Drivers.Remove(driver);
                    _context.SaveChanges();
                }
                return View(driver);
                 

                    
            }
            catch
            {
                return View();
            }
           
        }
        public ActionResult view(int id)
        {
            Driver Driver = _context.Drivers.Find(id);
            if(Driver ==null)
            {
                return HttpNotFound();
            }
            return View(Driver);
        }
        public ActionResult Saver(servicerequired s)
        {
            _context.Servicerequireds.Add(s);
            _context.SaveChanges();
            return View("Index");
        }
        public ActionResult DiPaymentLog()
        {
            var p = _context.PaymentLogs.ToList();
            return View(p);
        }
    }
}