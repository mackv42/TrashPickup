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
            return RedirectToAction("Details");
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
