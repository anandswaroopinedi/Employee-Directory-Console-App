using EmployeeDirectoryConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.Interfaces
{
    public interface IEmployeePropertyEntries
    {
        public void DisplayHeaders();
        public string GetFirstName();
        public string GetLastName();
        public string GetEmail();
        public string GetDateOfBirth();
        public string GetMobileNo();
        public string GetJoiningDate();
        public string GetProjectName();
        public string ChooseLocation();
        public string ChooseDepartment();
        public string ChooseRole();
        public string ChooseManager(EmployeeModel employeeModel);
        public string GetDescription();
    }
}
    