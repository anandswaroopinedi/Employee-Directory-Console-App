using EmployeeDirectoryConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.DataPresentation.Interface
{
    public interface IDepartmentOperations
    {
        public List<DepartmentModel> read();
        public void write();
    }
}
