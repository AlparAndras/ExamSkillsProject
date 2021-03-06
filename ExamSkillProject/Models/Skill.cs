﻿using System;
using System.Data.Entity;
using System.Linq;

namespace ExamSkillProject.Models
{

    public class Skill
    {
        public int SkillId { get; set; }

        public string SkillIcon { get; set; }

        public string SkillName { get; set; }

        public int SkillPoints { get; set; }

        public string SkillDescription { get; set; }

        public int CompanyId { get; set; }

   


        // Your context has been configured to use a 'Skill' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ExamSkillProject.Models.Skill' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Skill' 
        // connection string in the application configuration file.
    
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