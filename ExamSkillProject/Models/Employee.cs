using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamSkillProject.Models
{
    public class Employee
    {
        public int EmployeeID { get; set;}
        public string FirstName { get; set;}
        public string LastName{ get; set;}
        public string Passwrod { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }
        public Company company { get; set; }
   
    }
}