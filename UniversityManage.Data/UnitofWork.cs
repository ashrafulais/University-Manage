using System;
using System.Collections.Generic;
using System.Text;
using UniversityManage.Data.Interfaces;
using UniversityManage.Data.Repositories;

namespace UniversityManage.Data
{
    public class UnitofWork : IUnitofWork
    {
        public IDepartmentsRepo _departmentsRepo { get; set; }
        public IStudentsRepo _studentsRepo { get; set; }
        public ICoursesRepo _coursesRepo { get; set; }
        public IInstructorRepo _instructorRepo { get; set; }

        public UniversityContext _context;

        public UnitofWork(string conn, string mig)
        {
            _context = new UniversityContext(conn, mig);
            _departmentsRepo = new DepartmentsRepo(_context);
            _studentsRepo = new StudentsRepo(_context);
            _coursesRepo = new CoursesRepo(_context);
            _instructorRepo = new InstructorRepo(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
