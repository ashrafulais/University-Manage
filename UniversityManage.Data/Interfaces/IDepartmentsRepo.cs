using System;
using System.Collections.Generic;
using System.Text;
using UniversityManage.Model;

namespace UniversityManage.Data.Interfaces
{
    public interface IDepartmentsRepo
    {
        public IEnumerable<Department> GetAllDepartmentsRepo();
        public Department GetDepartmentRepo(int id);
        public void InsertDepartmentRepo(Department department);
        public void UpdateDepartmentRepo(Department department);
        public void DeleteDepartmentRepo(Department department);

    }
}
