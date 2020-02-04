using System;
using System.Collections.Generic;
using System.Text;
using UniversityManage.Data.Interfaces;

namespace UniversityManage.Data
{
    public interface IUnitofWork
    {
        public IDepartmentsRepo _departmentsRepo { get; set; }
        public IStudentsRepo _studentsRepo { get; set; }

        public void Save();
    }
}
