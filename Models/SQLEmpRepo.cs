using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace newmvccore.Models
{
    public class SQLEmpRepo : IEmployeeRepo
    {
        private AppDbContext _appDbContext;

        public SQLEmpRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Employee Addemployee(Employee employee)
        {
            _appDbContext.employees.Add(employee);
            _appDbContext.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            Employee employee = _appDbContext.employees.FirstOrDefault(x => x.id == id);
            if (employee != null)
            {
                _appDbContext.employees.Remove(employee);
                _appDbContext.SaveChanges();
            }
            return employee;
        }

        public Employee GetEmployee(int id)
        {
            return _appDbContext.employees.FirstOrDefault(x => x.id == id);
        }

        public IEnumerable<Employee> listemployee()
        {
            return _appDbContext.employees.ToList();
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var emp = _appDbContext.employees.Attach(employee);
            emp.State = EntityState.Modified;
            _appDbContext.SaveChanges();
            return employee;

        }
    }
}
