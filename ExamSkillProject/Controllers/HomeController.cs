using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamSkillProject.Models;
using Microsoft.AspNet.Identity;
using ExamSkillProject.Helpers;
using System.Data.Entity.Validation;

namespace ExamSkillProject.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult UserProfile()
        {
            ApplicationUser user = db.Users.Find(User.Identity.GetUserId());
            return View(user);
        }

        [HttpGet]
        [Authorize]
        public ActionResult EditProfile()
        {
            ApplicationUser currentuser = db.Users.Find(User.Identity.GetUserId());
            return View(currentuser);
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditProfile(CreateEmployeeViewModel model, HttpPostedFileBase file)
        {

            ApplicationUser dbUser = db.Users.Find(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {

                FileUpload FileUploader = new FileUpload();
                string result = FileUploader.Upload(model.Email, file);
                if (result != null)
                {
                    dbUser.Picture = result;
                }

                dbUser.FirstName = model.FirstName;
                dbUser.LastName = model.LastName;
                dbUser.Email = model.Email;
                dbUser.UserName = model.Email;

                db.SaveChanges();

                return View("UserProfile", dbUser);

            }
            return View(dbUser);

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

    }
}