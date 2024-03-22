using EmployeeDirectoryConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.Interfaces
{
    public interface IDepartment
    {
        public void AddDepartment(DepartmentModel dept);
    }
}
