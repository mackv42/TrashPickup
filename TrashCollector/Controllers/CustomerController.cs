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
        public CustomerController()
        {
            _context = new ApplicationDbContext();
           
        }
        // GET: Customer
        [Authorize(Roles = "Customer")]
        public ActionResult Index()
        {
            string find = User.Identity.GetUserId();
            Customer c = _context.Customers.Where(x => x.ApplicationId == find).FirstOrDefault();
            return View(c);
        }


        // GET: Customer/Details/5
        [Authorize(Roles = "Customer")]
        public ActionResult Details()
        {
            string find = User.Identity.GetUserId();
            Customer customer = _context.Customers.Where(x=>x.ApplicationId == find ).FirstOrDefault();
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
