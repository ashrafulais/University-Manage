using System;
using System.Collections.Generic;
using System.Text;
using UniversityManage.Model;

namespace UniversityManage.Data.Interfaces
{
    public interface IStudentCourseRepo
    {
        public IEnumerable<StudentCourse> GetStudentCoursesRepo();
        public IEnumerable<StudentCourse> GetStudentCourseRepo(int studentid);
        public StudentCourse GetStudentCourseRepo(int studentid, int courseid);
        public void InsertStudentCourseRepo(StudentCourse studentCourse);
        public void UpdateStudentCourseRepo(StudentCourse studentCourse);
        public void DeleteStudentCourseRepo(StudentCourse studentCourse);

    }
}
