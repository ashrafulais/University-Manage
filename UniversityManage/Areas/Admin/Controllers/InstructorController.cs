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
    public class InstructorController : Controller
    {
        IStudentCourseService _studentCourseService;
        ICoursesService _coursesService;
        public InstructorController(IStudentCourseService studentCourseService,
            ICoursesService coursesService)
        {
            _studentCourseService = studentCourseService;
            _coursesService = coursesService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllEnrollments()
        {
            return View();
        }

        public IActionResult AllEnrollmentsData()
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
            var records = _studentCourseService.GetStudentCoursesService();

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (from record in records
                        select new string[]
                        {
                                record.StudentId.ToString(),
                                record.CourseId.ToString()
                        }
                    ).ToArray()
            };
        }

        public IActionResult Demo()
        {
            return View("Message");
        }

        public IActionResult ViewEnrollment(int studentid, int courseid)
        {
            try
            {
                return View(_studentCourseService
                    .GetStudentCourseService(studentid, courseid)
                    );
            }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View("Message");
            }
        }
        public IActionResult AddEnrollment()
        {
            ViewData["courses"] = _coursesService
                    .GetCoursesService();
            return View();
        }

        [HttpPost]
        public IActionResult AddEnrollment(StudentCourse studentCourse)
        {
            try
            {
                _studentCourseService.InsertStudentCourseService(studentCourse);
                ViewData["Message"] = "Successfully enrolled";
                return View("Message");
            }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View("Message");
            }
        }

        public IActionResult EditEnrollment(int studentid, int courseid)
        {
            try
            {
                ViewData["courses"] = _coursesService
                    .GetCoursesService();
                return View(new StudentCourse()
                { 
                    StudentId= studentid, 
                    CourseId = courseid
                });
            }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View("Message");
            }
        }

        [HttpPost]
        public IActionResult EditEnrollment(StudentCourse studentCourse)
        {
            try
            {
                _studentCourseService.UpdateStudentCourseService(studentCourse);
                ViewData["Message"] = "Course Updated";
                return View("Message");
            }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View("Message");
            }
        }

        //public async Task RunEdit(StudentCourse studentCourse)
        //{
        //    await Task.Run(() => _studentCourseService.UpdateStudentCourseService(studentCourse));
        //}

        public IActionResult DeleteEnrollment(int studentid, int courseid)
        {
            try
            {
                _studentCourseService
                    .DeleteStudentCourseService(new StudentCourse()
                    {
                        StudentId = studentid,
                        CourseId = courseid
                    });

                ViewData["Message"] = "Course Enrollment Deleted";
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