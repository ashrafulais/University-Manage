using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UniversityManage.Model
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public Student Students { get; set; }

        public int CourseId { get; set; }
        public Course Courses { get; set; }

    }
}
