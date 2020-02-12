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
        public int InstructorId { get; set; }
        public Department Departments { get; set; }
        public Instructor Instructors { get; set; }
        public IEnumerable<StudentCourse> StudentCourses { get; set; }
    }
}
