using EmployeeDirectoryConsoleApp.Models;

namespace EmployeeDirectoryConsoleApp.Presentation.Interfaces
{
    public interface IEmployeePropertyEntryManager
    {
        public void DisplayHeaders();
        public string GetFirstName();
        public string GetLastName();
        public string GetEmail();
        public string GetDateOfBirth();
        public string GetMobileNo();
        public string GetJoiningDate();
        public string GetProjectName();
        public string ChooseRole();
        public string ChooseManager(EmployeeModel employeeModel);
    }
}
