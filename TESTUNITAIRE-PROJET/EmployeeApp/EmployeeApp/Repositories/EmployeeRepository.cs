using EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Repositories
{

    public interface IRepository<out T> where T: DomainObject
    {
        T Get(int id);
    }
    public interface  IEmployeeRepository :IRepository<Employee>
    {
    }

    public class EmployeeRepository : IEmployeeRepository
    {

        public static List<Employee> Employees = new List<Employee>
        {
        new Employee {Name ="John",Id =1 ,JoiningDate=DateTime.Parse("1/1/2018"),Salary=1000},
           new Employee {Name ="John",Id =1 ,JoiningDate=DateTime.Parse("1/1/2018"),Salary=1000},
              new Employee {Name ="John",Id =1 ,JoiningDate=DateTime.Parse("1/1/2018"),Salary=1000},
        };

        public Employee Get(int id)
        {
            return Employees.Find(e => e.Id == 1);
        }
    }
}
