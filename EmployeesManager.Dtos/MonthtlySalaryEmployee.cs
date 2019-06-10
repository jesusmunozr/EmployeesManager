using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Dtos
{
    public class MonthtlySalaryEmployee : EmployeeBase
    {
        public override decimal Salary
        {
            get
            {
                return this.monthlySalary * 12;
            }
        }

        private decimal monthlySalary;

        public MonthtlySalaryEmployee(int id, string name, int roleId, string roleName, string roleDescription, decimal monthlySalary)
            : base(id, name, roleId, roleName, roleDescription)
        {
            this.monthlySalary = monthlySalary;
        }

        
    }
}
