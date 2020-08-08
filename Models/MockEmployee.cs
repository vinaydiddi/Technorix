using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newmvccore.Models
{
    public class MockEmployee : IEmployeeRepo
    {
        private List<Employee> employees;
        public MockEmployee()
        {
            employees = new List<Employee>
            {
                new Employee{id=1,name="Vinay",department=DeptEnum.hr,email="hr@peocit.com"},
                new Employee{id=2,name="Kalyani",department=DeptEnum.manager,email="hr@peocit.com"},
                new Employee{id=3,name="Komal",department=DeptEnum.manager,email="hr@peocit.com"}
            };
        }

        public Employee Addemployee(Employee employee)
        {
            employee.id=employees.Max(x => x.id) + 1;
            employees.Add(employee);
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            Employee emp = employees.FirstOrDefault(x => x.id == id);
            if (emp != null)
            {
                employees.Remove(emp);
            }
            return emp;
        }

        public Employee GetEmployee(int id)
        {
            return employees.FirstOrDefault(x => x.id == id);
        }

        public IEnumerable<Employee> listemployee()
        {
            return employees;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            Employee emp = employees.FirstOrDefault(x => x.id == employee.id);
            if (emp != null)
            {
                emp.name = employee.name;
                emp.email = employee.email;
                emp.department = employee.department;
            }
            return emp;
        }
    }
}
