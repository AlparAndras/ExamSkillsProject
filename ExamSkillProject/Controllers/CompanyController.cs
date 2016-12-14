using ExamSkillProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ExamSkillProject.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

        // GET: Company
        public ActionResult Index()
        {

             var currentUser = userManager.FindById(User.Identity.GetUserId());

            if(currentUser.CompanyId == 0)
            {
                return View();
            }
            return View( db.Companies.Where( i => i.CompanyId == currentUser.CompanyId ).First());
        }

        [Authorize (Roles="Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Company company, HttpPostedFileBase file)
        {

            db.Companies.Add(company);
            db.SaveChanges();


            var currentUser = db.Users.Find(User.Identity.GetUserId());
            ApplicationUser newUser = db.Users.Find(User.Identity.GetUserId());

            newUser.CompanyId = company.CompanyId;
            newUser.Id = currentUser.Id;

            db.Entry(currentUser).CurrentValues.SetValues(newUser);

            db.SaveChanges();
           

            return View("Index", company);
        }

        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit()
        {
            return View( UserCompany() );
        }

        
        [HttpPost]
        public ActionResult Edit( Company company, HttpPostedFileBase file)
        { 
            Company dbCompany = UserCompany();
            company.CompanyId = dbCompany.CompanyId;
            db.Entry(dbCompany).CurrentValues.SetValues(company);
            db.SaveChanges();
            return View("Index", dbCompany);
        }



        private ApplicationUser CurrentUser()
        {
            ApplicationUser currentUser = userManager.FindById(User.Identity.GetUserId());
            return currentUser;
        }

        private Company UserCompany()
        {
            ApplicationUser currentUser = CurrentUser();
            Company currentCompany = db.Companies.Where(i => i.CompanyId == currentUser.CompanyId).First();
            return currentCompany;
        }
    }
}