using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityManage.Data.Interfaces;
using UniversityManage.Model;

namespace UniversityManage.Data.Repositories
{
    public class StudentCourseRepo : IStudentCourseRepo
    {
        UniversityContext _context;
        public StudentCourseRepo(UniversityContext context)
        {
            _context = context;
        }
        public void DeleteStudentCourseRepo(StudentCourse studentCourse)
        {
            _context.StudentCourses.Remove(studentCourse);
        }

        public IEnumerable<StudentCourse> GetStudentCourseRepo(int studentid)
        {
            return _context.StudentCourses
                .Where(x => x.StudentId == studentid)
                .ToList();
        }

        public StudentCourse GetStudentCourseRepo(int studentid, int courseid)
        {
            return _context.StudentCourses
                .Where(x => x.StudentId == studentid && x.CourseId == courseid)
                .FirstOrDefault();
        }

        public IEnumerable<StudentCourse> GetStudentCoursesRepo()
        {
            return _context.StudentCourses.Take(10);
        }

        public void InsertStudentCourseRepo(StudentCourse studentCourse)
        {
            _context.StudentCourses.Add(studentCourse);
        }

        public void UpdateStudentCourseRepo(StudentCourse studentCourse)
        {
            _context.StudentCourses.Update(studentCourse);
        }
    }
}
