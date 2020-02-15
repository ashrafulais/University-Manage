using System;
using System.Collections.Generic;
using System.Text;
using UniversityManage.Model;

namespace UniversityManage.Data.Interfaces
{
    public interface IDepartmentsService
    {
        public IEnumerable<Department> GetAllDepartmentsService();
        public Department GetDepartmentService(int id);
        public void InsertDepartmentService(Department department);
        public void UpdateDepartmentService(Department department);
        public void DeleteDepartmentService(int id);
    }
}
