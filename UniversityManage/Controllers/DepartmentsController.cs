using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityManage.Data.Interfaces;
using UniversityManage.Model;

namespace UniversityManage.Controllers
{
    public class DepartmentsController : Controller
    {
        private IDepartmentsService _departmentsService;
        public DepartmentsController(IDepartmentsService departmentsService)
        {
            _departmentsService = departmentsService;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult GetAllDepartments()
        { 
            try
            {
                return Json(GetDatabaseData());
            }
            catch (Exception e)
            {
                return View("Error", new ErrorViewModel { RequestId = e.Message});
            }
        }

        [ActionName("GetDatabaseData")]
        public object GetDatabaseData()
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _departmentsService.GetAllDepartmentsService();

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (from record in records
                        select new string[]
                        {
                                record.Id.ToString(),
                                record.Name,
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        [HttpGet()]
        public IActionResult ViewDepartment(int id)
        {
            try
            {
                Department department = _departmentsService
                    .GetDepartmentService(id);
                return View(department);
            }
            catch (Exception e)
            {
                return View("Error", new ErrorViewModel { RequestId = e.Message });
            }
        }
    }
}