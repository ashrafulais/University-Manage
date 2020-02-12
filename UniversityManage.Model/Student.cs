using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversityManage.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public DateTime DateofBirth { get; set; }
        public int DepartmentId { get; set; }
        //public DateTime DateofRegistration { get; set; }

        public Department Departments { get; set; }

        [NotMapped]
        public IEnumerable<StudentCourse> StudentCourses { get; set; }
    }
}
