using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext _context;
        public EmployeeController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Employee
        [Authorize(Roles = "Employee")]
        public ActionResult Index()
        {
            return RedirectToAction("CustomerList");
        }

        public ActionResult CustomerList(DayOfWeek? day)
        {
            string find = User.Identity.GetUserId();
            Employee employee = _context.Employees.Where(x => x.ApplicationId == find).FirstOrDefault();
            List<Customer> Customers = _context.Customers.Where(x => x.Zip == employee.Zip).ToList();
            Customers = Customers.Where(x => x.pickupDay != null).ToList();
            string dayofWeek = Request.QueryString["testSelect"];

            if (!String.IsNullOrEmpty(dayofWeek))
            {
                Customers = Customers.Where(x => x.pickupDay == (byte?)Int32.Parse(dayofWeek)).ToList();
            }
            else
            {
                
                byte? todaysDayOfWeek = (byte?)DateTime.Now.DayOfWeek;
                Customers = Customers.Where(x => x.pickupDay == todaysDayOfWeek).ToList();
            }

            return View(Customers); 
        }

        // GET: Employee/Details/5
        [Authorize(Roles = "Employee")]
        public ActionResult Details()
        {
            string find = User.Identity.GetUserId();
            Employee employee = _context.Employees.Where(x => x.ApplicationId == find).FirstOrDefault();

            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            string find = User.Identity.GetUserId();
            Employee Employee = _context.Employees.Where(x => x.ApplicationId == find).FirstOrDefault();
            if(Employee != null)
            {
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }

        
        //[Authorize (Roles="Employee")]
        public ActionResult CustomerDetails(int? id)
        {
            Response.AppendHeader("Access-Control-Allow-Origin", "*");
            var a = _context.Customers.Where(x => x.Id == id).FirstOrDefault();
            return View(a);
        }

        [HttpPost]
        [Authorize(Roles = "Employee")]
        public ActionResult ConfirmPickup(int? Id)
        {
            Customer found = _context.Customers.Where(x => x.Id == Id).FirstOrDefault();
            found.paymentDue += found.pickupPrice;
            _context.SaveChanges();
            return RedirectToAction("CustomerList", 1);
        }

        // POST: Employee/Create

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                employee.ApplicationId = User.Identity.GetUserId();
                if (String.IsNullOrEmpty(employee.Address) |
                    String.IsNullOrEmpty(employee.State) |
                    String.IsNullOrEmpty(employee.Zip))
                {
                    return RedirectToAction("Create", "Employee");
                }
                ApplicationUser user = _context.Users.Where(x => x.Id == employee.ApplicationId).FirstOrDefault();
                user.UserRole = _context.Roles.Where(x => x.Name == "Customer").FirstOrDefault().Name;

                
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Employee/Edit/5
        [Authorize(Roles = "Employee")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [Authorize(Roles = "Employee")]
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

        // GET: Employee/Delete/5
        [Authorize(Roles = "Employee")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [Authorize(Roles = "Employee")]
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
