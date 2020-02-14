using System;
using System.Collections.Generic;
using System.Text;
using UniversityManage.Model;

namespace UniversityManage.Data.Interfaces
{
    public interface IStudentCourseService
    {
        public IEnumerable<StudentCourse> GetStudentCoursesService();
        public IEnumerable<StudentCourse> GetStudentCourseService(int studentid);
        public StudentCourse GetStudentCourseService(int studentid, int courseid);
        public void InsertStudentCourseService(StudentCourse studentCourse);
        public void UpdateStudentCourseService(StudentCourse studentCourse);
        public void DeleteStudentCourseService(StudentCourse studentCourse);
    }
}
