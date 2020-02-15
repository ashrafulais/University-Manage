using System;
using System.Collections.Generic;
using System.Text;
using UniversityManage.Model;

namespace UniversityManage.Data.Interfaces
{
    public interface ICoursesService
    {
        public Course GetCourseService(int id);
        public IEnumerable<Course> GetCoursesService();
        public void InsertCourseService(Course course);
        public void UpdateCourseService(Course course);
        public void DeleteCourseService(int id);
    }
}
