using ExamSkillProject.DAL;
using ExamSkillProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ExamSkillProject.Controllers
{
    public class CompanyController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        private ApplicationDbContext db2 = new ApplicationDbContext();
        // GET: Company
        public ActionResult Index()
        {

             var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db2));
             var currentUser = userManager.FindById(User.Identity.GetUserId());

            if(currentUser.CompanyId == 0)
            {
                return View();
            }
            return View( db.Companies.Where( i => i.CompanyId == currentUser.CompanyId ).First());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Company company)
        {
            db.Companies.Add(company);
            db.SaveChanges();

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db2));
            var currentUser = userManager.FindById(User.Identity.GetUserId());

            currentUser.CompanyId = company.CompanyId;
            db2.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}