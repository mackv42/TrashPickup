using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public double _pickupPrice;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
            _pickupPrice = 2.50;
        }
        // GET: Customer
        [Authorize(Roles = "Customer")]
        public ActionResult Index()
        {
            return RedirectToAction("Details");
        }


        // GET: Customer/Details/5
        [Authorize(Roles = "Customer,Employee")]
    
        public ActionResult Details(int? Id)
        {
            Customer customer = new Customer();
            if(Id == null)
            {
                string find = User.Identity.GetUserId();
                customer = _context.Customers.Where(x => x.ApplicationId == find).FirstOrDefault();
                return View(customer);
            }
            customer = _context.Customers.Where(x => x.Id == Id).FirstOrDefault();
            return View(customer);
        }

        // GET: Customer/Create
        
        [Authorize(Roles = "Customer")]
        public ActionResult Create()
        {
            string find = User.Identity.GetUserId();
            Customer customer = _context.Customers.Where(x => x.ApplicationId == find).FirstOrDefault();
            if(customer != null)
            {
                return RedirectToAction("Index", "Customer");
            }
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer c)
        {
            try { 
                c.ApplicationId = User.Identity.GetUserId();
                if (String.IsNullOrEmpty(c.Address)|
                    String.IsNullOrEmpty(c.State)|
                    String.IsNullOrEmpty(c.Zip))
                {
                    return RedirectToAction("Create", "Customer");
                }
                ApplicationUser user = _context.Users.Where(x=>x.Id ==c.ApplicationId).FirstOrDefault();
                user.UserRole = _context.Roles.Where(x => x.Name == "Customer").FirstOrDefault().Name;
                
                c.pickupDay = null;
                c.OneTimePickup = null;
                c.suspendEnd = null;
                c.suspendEnd = null;
                _context.Customers.Add(c);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [Authorize(Roles = "Customer")]
        public ActionResult EditPickup()
        {
            string find = User.Identity.GetUserId();
            Customer customer = _context.Customers.Where(x => x.ApplicationId == find).FirstOrDefault();
            return View(customer);
        }

        [Authorize(Roles ="Customer")]
        [HttpGet]
        public ActionResult GetPayment(Customer customer)
        {
            string find = User.Identity.GetUserId();
            Customer found = _context.Customers.Where(x => x.ApplicationId == find).FirstOrDefault();

            return View(found);
        }


        //Payments happen every 4weeks after first pickup
        [Authorize(Roles = "Customer")]
        [HttpPost]
        public ActionResult EditPickup(Customer customer)
        {
            string find = User.Identity.GetUserId();
            Customer found = _context.Customers.Where(x => x.ApplicationId == find).FirstOrDefault();
            found.pickupDay = customer.pickupDay;
            found.OneTimePickup = customer.OneTimePickup;
            found.suspendEnd = customer.suspendEnd;
            found.suspendStart = customer.suspendStart;

            DateTime today = DateTime.Now;
            int difference = (int)found.pickupDay - (int)today.DayOfWeek;
            if(difference < 0)
            {
                difference = difference + 7;
            }
            found.paymentDue = 4 * _pickupPrice;
            found.paymentDay = today.AddDays(difference+28); 
            
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //[Authorize(Roles = "Admin")]

        // GET: Customer/Edit/5
        [Authorize(Roles = "Customer")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [Authorize(Roles = "Customer")]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        [Authorize(Roles = "Customer")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [Authorize(Roles = "Customer")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
