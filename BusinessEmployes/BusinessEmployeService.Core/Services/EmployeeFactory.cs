using BusinessEmployeService.Core.Dto;
using BusinessEmployeService.Core.Interfaces;
using BusinessEmployeService.Domain.Entities;

namespace BusinessEmployeService.Core.Services
{
    public class EmployeeFactory:IEmployeeFactory
    {
        public EmployeeDtoBase CalculateSalary(Employee employee)
        {
            switch (employee.ContractTypeName)
            {
                case "HourlySalaryEmployee":
                    return new EmployeeDtoHourly(employee);
                case "MonthlySalaryEmployee":
                    return new EmployeeDtoMonthly(employee);
                default:
                    return new EmployeeDtoMonthly(employee);
            }
        }
    }
}
