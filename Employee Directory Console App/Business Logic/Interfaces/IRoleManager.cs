using EmployeeDirectoryConsoleApp.Models;

namespace EmployeeDirectoryConsoleApp.Interfaces
{
    public interface IRoleManager
    {
        public void AddRole(RolesModel rolesModel);
        public void Display(RolesModel rolesModel);
    }
}
