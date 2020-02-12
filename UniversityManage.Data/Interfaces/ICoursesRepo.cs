using System;
using System.Collections.Generic;
using System.Text;
using UniversityManage.Model;

namespace UniversityManage.Data.Interfaces
{
    public interface ICoursesRepo
    {
        public Course GetCourseRepo(int id);
        public IEnumerable<Course> GetCoursesRepo();
        public void InsertCourseRepo(Course course);
        public void UpdateCourseRepo(Course course);
        public void DeleteCourseRepo(Course course);

    }
}
