using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamSkillProject.Models;

namespace ExamSkillProject.Controllers
{
    public class HomeController : Controller
    {
        //Hello from Alpar
        //hello from roni
        //hello from Alpar 

        private SkillsContext db = new SkillsContext();
        private List<Skill> Skills = new List<Skill>();
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

        public ActionResult ShowAllSkills()
        {
            Skills = this.db.Skills.ToList();
            return View(Skills);
        }

        public ActionResult SkillDetails(int id)
        {
            Skill skill = this.db.Skills.Find(id);
            return View(skill);
        }

        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View("CreateSkill");

        }
        [HttpPost]
        public ActionResult Create(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateSkill", skill);
            }
           
            this.db.Skills.Add(skill);
            db.SaveChanges();
            Skills = this.db.Skills.ToList();
            return View("CreateSkill");
        }
    }
}