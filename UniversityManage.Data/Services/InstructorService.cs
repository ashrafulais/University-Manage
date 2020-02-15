using System;
using System.Collections.Generic;
using System.Text;
using UniversityManage.Data.Interfaces;
using UniversityManage.Model;

namespace UniversityManage.Data.Services
{
    public class InstructorService : IInstructorService
    {
        IUnitofWork _unitofWork;
        public InstructorService(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public void DeleteInstructor(int id)
        {
            try
            {
                _unitofWork._instructorRepo.DeleteInstructorRepo(
                    _unitofWork._instructorRepo.GetInstructorRepo(id));
                _unitofWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        public Instructor GetInstructor(int id)
        {
            try
            {
                return _unitofWork._instructorRepo.GetInstructorRepo(id);
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        public IEnumerable<Instructor> GetInstructors()
        {
            try
            {
                return _unitofWork._instructorRepo.GetInstructorsRepo();
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        public void InsertInstructor(Instructor instructor)
        {
            try
            {
                _unitofWork._instructorRepo.InsertInstructorRepo(instructor);
                _unitofWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        public void UpdateInstructor(Instructor instructor)
        {
            try
            {
                _unitofWork._instructorRepo.UpdateInstructorRepo(instructor);
                _unitofWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }
    }
}
