namespace ExamSkillProject.Models
{
    
    using System.Collections.Generic;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Assignment
    {
        public int AssignmentId { get; set; }
        public string UserId { get; set; }
        public int SkillId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}