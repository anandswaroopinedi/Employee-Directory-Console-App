using EmployeeDirectoryConsoleApp.Presentation.Interfaces;
using EmployeeDirectoryConsoleApp.Interfaces;
using EmployeeDirectoryConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.Services
{
    public class RoleManager:IRoleManager
    {
        private readonly IDepartmentPropertyEntryManager _departmentPropertyEntries;
        private readonly IRolePropertyEntryManager _rolePropertyEntries;
        private readonly ILocationPropertyEntryManager _locationPropertyEntries;
        public RoleManager( IDepartmentPropertyEntryManager departmentPropertyEntries, IRolePropertyEntryManager rolePropertyEntries, ILocationPropertyEntryManager locationPropertyEntries)
        {
            _departmentPropertyEntries = departmentPropertyEntries;
            _rolePropertyEntries = rolePropertyEntries;
            _locationPropertyEntries = locationPropertyEntries;
        }

        public void AddRole(RolesModel role)
        {
            Console.WriteLine("Roles");
            role.Department = _departmentPropertyEntries.ChooseDepartment();
            Console.WriteLine("Roles");
            role.Location = _locationPropertyEntries.ChooseLocation();
            role.Description = _rolePropertyEntries.GetDescription();
        }
        public void Display(RolesModel role)
        {
            Console.WriteLine(new string('-', 66));
            Console.WriteLine("{0,-18} {1,-18} {2,-12} {3,-18}",role.Name,role.Department,role.Location,role.Description);
        }
    }
}
