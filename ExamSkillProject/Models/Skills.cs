using System;
using System.Data.Entity;
using System.Linq;

namespace ExamSkillProject.Models
{

    public class Skills : DbContext
    {
        public int SkillsId { get; set; }

        public string SkillsName { get; set; }

        public int SkillsPoints { get; set; }

        public string SkillsDescription { get; set; }



        // Your context has been configured to use a 'Skill' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ExamSkillProject.Models.Skill' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Skill' 
        // connection string in the application configuration file.
        public Skills()
            : base("name=Skill")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}