using System;
using System.Collections.Generic;
using System.Text;
using UniversityManage.Data.Interfaces;
using UniversityManage.Model;

namespace UniversityManage.Data.Services
{
    public class StudentCourseService : IStudentCourseService
    {
        IUnitofWork _unitofWork;
        public StudentCourseService(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public void DeleteStudentCourseService(StudentCourse studentCourse)
        {
            try
            {
                _unitofWork._studentCourseRepo.DeleteStudentCourseRepo(studentCourse);
                _unitofWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception("Error "+e.Message);
            }
        }

        public IEnumerable<StudentCourse> GetStudentCourseService(int studentid)
        {
            try
            {
                return _unitofWork._studentCourseRepo
                    .GetStudentCourseRepo(studentid);
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }

        public StudentCourse GetStudentCourseService(int studentid, int courseid)
        {
            try
            {
                return _unitofWork._studentCourseRepo
                    .GetStudentCourseRepo(studentid, courseid);
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }

        public IEnumerable<StudentCourse> GetStudentCoursesService()
        {
            try
            {
                return _unitofWork._studentCourseRepo
                    .GetStudentCoursesRepo();
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }

        public void InsertStudentCourseService(StudentCourse studentCourse)
        {
            try
            {
                _unitofWork._studentCourseRepo
                    .InsertStudentCourseRepo(studentCourse);
                _unitofWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }

        public void UpdateStudentCourseService(StudentCourse studentCourse)
        {
            try
            {
                _unitofWork._studentCourseRepo
                    .UpdateStudentCourseRepo(studentCourse);
                _unitofWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }
    }
}
