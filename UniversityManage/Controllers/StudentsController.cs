using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityManage.Data.Interfaces;
using UniversityManage.Model;

namespace UniversityManage.Controllers
{
    public class StudentsController : Controller
    {
        IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllStudents()
        {
            try
            {
                return Json(GetDatabaseData());
            }
            catch (Exception e)
            {
                return View("Error", new ErrorViewModel { RequestId = e.Message });
            }
        }

        [ActionName("GetDatabaseData")]
        public object GetDatabaseData()
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

        [HttpGet()]
        public IActionResult ViewStudent(int id)
        {
            try
            {
                Student student = _studentsService
                    .GetStudentService(id);
                return View(student);
            }
            catch (Exception e)
            {
                return View("Error", new ErrorViewModel { RequestId = e.Message });
            }
        }
    }
}