using EmployeeDirectoryConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.Interfaces
{
    public interface IRoleManager
    {
        public void AddRole(RolesModel rolesModel);
        public void Display(RolesModel rolesModel);
    }
}
