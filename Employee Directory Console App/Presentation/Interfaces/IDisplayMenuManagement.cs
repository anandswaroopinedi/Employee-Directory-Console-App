using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.Presentation.Interfaces
{
    public interface IDisplayMenuManagement
    {
        public void StartAppDisplayOptionMenu();
        public void EmployeeManagementDisplayMenu();
        public void RoleManagementDisplayMenu();
        public void DepartmentLocationDisplayMenu();
    }
}
