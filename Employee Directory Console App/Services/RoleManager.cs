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
        private  IEmployeePropertyEntries _employeePropertyEntries
        {
            set
            {
                this._employeePropertyEntries= value;
            }
            get
            {
                return this._employeePropertyEntries;
            }
        }
        public RoleManager(IEmployeePropertyEntries employeePropertyEntries)
        {
            _employeePropertyEntries = employeePropertyEntries;
        }

        public void AddRole(RolesModel role)
        {
            Console.WriteLine("Roles");
            role.Department = _employeePropertyEntries.ChooseDepartment();
            Console.WriteLine("Roles");
            role.Location = _employeePropertyEntries.ChooseLocation();
            role.Description = _employeePropertyEntries.GetDescription();
        }
        public void Display(RolesModel role)
        {
            Console.WriteLine(new string('-', 66));
            Console.WriteLine("{0,-18} {1,-18} {2,-12} {3,-18}",role.Name,role.Department,role.Location,role.Description);
        }
    }
}
