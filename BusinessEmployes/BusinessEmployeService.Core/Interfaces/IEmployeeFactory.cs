using BusinessEmployeService.Core.Dto;
using BusinessEmployeService.Domain.Entities;

namespace BusinessEmployeService.Core.Interfaces
{
    public interface IEmployeeFactory
    {
        EmployeeDtoBase CalculateSalary(Employee employee);
    }
}
