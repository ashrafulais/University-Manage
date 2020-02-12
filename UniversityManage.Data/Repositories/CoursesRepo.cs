using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityManage.Data.Interfaces;
using UniversityManage.Model;

namespace UniversityManage.Data.Repositories
{
    public class CoursesRepo : ICoursesRepo
    {
        UniversityContext _context;
        public CoursesRepo(UniversityContext context)
        {
            _context = context;
        }

        public void DeleteCourseRepo(Course course)
        {
            _context.Courses.Remove(course);
        }

        public Course GetCourseRepo(int id)
        {
            return _context.Courses
                .Where(x => x.Id == id)
                .Include(x => x.Instructors)
                .FirstOrDefault();
        }

        public IEnumerable<Course> GetCoursesRepo()
        {
            return _context.Courses
                .Include(x => x.Instructors)
                .Take(10)
                .ToList();
        }

        public void InsertCourseRepo(Course course)
        {
            _context.Courses.Add(course);
        }

        public void UpdateCourseRepo(Course course)
        {
            _context.Courses.Update(course);
        }
    }
}
