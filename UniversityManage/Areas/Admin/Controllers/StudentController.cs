using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityManage.Data.Interfaces;
using UniversityManage.Model;

namespace UniversityManage.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        IDepartmentsService _departmentService;
        IStudentsService _studentsService;
        public StudentController(IDepartmentsService departmentService,
            IStudentsService studentsService)
        {
            _departmentService = departmentService;
            _studentsService = studentsService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllStudents()
        {
            return View();
        }

        public IActionResult AllStudentsData()
        {
            try
            {
                return Json(GetDatabaseData());
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
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

        public IActionResult AddStudent()
        {
            //need department list
            List<Department> departments = _departmentService
                .GetAllDepartmentsService()
                .ToList();

            ViewData["departments"] = departments;
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            try
            {
                _studentsService.InsertStudentService(student);
                ViewData["Message"] = "Successfully inserted student.";
                return View("Message");
            }
            catch (Exception e)
            {
                ViewData["Message"] = "Error: "+e.Message;
                return View("Message");
            }
        }

        public IActionResult EditStudent(int id)
        {
            try
            {
                List<Department> departments = _departmentService
                .GetAllDepartmentsService()
                .ToList();

                ViewData["departments"] = departments;
                Student student = _studentsService.GetStudentService(id);
                return View(student);
            }
            catch (Exception e)
            {
                ViewData["Message"] = "Error " + e.Message;
                return View("Message");
            }

        }

        [HttpPost]
        public IActionResult EditStudent(Student student)
        {
            try
            {
                _studentsService.UpdateStudentService(student);
                ViewData["Message"] = "Successfully updated";
                return View("Message");
            }
            catch (Exception e)
            {
                ViewData["Message"] = "Error " + e.Message;
                return View("Message");
            }
        }

        public IActionResult DeleteStudent(int id=0)
        {
            try
            {
                return View(_studentsService.GetStudentService(id));
            }
            catch (Exception e)
            {
                ViewData["Message"] = "Error "+e.Message;
                return View("Message");
            }
        }

        public IActionResult ConfirmDeleteStudent(int id=0)
        {
            try
            {
                _studentsService.DeleteStudentService(new Student() { Id = id });
                ViewData["Message"] = "Successfully deleted";
                return View("Message");
            }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View("Message");
            }
        }

        //[HttpGet("{id}")]
        public IActionResult ViewStudent(int id=0)
        {
            try
            {
                return View(_studentsService.GetStudentService(id));
            }
            catch (Exception)
            {
                ViewData["Message"] = "No records";
                return View("Message");
            }
        }
    }
}