using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityManage.Data.Interfaces;
using UniversityManage.Model;

namespace UniversityManage.Controllers
{
    public class InstructorsController : Controller
    {
        IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllInstructors()
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
            var records = _instructorService.GetInstructors();

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
        public IActionResult ViewInstructors(int id)
        {
            try
            {
                Instructor instructor = _instructorService.GetInstructor(id);
                return View(instructor);
            }
            catch (Exception e)
            {
                return View("Error", new ErrorViewModel { RequestId = e.Message });
            }
        }
    }
}