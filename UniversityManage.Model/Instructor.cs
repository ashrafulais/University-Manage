using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityManage.Model
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int DepartmentId { get; set; }

        public decimal Salary { get; set; }

        public Department Departments { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
