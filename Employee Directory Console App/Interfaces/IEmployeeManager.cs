using EmployeeDirectoryConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.Interfaces
{
    public interface IEmployeeManager
    {
        public void Create(EmployeeModel model);
        public void Update(EmployeeModel model);
        public void Delete(EmployeeModel model);
        public void Display(EmployeeModel model);
    }
}
