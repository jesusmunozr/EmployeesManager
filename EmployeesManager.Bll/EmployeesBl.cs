using EmployeesManager.Dal;
using EmployeesManager.Dal.Entities;
using EmployeesManager.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManager.Bll
{
    public class EmployeesBl : IEmployeeBl
    {
        private IApiDataAccess<Employee> _dataAccess;

        public EmployeesBl(IApiDataAccess<Employee> dataAccess)
        {
            this._dataAccess = dataAccess;
        }

        public async Task<IEnumerable<EmployeeBase>> Get(int? id)
        {
            //return await GetEmployeesDtos();
            if (id is null)
            {
                return await GetEmployeesDtos();
            }
            else
            {
                var employees = await GetEmployeesDtos();
                return employees.Where(emp => emp.Id == id);
            }
        }

        //public async Task<EmployeeBase> GetById(int id)
        //{
        //    var employees = await GetEmployeesDtos();
        //    return employees.FirstOrDefault(emp => emp.Id == id);
        //}

        private async Task<IEnumerable<EmployeeBase>> GetEmployeesDtos()
        {
            EmployeeFactory factory = null;
            IList<EmployeeBase> employees = null;


            var employeeEntities = await this._dataAccess.Get("api/employees");

            if (employeeEntities != null)
            {
                employees = new List<EmployeeBase>();

                foreach(var emp in employeeEntities)
                {
                    switch (emp.ContractTypeName.ToLower())
                    {
                        case "hourlysalaryemployee":
                            factory = new HourlySalaryEmployeeFactory(emp);
                            break;
                        case "monthlysalaryemployee":
                            factory = new MonthtlySalaryEmployeeFactory(emp);
                            break;
                        default:
                            break;
                    }
                    employees.Add(factory.GetEmployee());
                }
                return employees;
            }
            else
            {
                return null;
            }
        }
    }
}
