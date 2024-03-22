using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.Interfaces
{
    public interface IEmployeeManagement
    {
        public void AddEmployee();
        public void DisplayAll();
        public void DisplayOne();
        public void UpdateEmployee();
        public void DeleteEmployee();
        public void DisplayMenu();
    }
}
