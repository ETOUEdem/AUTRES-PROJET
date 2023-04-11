using EmployeeApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Services
{
    public interface IEmployeeService
    {
        double CalculateTax(int employeeId, DateTime to);

    }

    public class EmployeeService : IEmployeeService
    {
        private ITaxService _taxeService;
        private IEmployeeRepository _repository;

        public EmployeeService(ITaxService taxService, IEmployeeRepository repository)
        {
            _taxeService = taxService;
            _repository = repository;
        }
        public double CalculateTax(int employeeId, DateTime to)
        {
            var employee = _repository.Get(employeeId);
            var totalMonth = ((to - employee.JoiningDate).TotalDays + 1) / 30;
            var totalSalary = totalMonth * employee.Salary;
            return totalSalary * _taxeService.GetTaxeRate();
        }
    }
}
