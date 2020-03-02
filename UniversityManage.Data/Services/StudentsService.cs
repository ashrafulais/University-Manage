using System;
using System.Collections.Generic;
using System.Text;
using UniversityManage.Data.Interfaces;
using UniversityManage.Model;

namespace UniversityManage.Data.Services
{
    public class StudentsService : IStudentsService
    {
        IUnitofWork _unitofWork;
        public StudentsService(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public void DeleteStudentService(Student student)
        {
            try
            {
                _unitofWork._studentsRepo.DeleteStudentRepo(student);
                _unitofWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        public List<Student> GetAllStudentsService()
        {
            try
            {
                //Using Generics
                return _unitofWork._studentsRepo
                    .GetAllData();
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        public Student GetStudentService(int id)
        {
            try
            {
                return _unitofWork._studentsRepo.GetStudentRepo(id);
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        public void InsertStudentService(Student student)
        {
            try
            {
                _unitofWork._studentsRepo.InsertStudentRepo(student);
                _unitofWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        public void UpdateStudentService(Student student)
        {
            try
            {
                _unitofWork._studentsRepo.UpdateStudentRepo(student);
                _unitofWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

    }
}
