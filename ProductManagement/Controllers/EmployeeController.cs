using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductManagement.Models;
using ProductManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.Controllers
{
    
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        static string ResponseMessage="";
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        //public IActionResult Index()
        //public string Index()
        //public JsonResult Index()
        public ViewResult Index()
        {
            EmployeeDetailsViewModel employeeDetailsViewModel = new EmployeeDetailsViewModel()
            {
                Employees = _employeeRepository.GetEmployees(),
                PageTitle = "Employee Details"
            };
           
            if (ResponseMessage.Length>0)
            {
                ViewBag.Message = ResponseMessage;
                ResponseMessage = "";
            }
            else
            {
                ViewBag.Message = "";
            }
            return View(employeeDetailsViewModel);
            //return _employeeRepository.GetEmployee(1).Name;
            //return Json(new { id = 1, name = "Ram" });
            //return ("Hello World! From Home Controller");
            //return View();
        }

        //public JsonResult Details()
        //public ObjectResult Details()
        
        
        public ViewResult Detail(int? Id)
        {
            EmployeeDetailsViewModel employeeDetailsViewModel = new EmployeeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(Id??1),
                PageTitle = "Employee Details"
            };
            return View(employeeDetailsViewModel);

        }

        public ViewResult Details(int? Id)
        {
            EmployeeDetailsViewModel employeeDetailsViewModel = new EmployeeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(Id ?? 1),
                PageTitle = "Employee Details"
            };
            return View(employeeDetailsViewModel);

        }

        public ViewResult Create()
        {
            EmployeeDetailsViewModel employeeDetailsViewModel = new EmployeeDetailsViewModel()
            {                
                PageTitle = "Add Employee"
            };

            return View(employeeDetailsViewModel);

        }

        public ViewResult Update(int Id)
        {
            EmployeeDetailsViewModel employeeDetailsViewModel = new EmployeeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(Id),
                PageTitle = "Edit Employee"
            };
            
            return View(employeeDetailsViewModel);          

        }

        [HttpPost]
        public ActionResult Save(Employee employee)
        {
           int id = _employeeRepository.SaveEmployee(employee);
           if(id>0)
            {
                ResponseMessage = "Data successfully saved.";
            }
            return RedirectToAction("Index");

        }

        
        public ActionResult Delete(int Id)
        {
            int id = _employeeRepository.DeleteEmployee(Id);
            if (id > 0)
            {
                ResponseMessage = "Data successfully deleted.";
            }
            return RedirectToAction("Index");

        }


    }
}