using System;
using System.Collections.Generic;
using System.Text;
using UniversityManage.Data.Interfaces;
using UniversityManage.Model;

namespace UniversityManage.Data.Services
{
    public class DepartmentsService : IDepartmentsService
    {
        IUnitofWork _unitofWork;
        public DepartmentsService(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public void DeleteDepartmentService(Department department)
        {
            try
            {
                _unitofWork._departmentsRepo.DeleteDepartmentRepo(department);
                _unitofWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception("Deletion Failed :" + e.StackTrace);
            }
        }

        public IEnumerable<Department> GetAllDepartmentsService()
        {
            try
            {
                return _unitofWork._departmentsRepo.GetAllDepartmentsRepo();
            }
            catch (Exception e)
            {
                throw new Exception("Fetching error:"+ e.StackTrace);
            }
        }

        public Department GetDepartmentService(int id)
        {
            try
            {
                return _unitofWork._departmentsRepo.GetDepartmentRepo(id);
            }
            catch (Exception e)
            {
                throw new Exception("Fetching error:" + e.StackTrace);
            }
        }

        public void InsertDepartmentService(Department department)
        {
            try
            {
                _unitofWork._departmentsRepo.InsertDepartmentRepo(department);
                _unitofWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception("Insertion Failed:" + e.StackTrace);
            }
        }

        public void UpdateDepartmentService(Department department)
        {
            try
            {
                _unitofWork._departmentsRepo.UpdateDepartmentRepo(department);
                _unitofWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception("Updating failed:" + e.StackTrace);
            }
        }
    }
}
