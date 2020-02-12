using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityManage.Data.Interfaces;
using UniversityManage.Model;

namespace UniversityManage.Controllers
{
    public class CoursesController : Controller
    {
        ICoursesService _coursesService;
        public CoursesController(ICoursesService coursesService)
        {
            _coursesService = coursesService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllCourses()
        {
            try
            {
                return Json(GetCoursesData());
            }
            catch (Exception e)
            {
                return View("Error", new ErrorViewModel { RequestId = e.Message });
            }
        }

        [HttpGet("GetCoursesData")]
        public object GetCoursesData()
        {
            int total = 0, totalFiltered = 0;
            var records = _coursesService.GetCoursesService();

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (
                    from record in records
                    select new string[]
                    {
                        record.Id.ToString(),
                        record.Code,
                        record.Name,
                        record.Instructors.Name,
                        record.Id.ToString()
                    }
                ).ToArray()
            };
        }

        [HttpGet]
        public IActionResult ViewCourse(int id)
        {
            try
            {
                Course course = _coursesService.GetCourseService(id);
                return View(course);
            }
            catch (Exception e)
            {
                return View("Error", new ErrorViewModel { RequestId = e.Message });
            }
        }
    }
}