using System;
using System.Collections.Generic;
using System.Text;
using EmployeesManager.Dal.Entities;
using EmployeesManager.Dtos;

namespace EmployeesManager.Bll
{
    class HourlySalaryEmployeeFactory : EmployeeFactory
    {
        private Employee _employee;

        public HourlySalaryEmployeeFactory(Employee employee)
        {
            this._employee = employee;
        }

        public override EmployeeBase GetEmployee()
        {
            return new HourlySakaryEmployee(this._employee.Id, this._employee.Name, this._employee.RoleId, this._employee.RoleName, this._employee.RoleDescription, this._employee.HourlySalary);
        }

    }
}
