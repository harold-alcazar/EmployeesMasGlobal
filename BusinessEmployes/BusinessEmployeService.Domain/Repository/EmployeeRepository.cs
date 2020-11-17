using BusinessEmployeService.Domain.Entities;
using BusinessEmployeService.Domain.Helpers;
using BusinessEmployeService.Domain.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessEmployeService.Domain.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly IHttpClient _httpClient;
        private readonly IConfigProvider _configuration;

        public EmployeeRepository(IHttpClient httpClient, IConfigProvider configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employees = await GetEmployeeList().ConfigureAwait(false);
            var employee = employees?.FirstOrDefault(e => e.Id == id);
            return employee;
        }

        public async Task<IList<Employee>> GetEmployeeList()
        {
            string urlApiEmployees = _configuration.GetVal("UrlEmployees");
            var employess = await _httpClient.GetData<List<Employee>>(urlApiEmployees).ConfigureAwait(false);
            return employess;
        }
    }
}
