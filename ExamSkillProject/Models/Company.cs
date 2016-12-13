﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamSkillProject.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Logo { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
}