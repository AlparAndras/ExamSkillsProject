using ExamSkillProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamSkillProject.Controllers
{
    public class EmployeeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        private List<Employee> employees = new List<Employee>();   



        // GET: Employee
        public ActionResult Index()
        {
            
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindById(User.Identity.GetUserId());

            if (user.CompanyId != 0) {
                return View(db.Users.Where(i => i.CompanyId == user.CompanyId));
            }

            return View();

        }

        // GET: Employee/Details/5
        public ActionResult Details(string id)
        {
            ApplicationUser employee = db.Users.Find(id);
            return View(employee);
        }


        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(ApplicationUser employee)
        {



            if (ModelState.IsValid)
            {
                UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                var user = userManager.FindById(User.Identity.GetUserId());

                ApplicationUser newUser = new ApplicationUser {
                    UserName = employee.Email,
                    Email = employee.Email,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    CompanyId = user.CompanyId
                };
                string password = System.Web.Security.Membership.GeneratePassword(10, 1);

                userManager.Create(newUser, password);
                return Content(password);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create");
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
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
