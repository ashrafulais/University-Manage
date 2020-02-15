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
    public class CourseController : Controller
    {
        IInstructorService _instructorService;
        IDepartmentsService _departmentsService;
        ICoursesService _coursesService;
        public CourseController(IInstructorService instructorService,
        IDepartmentsService departmentsService,
        ICoursesService coursesService)
        {
            _instructorService = instructorService;
            _departmentsService = departmentsService;
            _coursesService = coursesService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllCourses()
        {
            return View();
        }

        public IActionResult AllCoursesData()
        {
            try
            {
                return Json(GetDatabaseData());
            }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View("Message");
            }
        }

        [ActionName("GetDatabaseData")]
        private object GetDatabaseData()
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _coursesService.GetCoursesService();

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (from record in records
                        select new string[]
                        {
                                record.Id.ToString(),
                                record.Code,
                                record.Name,
                                record.DepartmentId.ToString(),
                                record.InstructorId.ToString()
                        }
                    ).ToArray()
            };
        }

        public IActionResult ViewCourse(int id)
        {
            try
            {
                return View(_coursesService
                    .GetCourseService(id));
            }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View("Message");
            }
        }
        public IActionResult AddCourse()
        {
            ViewData["departments"] = _departmentsService
                .GetAllDepartmentsService();
            ViewData["instructors"] = _instructorService
                .GetInstructors();
            return View();
        }

        [HttpPost]
        public IActionResult AddCourse(Instructor instructor)
        {
            try
            {
                _instructorService.InsertInstructor(instructor);
                ViewData["Message"] = "Successfully inserted";
                return View("Message");
            }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View("Message");
            }
        }

        public IActionResult EditCourse(int id)
        {
            try
            {
                ViewData["departments"] = _departmentsService
                .GetAllDepartmentsService();
                ViewData["instructors"] = _instructorService
                    .GetInstructors();

                return View(_coursesService
                    .GetCourseService(id)
                    );
            }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View("Message");
            }
        }

        [HttpPost]
        public IActionResult EditCourse(Course course)
        {
            try
            {
                _coursesService.UpdateCourseService(course);
                ViewData["Message"] = "Info Updated";
                return View("Message");
            }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View("Message");
            }
        }

        public IActionResult DeleteCourse(int id)
        {
            try
            {
                _coursesService.DeleteCourseService(id);

                ViewData["Message"] = "Course Deleted";
                return View("Message");
            }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View("Message");
            }
        }
    }
}