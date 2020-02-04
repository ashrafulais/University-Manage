using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityManage.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public int DepartmentId { get; set; }
        public Department DepartmentCourse { get; set; }
        public Instructor InstructorCourse { get; set; }
    }
}
