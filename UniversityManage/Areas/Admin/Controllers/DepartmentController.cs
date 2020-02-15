using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityManage.Data.Interfaces;
using UniversityManage.Model;

namespace UniversityManage.Areas.Admin.Controllers
{
    [Area("admin")]
    public class DepartmentController : Controller
    {
        IDepartmentsService _departmentService;
        public DepartmentController(IDepartmentsService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllDepartments()
        {
            return View();
        }

        public IActionResult AllDepartmentsData()
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
            var records = _departmentService.GetAllDepartmentsService();

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (from record in records
                        select new string[]
                        {
                                record.Id.ToString(),
                                record.Code,
                                record.Name
                        }
                    ).ToArray()
            };
        }

        public IActionResult ViewDepartment(int id)
        {
            try
            {
                return View(_departmentService
                    .GetDepartmentService(id));
            }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View("Message");
            }
        }
        public IActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDepartment(Department Department)
        {
            try
            {
                _departmentService.InsertDepartmentService(Department);
                ViewData["Message"] = "Successfully inserted";
                
                return View("Message");
            }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View("Message");
            }
        }

        public IActionResult EditDepartment(int id)
        {
            try
            {
                return View(_departmentService
                    .GetDepartmentService(id)
                    );
            }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View("Message");
            }
        }

        [HttpPost]
        public IActionResult EditDepartment(Department Department)
        {
            try
            {
                _departmentService.UpdateDepartmentService(Department);
                ViewData["Message"] = "Info Updated";
                //ViewData["Message"] = JsonSerializer.Serialize(Department);
                return View("Message");
            }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View("Message");
            }
        }

        public IActionResult DeleteDepartment(int id)
        {
            try
            {
                return View(_departmentService.GetDepartmentService(id));
            }
            catch (Exception e)
            {
                ViewData["Message"] = e.Message;
                return View("Message");
            }
        }

        public IActionResult ConfirmDeleteDepartment(int id)
        {
            try
            {
                _departmentService.DeleteDepartmentService(id);

                ViewData["Message"] = "Department Deleted";
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