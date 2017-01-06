﻿using ExamSkillProject.Models;
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
        private List<Assignment> Assignments = new List<Assignment>();

        // GET: CretaeSkill
        [Authorize(Roles = "Admin")]
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
                        this.db.Skill.Add(skill);
                        db.SaveChanges();
                        var user = userManager.FindById(User.Identity.GetUserId());
                        List<ApplicationUser> users = new List<ApplicationUser>();
                        users = new List<ApplicationUser>(db.Users.Where(i => i.CompanyId == user.CompanyId)); 
                        Assignments = this.db.Assignment.ToList();
                        return RedirectToAction("SkillDetails", new { id = skill.SkillId, users = users, assignments = Assignments });
                 }
            }
            return View("CreateSkill", skill);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteSkill(int skillId)
        {
            Skill skill = this.db.Skill.Find(skillId);
            this.db.Skill.Remove(skill);
            List<Assignment> expiredBySkillDelete = new List<Assignment>();
            foreach (var assignment in Assignments)
            {
             if(assignment.SkillId == skill.SkillId)
               {
               if(assignment.EndDate > DateTime.Now)
               {
                 assignment.EndDate = DateTime.Now;

               }
               }
              } 

            this.db.SaveChanges();
            Skills = this.db.Skill.ToList();
            return View("ShowAllSkills", Skills);
        }
        //Show All Skills
        public ActionResult ShowAllSkills()
        {
            var user = userManager.FindById(User.Identity.GetUserId());
            Skills = this.db.Skill.ToList();
            List<Skill> companySkills = new List<Skill>();
            foreach (var skill in Skills)
            {
                if (skill.CompanyId == user.CompanyId)
                {
                    companySkills.Add(skill);
                    if (Skills.Count < 1)
                    {
                        if (User.IsInRole("Admin"))
                        {
                            return RedirectToAction("CreateSkill");
                        }
                        return View(companySkills);
                    }
                }
            }
            
            return View(companySkills);

        }
        public ActionResult SkillDetails(int id, List<ApplicationUser> users = null, List<Assignment> assignments = null)
        {
            Skill skill = this.db.Skill.Find(id);
            assignments = this.db.Assignment.ToList();
            var user = userManager.FindById(User.Identity.GetUserId());
            users = new List<ApplicationUser>(db.Users.Where(i => i.CompanyId == user.CompanyId));
            //Tuple<int, string, bool> tuple = new Tuple<int, string, bool>(1, "cat", true);
            Tuple<Skill, List<ApplicationUser>, List<Assignment>> tuple = new Tuple<Skill, List<ApplicationUser>, List<Assignment>>(skill, users, assignments);
            return View(tuple);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult AssignSkill(Assignment assignment, string userId, int skillId)
        {
            assignment.UserId = userId;
            assignment.SkillId = skillId;
            assignment.StartDate = DateTime.Now;
            assignment.EndDate = DateTime.Now.AddMonths(11);
            this.db.Assignment.Add(assignment);
            db.SaveChanges();
            Skill skill = this.db.Skill.Find(skillId);
            var user = userManager.FindById(User.Identity.GetUserId());
            List<ApplicationUser> Users = new List<ApplicationUser>();
            Users = new List<ApplicationUser>(db.Users.Where(i => i.CompanyId == user.CompanyId)); 
            Assignments = this.db.Assignment.ToList();
            //List<ApplicationUser> unassignedUsers = new List<ApplicationUser>();
            //var query =
            //    from unassignedUser in db.Users
            //     where unassignedUser.CompanyId == user.CompanyId
            //     join currentAssignments in db.Assignment on unassignedUser.Id equals currentAssignments.UserId
            //     where currentAssignments.UserId != unassignedUser.Id || currentAssignments.EndDate < DateTime.Now
            //     select  unassignedUser;
            //unassignedUsers = query.ToList<ApplicationUser>();
          return RedirectToAction("SkillDetails", new { id = skillId, users = Users, assignments = Assignments});
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Unassign(int skillId, int assignmentId)
        {
            
            Assignment assignment = this.db.Assignment.Find(assignmentId);
            this.db.Assignment.Remove(assignment);
            this.db.SaveChanges();
            var user = userManager.FindById(User.Identity.GetUserId());
            List<ApplicationUser> Users = new List<ApplicationUser>();
            Users = new List<ApplicationUser>(db.Users.Where(i => i.CompanyId == user.CompanyId));
            Assignments = this.db.Assignment.ToList();
            return RedirectToAction("SkillDetails", new { id = skillId, users = Users, assignments = Assignments }); 
        }

    }
}