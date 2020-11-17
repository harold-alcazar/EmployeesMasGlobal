using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEmployeService.Domain
{
    public interface IConfigProvider
    {
        string GetVal(string key);
    }
}
