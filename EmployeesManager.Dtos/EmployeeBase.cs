using System;

namespace EmployeesManager.Dtos
{
    public abstract class EmployeeBase
    {
        public int Id { get; }
        public string Name { get; }
        public int RoleId { get; }
        public string RoleName { get; }
        public string RoleDescription { get; }
        public abstract decimal Salary { get; }

        protected EmployeeBase(int id, string name, int roleId, string roleName, string roleDescription)
        {
            this.Id = id;
            this.Name = name;
            this.RoleId = roleId;
            this.RoleName = roleName;
            this.RoleDescription = roleDescription;
        }
    }
}
