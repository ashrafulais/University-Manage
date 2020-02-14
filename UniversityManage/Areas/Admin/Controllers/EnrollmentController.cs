using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityManage.Data.Interfaces;
using UniversityManage.Model;

namespace UniversityManage.Areas.Admin.Controllers
{
    [Area("admin")]
    public class EnrollmentController : Controller
    {
        IDepartmentsService _departmentService;
        IStudentsService _studentsService;
        public EnrollmentController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllEnrollments()
        {
            return View();
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

        public IActionResult AddEnrollment()
        {
            return View();
        }

        public IActionResult EditEnrollment()
        {
            return View();
        }

        public IActionResult DeleteEnrollment()
        {
            return View();
        }
    }
}