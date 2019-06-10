using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Dal
{
    public interface IApiDataAccess<T>
    {
        Task<IEnumerable<T>> Get(string path);
    }
}
