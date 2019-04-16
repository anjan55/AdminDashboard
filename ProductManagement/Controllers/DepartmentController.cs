using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string List()
        {
            return "List from department controller";
        }

        public string Details()
        {
            return "Details from department controller";
        }
    }
}