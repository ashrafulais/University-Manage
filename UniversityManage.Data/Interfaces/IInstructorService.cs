using System;
using System.Collections.Generic;
using System.Text;
using UniversityManage.Model;

namespace UniversityManage.Data.Interfaces
{
    public interface IInstructorService
    {
        public Instructor GetInstructor(int id);
        public IEnumerable<Instructor> GetInstructors();
        public void InsertInstructor(Instructor instructor);
        public void UpdateInstructor(Instructor instructor);
        public void DeleteInstructor(Instructor instructor);
    }
}
