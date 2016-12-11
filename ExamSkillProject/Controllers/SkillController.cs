using ExamSkillProject.DAL;
using ExamSkillProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamSkillProject.Controllers
{
    public class SkillController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        private List<Skills> Skills = new List<Skills>();
        // GET: Skill
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