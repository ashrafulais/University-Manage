using Autofac;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using UniversityManage.Data.Interfaces;
using UniversityManage.Model;

namespace UniversityManage.Areas.Admin.Models
{
    public class StudentViewModel
    {
        IDepartmentsService _departmentService;
        IStudentsService _studentsService;

        public StudentViewModel(IDepartmentsService departmentService,
            IStudentsService studentsService)
        {
            _departmentService = departmentService;
            _studentsService = studentsService;
        }

        public List<Department> GetDepartments()
        {
            return _departmentService
                .GetAllDepartmentsService()
                .ToList();
        }

        public object GetAllStudents()
        {
            try
            {
                return GetDatabaseData();
            }
            catch (Exception e)
            {
                throw new Exception("Error "+e.Message);
            }
        }

        [ActionName("GetDatabaseData")]
        private object GetDatabaseData()
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _studentsService.GetAllStudentsService();

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (from record in records
                        select new string[]
                        {
                                record.Id.ToString(),
                                record.Name,
                                record.DepartmentId.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        internal void InsertStudent(Student student)
        {
            _studentsService.InsertStudentService(student);
        }
    }
}
