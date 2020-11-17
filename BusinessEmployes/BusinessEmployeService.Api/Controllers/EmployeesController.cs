using BusinessEmployeService.Core.Dto;
using BusinessEmployeService.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessEmployeService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employess
        [HttpGet("api/GetEmployees")]
        public async Task<IList<EmployeeDtoBase>> GetEmployees()
        {
            return await _employeeService.GetEmployees().ConfigureAwait(false);
        }

        //// GET: api/GetEmployeeById/{0}
        //[HttpGet(Name = "api/GetEmployeeById/{0}")]
        [HttpGet("api/GetEmployeeById/{id}")]
        public async Task<IList<EmployeeDtoBase>> GetEmployeeById(int id)
        {
            return await _employeeService.GetEmployeeById(id).ConfigureAwait(false);
        }
    }
}
