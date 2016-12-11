using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamSkillProject.Models;
using ExamSkillProject.DAL;

namespace ExamSkillProject.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        //Hello from Alpar
        //hello from roni
        //hello from Alpar 
       
        private List<Skills> Skills = new List<Skills>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ShowAllSkill()
        {            
            if (Skills.Count < 1)
            {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("CreateSkill");  
                }
                return View();              
            }
            Skills = this.db.Skills.ToList();
            return View(Skills);
           
        }

        public ActionResult SkillDetails(int id)
        {
            Skills skill = this.db.Skills.Find(id);
            return View(skill);
        }

        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View("CreateSkill");

        }
        [HttpPost]
        public ActionResult CreateSkill(Skills skills)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateSkill", skills);
            }
           
            this.db.Skills.Add(skills);
            db.SaveChanges();
            Skills = this.db.Skills.ToList();
            return View("CreateSkill");
        }
    }
}