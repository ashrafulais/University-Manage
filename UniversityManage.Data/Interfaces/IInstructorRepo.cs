using System;
using System.Collections.Generic;
using System.Text;
using UniversityManage.Model;

namespace UniversityManage.Data.Interfaces
{
    public interface IInstructorRepo
    {
        public Instructor GetInstructorRepo(int id);
        public IEnumerable<Instructor> GetInstructorsRepo();
        public void InsertInstructorRepo(Instructor instructor);
        public void UpdateInstructorRepo(Instructor instructor);
        public void DeleteInstructorRepo(Instructor instructor);

    }
}
