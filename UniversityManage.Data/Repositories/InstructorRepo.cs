using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityManage.Data.Interfaces;
using UniversityManage.Model;

namespace UniversityManage.Data.Repositories
{
    public class InstructorRepo : IInstructorRepo
    {
        UniversityContext _context;
        public InstructorRepo(UniversityContext context)
        {
            _context = context;
        }
        public void DeleteInstructorRepo(Instructor instructor)
        {
            _context.Instructors.Remove(instructor);
        }

        public Instructor GetInstructorRepo(int id)
        {
            return _context.Instructors
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Instructor> GetInstructorsRepo()
        {
            return _context.Instructors.Take(10).ToList();
        }

        public void InsertInstructorRepo(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
        }

        public void UpdateInstructorRepo(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
        }
    }
}
