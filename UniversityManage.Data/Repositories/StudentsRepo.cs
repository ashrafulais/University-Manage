using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityManage.Data.Interfaces;
using UniversityManage.Model;

namespace UniversityManage.Data.Repositories
{
    public class StudentsRepo : IStudentsRepo
    {
        public UniversityContext _context;
        public StudentsRepo(UniversityContext context)
        {
            _context = context;
        }

        public void DeleteStudentRepo(Student student)
        {
            _context.Students.Remove(student);
        }

        public List<Student> GetAllStudentsRepo()
        {
            return _context.Students.Take(30).ToList();
        }

        public Student GetStudentRepo(int id)
        {
            return _context.Students
                .Include(x => x.DepartmentStudent)
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public void InsertStudentRepo(Student student)
        {
            _context.Students.Add(student);
        }

        public void UpdateStudentRepo(Student student)
        {
            _context.Students.Update(student);
        }

    }
}
