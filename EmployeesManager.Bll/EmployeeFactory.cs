using EmployeesManager.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Bll
{
    abstract class EmployeeFactory
    {
        public abstract EmployeeBase GetEmployee();
    }
}
