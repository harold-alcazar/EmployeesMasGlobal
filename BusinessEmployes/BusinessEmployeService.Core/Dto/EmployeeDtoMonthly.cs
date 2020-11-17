using BusinessEmployeService.Core.Interfaces;
using BusinessEmployeService.Domain.Entities;

namespace BusinessEmployeService.Core.Dto
{
   public class EmployeeDtoMonthly: EmployeeDtoBase, IEmployeeDto
    {
        public EmployeeDtoMonthly(Employee employee)
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
            SalaryAmmount = CalculateSalaryAmmount();
        }

        public double CalculateSalaryAmmount()
        {
            return MonthlySalary * 12;
        }
    }
}
