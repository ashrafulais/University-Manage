using System;
using System.Collections.Generic;
using System.Text;
using UniversityManage.Model;

namespace UniversityManage.Data.Interfaces
{
    public interface IStudentsService
    {
        public List<Student> GetAllStudentsService();
        public Student GetStudentService(int id);
        public void InsertStudentService(Student student);
        public void UpdateStudentService(Student student);
        public void DeleteStudentService(Student student);

    }
}
