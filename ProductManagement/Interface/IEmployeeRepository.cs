using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Models
{
    public interface IEmployeeRepository
    {
        
        Employee GetEmployee(int Id);
        int SaveEmployee(Employee employee);
        int DeleteEmployee(int Id);
        IEnumerable<Employee> GetEmployees();
    }
}
