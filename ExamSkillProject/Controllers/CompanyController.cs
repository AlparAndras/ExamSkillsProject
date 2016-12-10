using ExamSkillProject.DAL;
using ExamSkillProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamSkillProject.Controllers
{
    public class CompanyController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Company
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Company company)
        {
            Company newCom = new Company();
            newCom.Address = "12asd";
            newCom.Name = "Nafddsf";

            db.Companies.Add(newCom);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}