using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.ViewModels
{
    public class EmployeeDetailsViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public Employee Employee { get; set; }
        public string PageTitle { get; set; }
    }
}
