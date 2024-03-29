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
        public string GetProjectName(List<string> projectDetails);
        public string ChooseRole(ref List<RolesModel> rolesList);
        public string ChooseDepartment(EmployeeModel employee, List<RolesModel> rolesList);
        public string ChooseLocation(EmployeeModel employee, List<RolesModel> rolesList);
        public string ChooseManager(EmployeeModel employeeModel, List<EmployeeModel> employeeList);
    }
}
