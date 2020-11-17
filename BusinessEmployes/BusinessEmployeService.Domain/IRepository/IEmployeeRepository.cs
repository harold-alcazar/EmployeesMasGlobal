using BusinessEmployeService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEmployeService.Domain.IRepository
{
    public interface IEmployeeRepository
    {
        Task<IList<Employee>> GetEmployeeList();
        Task<Employee> GetEmployeeById(int id);
    }
}
