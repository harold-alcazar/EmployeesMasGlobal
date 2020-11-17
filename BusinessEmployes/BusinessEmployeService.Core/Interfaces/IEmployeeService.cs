using BusinessEmployeService.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEmployeService.Core.Interfaces
{
    public interface IEmployeeService
    {
        Task<IList<EmployeeDtoBase>> GetEmployees();
        Task<IList<EmployeeDtoBase>> GetEmployeeById(int id);
    }
}
