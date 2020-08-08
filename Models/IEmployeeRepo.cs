using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newmvccore.Models
{
    public interface IEmployeeRepo
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> listemployee();
        Employee Addemployee(Employee employee);
        Employee DeleteEmployee(int id);
        Employee UpdateEmployee(Employee employee);
    }
}
