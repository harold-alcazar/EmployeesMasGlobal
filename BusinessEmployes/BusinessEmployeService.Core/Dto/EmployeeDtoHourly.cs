using BusinessEmployeService.Core.Interfaces;
using BusinessEmployeService.Domain.Entities;

namespace BusinessEmployeService.Core.Dto
{
    public class EmployeeDtoHourly : EmployeeDtoBase, IEmployeeDto
    {

        public EmployeeDtoHourly(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            ContractTypeName = employee.ContractTypeName;
            RoleId = employee.RoleId;
            RoleName = employee.RoleName;
            RoleDescription = employee.RoleDescription;
            RoleDescription = employee.RoleDescription;
            HourlySalary = employee.HourlySalary;
            MonthlySalary = employee.MonthlySalary;
            AnnualSalary = CalculateAnnualSalary();
        }

        public double CalculateAnnualSalary()
        {
            return 120 * HourlySalary * 12;
        }
    }
}
