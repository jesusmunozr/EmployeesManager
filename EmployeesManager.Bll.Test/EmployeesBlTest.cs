using EmployeesManager.Dtos;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EmployeesManager.Bll.Test
{
    public class EmployeesBlTest
    {
        [Fact]
        public void Task_Get_All_Employees()
        {
            //Arrange
            var employees = new List<EmployeeBase>
            {
                new HourlySakaryEmployee(1,"",1,"","",10000),
                new MonthtlySalaryEmployee(2,"",2, "","",20000)
            };

            var employeeBl = new Mock<IEmployeeBl>();
            employeeBl.Setup(b => b.Get(It.IsAny<Nullable<int>>())).Returns(Task.FromResult<IEnumerable<EmployeeBase>>(employees));

            Assert.Equal(employees, employeeBl.Object.Get(null).Result);
        }

        [Fact]
        public void Task_Get_Employee_By_Id()
        {
            //Arrange
            var employees = new List<EmployeeBase>
            {
                new HourlySakaryEmployee(1,"",1,"","",10000)
            };

            var employeeBl = new Mock<IEmployeeBl>();
            employeeBl.Setup(b => b.Get(It.IsAny<Nullable<int>>())).Returns(Task.FromResult<IEnumerable<EmployeeBase>>(employees));

            Assert.Equal(employees, employeeBl.Object.Get(1).Result);
        }
    }
}