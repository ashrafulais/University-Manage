using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityManage.Data.Interfaces;
using UniversityManage.Model;

namespace UniversityManage.Data.Repositories
{
    public class DepartmentsRepo : IDepartmentsRepo
    {
        UniversityContext _context;
        public DepartmentsRepo(UniversityContext context)
        {
            _context = context;
        }

        public void DeleteDepartmentRepo(Department department)
        {
            _context.Departments.Remove(department);
        }

        public IEnumerable<Department> GetAllDepartmentsRepo()
        {
            return _context.Departments.ToList();
        }

        public Department GetDepartmentRepo(int id)
        {
            return _context.Departments.Where(x => x.Id == id).FirstOrDefault();
        }

        public void InsertDepartmentRepo(Department department)
        {
            _context.Departments.Add(department);
        }

        public void UpdateDepartmentRepo(Department department)
        {
            _context.Departments.Update(department);
        }
    }
}
