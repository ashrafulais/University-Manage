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
        IInstructorService _instructorService;
        IDepartmentsService _departmentsService;
        public InstructorController(IInstructorService instructorService,
        IDepartmentsService departmentsService)
        {
            _instructorService = instructorService;
            _departmentsService = departmentsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllInstructors()
        {
            return View();
        }

        public IActionResult AllInstructorsData()
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
                                record.Salary.ToString()
                        }
                    ).ToArray()
            };
        }

        public IActionResult ViewInstructor(int id)
        {
            try
            {
                return View(_instructorService
                    .GetInstructor(id));
            }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View("Message");
            }
        }
        public IActionResult AddInstructor()
        {
            ViewData["departments"] = _departmentsService
                .GetAllDepartmentsService();
            return View();
        }

        [HttpPost]
        public IActionResult AddInstructor(Instructor instructor)
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

        public IActionResult EditInstructor(int id)
        {
            try
            {
                ViewData["departments"] = _departmentsService
                    .GetAllDepartmentsService();
                return View(_instructorService
                    .GetInstructor(id)
                    );
            }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View("Message");
            }
        }

        [HttpPost]
        public IActionResult EditInstructor(Instructor instructor)
        {
            try
            {
                _instructorService.UpdateInstructor(instructor);
                ViewData["Message"] = "Info Updated";
                return View("Message");
            }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View("Message");
            }
        }

        public IActionResult DeleteInstructor(int id)
        {
            try
            {
                _instructorService.DeleteInstructor(id);

                ViewData["Message"] = "Instructor Deleted";
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