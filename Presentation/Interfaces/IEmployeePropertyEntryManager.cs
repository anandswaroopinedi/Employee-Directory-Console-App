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
        public int ChooseProject();
        public int ChooseRole();
        public int ChooseDepartment(EmployeeModel employee);
        public int ChooseLocation(EmployeeModel employee);
        public string ChooseManager(EmployeeModel employeeModel, List<EmployeeModel> employeeList);
    }
}
