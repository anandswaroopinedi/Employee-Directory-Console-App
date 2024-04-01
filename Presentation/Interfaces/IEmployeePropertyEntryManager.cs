using Models;
namespace Presentation.Interfaces
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
        public string ChooseDepartment(EmployeeModel employee);
        public string ChooseLocation(EmployeeModel employee);
        public string ChooseManager(EmployeeModel employeeModel, List<EmployeeModel> employeeList);
    }
}
