using ExamSkillProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamSkillProject.Controllers
{
    public class SkillController : Controller
    {
        private UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        private ApplicationDbContext db = new ApplicationDbContext();
        private List<Skill> Skills = new List<Skill>();
        // GET: CretaeSkill
        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View("CreateSkill"); 
        }
        // Post: CretaeSkill
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult CreateSkill(Skill skill)
        {
            
            if (ModelState.IsValid)
            {
                 if (Request.Files.Count > 0)
                {
                        HttpPostedFileBase skillFile = Request.Files[0];
                        if (skillFile.ContentLength > 0)
                            {                                
                                var fileName = Path.GetFileName(skillFile.FileName);
                                skill.SkillIcon = Path.Combine(Server.MapPath("~/UploadedFiles"), fileName);
                                skillFile.SaveAs(skill.SkillIcon);                                
                            }
                        ApplicationUser currentUser = db.Users.Find(User.Identity.GetUserId());
                        skill.CompanyId = currentUser.CompanyId;
                        Company currentCompany = db.Companies.Where(i => i.CompanyId == currentUser.CompanyId).First();
                        this.db.Skill.Add(skill);
                        db.SaveChanges();
                        Skills = this.db.Skill.ToList();
                        return RedirectToAction("SkillDetails", new { id = skill.SkillId });
                 }
            }
            return View("CreateSkill", skill);
        }
 
        public ActionResult ShowAllSkills()
        {
            Skills = this.db.Skill.ToList();
            if (Skills.Count < 1)
            {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("CreateSkill");
                }
                return View(Skills);
            }
            Skills = this.db.Skill.ToList();
            return View(Skills);

        }
        public ActionResult SkillDetails(int id)
        {
            Skill skill = this.db.Skill.Find(id);
            return View(skill);
        }

    }
}