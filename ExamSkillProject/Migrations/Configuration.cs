namespace ExamSkillProject.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ExamSkillProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExamSkillProject.Models.ApplicationDbContext context)
        {
            Company c = new Company { Name = "Apple", Description = "tete", Address = "Lygten 37" };
            context.Companies.Add(c);
            context.SaveChanges();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string role = "Admin";
            if (!roleManager.RoleExists(role))
            {
                var roleResult = roleManager.Create(new IdentityRole(role));
            }



        }
    }
}
