using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newmvccore.Models
{
    public static class Modelbuilderextension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { id = 1, name = "vinay", department = DeptEnum.hr, email = "diddivinay@gmail.com" },
                new Employee { id = 2, name = "kalyani", department = DeptEnum.manager, email = "kalyani@gmail.com" },
                new Employee { id = 3, name = "nikita", department = DeptEnum.manager, email = "nikita@gmail.com" }
                );
        }
    }
}
