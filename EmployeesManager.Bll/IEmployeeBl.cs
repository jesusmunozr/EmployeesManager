using EmployeesManager.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Bll
{
    public interface IEmployeeBl
    {
        Task<IEnumerable<EmployeeBase>> Get(int? id);
        //Task<EmployeeBase> GetById(int id);
    }
}
