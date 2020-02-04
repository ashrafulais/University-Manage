using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityManage.Model
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateofBirth { get; set; }

        public int DepartmentId { get; set; }
        public Department DepartmentInstructor { get; set; }

        public decimal Salary { get; set; }
        public DateTime DateofRegistration { get; set; }
        public IEnumerable<Student> StudentsInstructor { get; set; }
    }
}
