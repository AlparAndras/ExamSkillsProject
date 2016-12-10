using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExamSkillProject.Models
{
    public class SkillsContext: DbContext
    {
        public virtual DbSet<Skill> Skills { get; set; }
    }
}