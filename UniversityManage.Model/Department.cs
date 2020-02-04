using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversityManage.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public decimal Budget { get; set; }

        public IEnumerable<Student> StudentsDepartment { get; set; }
        [NotMapped]
        public IEnumerable<Instructor> InstructorsDepartment { get; set; }
    }
}
