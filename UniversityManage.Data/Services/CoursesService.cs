﻿using System;
using System.Collections.Generic;
using System.Text;
using UniversityManage.Data.Interfaces;
using UniversityManage.Model;

namespace UniversityManage.Data.Services
{
    public class CoursesService : ICoursesService
    {
        IUnitofWork _unitofWork;
        public CoursesService(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public void DeleteCourseService(Course course)
        {
            try
            {
                _unitofWork._coursesRepo.DeleteCourseRepo(course);
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        public Course GetCourseService(int id)
        {
            try
            {
                return _unitofWork._coursesRepo.GetCourseRepo(id);
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        public IEnumerable<Course> GetCoursesService()
        {
            try
            {
                return _unitofWork._coursesRepo.GetCoursesRepo();
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        public void InsertCourseService(Course course)
        {
            try
            {
                _unitofWork._coursesRepo.InsertCourseRepo(course);
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        public void UpdateCourseService(Course course)
        {
            try
            {
                _unitofWork._coursesRepo.UpdateCourseRepo(course);
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }
    }
}