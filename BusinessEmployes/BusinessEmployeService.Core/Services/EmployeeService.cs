using AutoMapper;
using BusinessEmployeService.Core.Dto;
using BusinessEmployeService.Core.Interfaces;
using BusinessEmployeService.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEmployeService.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeFactory _employeeFactory;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, IEmployeeFactory employeeFactory)
        {
            _employeeRepository = employeeRepository;
            _employeeFactory = employeeFactory;
        }

        public async Task<IList<EmployeeDtoBase>> GetEmployees()
        {
            var employees = await _employeeRepository.GetEmployeeList().ConfigureAwait(false);
            var employeesDtoList = new List<EmployeeDtoBase>();
            foreach (var employee in employees)
            {
                employeesDtoList.Add(_employeeFactory.CalculateSalary(employee));
            }

            return employeesDtoList;
        }

        public async Task<IList<EmployeeDtoBase>> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id).ConfigureAwait(false);
            var employeesDtoList = new List<EmployeeDtoBase>();
            if (employee != null)
            {
                employeesDtoList.Add(_employeeFactory.CalculateSalary(employee));
            }

            return employeesDtoList;
        }
    }
}
