using ExamSkillProject.DAL;
using ExamSkillProject.Models;
using Microsoft.AspNet.Identity;
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

        // GET: Company
        public ActionResult Index( int companyId)
        {
            User.Identity.GetUserId();


            return View(db.Companies.Where(i => i.CompanyId == companyId).First());
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

            return RedirectToAction("Index");
        }
    }
}