

using BusinessLogicLayer.Interfaces;
using DepartmentManagementLibrary.Interfaces;
using InputEntryManagersLibrary.Interfaces;
using LocationManagementLibrary.Interfaces;
using Models;


namespace BusinessLogicLayer
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeePropertyEntryManager _employeePropertyEntries;
        private readonly IDepartmentPropertyEntryManager _departmentPropertyEntries;
        private readonly ILocationPropertyEntryManager _locationPropertyEntries;
        public EmployeeManager(IEmployeePropertyEntryManager employeePropertyEntries, ILocationPropertyEntryManager locationPropertyEntryManager, IDepartmentPropertyEntryManager departmentPropertyEntryManager)
        {
            _employeePropertyEntries = employeePropertyEntries;
            _departmentPropertyEntries = departmentPropertyEntryManager;
            _locationPropertyEntries = locationPropertyEntryManager;
        }
        public void Create(EmployeeModel employee,ref List<EmployeeModel>employeeList, ref List<LocationModel> locationList, ref List<DepartmentModel> departmentList, ref List<RolesModel> rolesList)
        {
            employee.FirstName = _employeePropertyEntries.GetFirstName();
            employee.LastName = _employeePropertyEntries.GetLastName();
            employee.DateOfBirth = _employeePropertyEntries.GetDateOfBirth();
            employee.Email = _employeePropertyEntries.GetEmail();
            employee.MobileNumber = _employeePropertyEntries.GetMobileNo();
            employee.JoinDate = _employeePropertyEntries.GetJoiningDate();
            employee.Location = _locationPropertyEntries.ChooseLocation(ref locationList);
            employee.JobTitle = _employeePropertyEntries.ChooseRole(ref rolesList);
            employee.Department = _departmentPropertyEntries.ChooseDepartment(ref departmentList);
            employee.ManagerId = _employeePropertyEntries.ChooseManager(employee,employeeList);
            employee.Project = _employeePropertyEntries.GetProjectName();
        }
        public void Update(EmployeeModel employee,ref List<EmployeeModel> employeeList, ref List<LocationModel> locationList, ref List<DepartmentModel> departmentList, ref List<RolesModel> rolesList)
        {
            _employeePropertyEntries.DisplayHeaders();
            Console.Write("\nChoose the details to change:");
            int.TryParse(Console.ReadLine(), out int option);
            switch (option)
            {
                case 1:
                    employee.FirstName = _employeePropertyEntries.GetFirstName();
                    break;
                case 2:
                    employee.LastName = _employeePropertyEntries.GetLastName();
                    break;
                case 3:
                    employee.DateOfBirth = _employeePropertyEntries.GetDateOfBirth();
                    break;
                case 4:
                    employee.Email = _employeePropertyEntries.GetEmail();
                    break;
                case 5:
                    employee.MobileNumber = _employeePropertyEntries.GetMobileNo();
                    break;
                case 6:
                    employee.JoinDate = _employeePropertyEntries.GetJoiningDate();
                    break;
                case 7:
                    employee.Location = _locationPropertyEntries.ChooseLocation(ref locationList);
                    break;
                case 8:
                    employee.JobTitle = _employeePropertyEntries.ChooseRole(ref rolesList);
                    break;
                case 9:
                    employee.Department = _departmentPropertyEntries.ChooseDepartment(ref departmentList);
                    break;
                case 10:
                    employee.ManagerId = _employeePropertyEntries.ChooseManager(employee,employeeList);
                    break;
                case 11:
                    employee.Project = _employeePropertyEntries.GetProjectName();
                    break;
                default:
                    Console.WriteLine("Modification can only be done on the above properties only");
                    break;
            }
            Console.WriteLine("{0,-8} {1,-18} {2,-12} {3,-18} {4,-12} {5,-12} {6,-12} {7,-12} {8,-12} {9,-15} {10,-12} ", "Id", "Full Name", "DateOfBirth", "Email", "MobileNumber", "JoinDate", "Location", "JobTitle", "Department", "ManagerName", "Project");
            Display(employee,ref employeeList);
        }
        public void Display(EmployeeModel e,ref List<EmployeeModel> employeeList)
        {
            string managerName = GetManagerName(e,ref employeeList);
            Console.WriteLine(new string('-', 145));
            Console.WriteLine("{0,-8} {1,-18} {2,-12} {3,-18} {4,-12} {5,-12} {6,-12} {7,-12} {8,-12} {9,-15} {10,-12} ", e.Id, e.FirstName + " " + e.LastName, e.DateOfBirth, e.Email, e.MobileNumber, e.JoinDate, e.Location, e.JobTitle, e.Department, managerName, e.Project);
        }
        public void Delete(EmployeeModel e,ref List<EmployeeModel> employeeList)
        {
            employeeList.Remove(e);
        }
        public static string GetManagerName(EmployeeModel e,ref List<EmployeeModel> employeeList)
        {
            for (int i = 0; i < employeeList.Count; i++)
            {
                if (employeeList[i].Id == e.ManagerId)
                {
                    return employeeList[i].FirstName + " " + employeeList[i].LastName;
                }
            }
            return "No Manager";
        }
    }

}
