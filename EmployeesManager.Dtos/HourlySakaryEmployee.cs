using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Dtos
{
    public class HourlySakaryEmployee : EmployeeBase
    {
        public override decimal Salary
        {
            get
            {
                return 120 * this.hourlySalary * 12;
            }
        }

        private decimal hourlySalary;

        public HourlySakaryEmployee(int id, string name, int roleId, string roleName, string roleDescription, decimal hourlySalary) 
            : base(id, name, roleId, roleName, roleDescription)
        {
            this.hourlySalary = hourlySalary;
        }
    }
}
