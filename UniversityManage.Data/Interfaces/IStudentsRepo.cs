using System;
using System.Collections.Generic;
using System.Text;
using UniversityManage.Model;

namespace UniversityManage.Data.Interfaces
{
    public interface IStudentsRepo : IGenericRepository<Student>
    {
        public List<Student> GetAllStudentsRepo();
        public Student GetStudentRepo(int id);
        public void InsertStudentRepo(Student student);
        public void UpdateStudentRepo(Student student);
        public void DeleteStudentRepo(Student student);
    }
}
