using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEmployeService.Domain.Helpers
{
    public interface IHttpClient
    {
        Task<T> GetData<T>(string path);
    }
}
