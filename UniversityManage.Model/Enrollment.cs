using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityManage.Model
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student StudentsEnrollment { get; set; }

        public int CourseId { get; set; }
        public Course CoursesEnrollment { get; set; }

    }
}
