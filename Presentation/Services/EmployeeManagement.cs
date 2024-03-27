using BusinessLogicLayer.Interfaces;
using DepartmentManagementLibrary.Interfaces;
using LocationManagementLibrary.Interfaces;
using Models;
using Presentation.Interfaces;
using Validations;

namespace Presentation.Services
{
    public class EmployeeManagement : IEmployeeManagement
    {

        public static List<EmployeeModel> EmployeeList = new List<EmployeeModel>();
        private readonly IEmployeeManager _employeeManager;
        private readonly IEmployeePropertyEntryManager _employeePropertyEntryManager;
        private readonly ILocationPropertyEntryManager _locationPropertyEntryManager;
        private readonly IDepartmentPropertyEntryManager _departmentPropertyEntryManager;
        //public static Employee EmpHandler=new Employee();
        //Displaying Menu When Employee Json has 0 employee count
        public EmployeeManagement(IEmployeeManager emp, IEmployeePropertyEntryManager employeePropertyEntryManager, ILocationPropertyEntryManager locationPropertyEntryManager, IDepartmentPropertyEntryManager departmentPropertyEntryManager)
        {
            _employeeManager = emp;
            _employeePropertyEntryManager = employeePropertyEntryManager;
            _locationPropertyEntryManager = locationPropertyEntryManager;
            _departmentPropertyEntryManager = departmentPropertyEntryManager;
        }
        public void GetUpdateDetails(EmployeeModel employee)
        {
            _employeePropertyEntryManager.DisplayHeaders();
            Console.WriteLine("12: Exit By Applying Changes");
            Console.Write("\nChoose the details to change:");
            int.TryParse(Console.ReadLine(), out int option);
            while (option <= 11 && option>=1)
            {
                switch (option)
                {
                    case 1:
                        employee.FirstName = _employeePropertyEntryManager.GetFirstName();
                        break;
                    case 2:
                        employee.LastName = _employeePropertyEntryManager.GetLastName();
                        break;
                    case 3:
                        employee.DateOfBirth = _employeePropertyEntryManager.GetDateOfBirth();
                        break;
                    case 4:
                        employee.Email = _employeePropertyEntryManager.GetEmail();
                        break;
                    case 5:
                        employee.MobileNumber = _employeePropertyEntryManager.GetMobileNo();
                        break;
                    case 6:
                        employee.JoinDate = _employeePropertyEntryManager.GetJoiningDate();
                        break;
                    case 7:
                        employee.Location = _locationPropertyEntryManager.ChooseLocation(ref StartApp.LocationList);
                        break;
                    case 8:
                        employee.JobTitle = _employeePropertyEntryManager.ChooseRole(ref RoleManagement.RoleList);
                        break;
                    case 9:
                        employee.Department = _departmentPropertyEntryManager.ChooseDepartment(ref StartApp.DepartmentList);
                        break;
                    case 10:
                        employee.ManagerId = _employeePropertyEntryManager.ChooseManager(employee, EmployeeList);
                        break;
                    case 11:
                        employee.Project = _employeePropertyEntryManager.GetProjectName();
                        break;
                    default:
                        Console.WriteLine("Modification can only be done on the above properties only");
                        break;
                }
                Console.Write("\nChoose the details to change:");
                int.TryParse(Console.ReadLine(), out option);
            }
        }
        //To Record the details of employee for update.
        public static string GetManagerName(EmployeeModel e)
        {
            for (int i = 0; i < EmployeeList.Count; i++)
            {
                if (EmployeeList[i].Id == e.ManagerId)
                {
                    return EmployeeList[i].FirstName + " " + EmployeeList[i].LastName;
                }
            }
            return "No Manager";
        }
        public void UpdateEmployee()
        {
            Console.Write("Enter Employee Id:");
            string id = Console.ReadLine()!.ToUpper();
            int index = CheckIdExists(id);
            if (index != -1)
            {
                GetUpdateDetails(EmployeeList[index]);
                _employeeManager.Update(EmployeeList[index], ref EmployeeList);
                string managerName = GetManagerName(EmployeeList[index]);
                Console.WriteLine("{0,-8} {1,-18} {2,-12} {3,-18} {4,-12} {5,-12} {6,-12} {7,-12} {8,-12} {9,-15} {10,-12} ", "Id", "Full Name", "DateOfBirth", "Email", "MobileNumber", "JoinDate", "Location", "JobTitle", "Department", "ManagerName", "Project");
                Console.WriteLine(new string('-', 145));
                Console.WriteLine("{0,-8} {1,-18} {2,-12} {3,-18} {4,-12} {5,-12} {6,-12} {7,-12} {8,-12} {9,-15} {10,-12} ", EmployeeList[index].Id, EmployeeList[index].FirstName + " " + EmployeeList[index].LastName, EmployeeList[index].DateOfBirth, EmployeeList[index].Email, EmployeeList[index].MobileNumber, EmployeeList[index].JoinDate, EmployeeList[index].Location, EmployeeList[index].JobTitle, EmployeeList[index].Department, managerName, EmployeeList[index].Project);
                Console.WriteLine("Employee Updated successfully");
            }
            else
            {
                Console.WriteLine("Employee Id doesn't exists");
            }
        }
        //To make the managerId's of employee that are containing the deleted id should be made default None
        //To Record the details of employee to perform deletion Operation
        public void DeleteEmployee()
        {
            Console.Write("Enter Employee Id:");
            string id = Console.ReadLine()!.ToUpper();
            int index = CheckIdExists(id);
            if (index != -1)
            {
                _employeeManager.Delete(EmployeeList[index], ref EmployeeList);
                Console.WriteLine("Employee deleted successfully");
            }
            else
            {
                Console.WriteLine("Employee Id doesn't exists");
            }
        }
        //To Display Employee through their id
        public void DisplayOne()
        {
            Console.Write("Enter Employee Id:");
            string id = Console.ReadLine().ToUpper();
            EmployeeModel employee = _employeeManager.Display(id);
            if (employee.Id != "None")
            {
                string managerName = GetManagerName(employee);
                Console.WriteLine("{0,-8} {1,-18} {2,-12} {3,-18} {4,-12} {5,-12} {6,-12} {7,-12} {8,-12} {9,-15} {10,-12} ", "Id", "Full Name", "DateOfBirth", "Email", "MobileNumber", "JoinDate", "Location", "JobTitle", "Department", "ManagerName", "Project");
                Console.WriteLine("{0,-8} {1,-18} {2,-12} {3,-18} {4,-12} {5,-12} {6,-12} {7,-12} {8,-12} {9,-15} {10,-12} ", employee.Id, employee.FirstName + " " + employee.LastName, employee.DateOfBirth, employee.Email, employee.MobileNumber, employee.JoinDate, employee.Location, employee.JobTitle, employee.Department, managerName, employee.Project);
            }
            else
            {
                Console.WriteLine("Employee Id doesn't exists");
            }
        }
        public void DisplayAll()
        {
            Console.WriteLine($"\nNo of Employee records in the Database are: {EmployeeList.Count}");
            Console.WriteLine("{0,-8} {1,-18} {2,-12} {3,-18} {4,-12} {5,-12} {6,-12} {7,-12} {8,-12} {9,-15} {10,-12} ", "Id", "Full Name", "DateOfBirth", "Email", "MobileNumber", "JoinDate", "Location", "JobTitle", "Department", "ManagerName", "Project");
            foreach (var employee in EmployeeList)
            {
                string managerName = GetManagerName(employee);
                Console.WriteLine("{0,-8} {1,-18} {2,-12} {3,-18} {4,-12} {5,-12} {6,-12} {7,-12} {8,-12} {9,-15} {10,-12} ", employee.Id, employee.FirstName + " " + employee.LastName, employee.DateOfBirth, employee.Email, employee.MobileNumber, employee.JoinDate, employee.Location, employee.JobTitle, employee.Department, managerName, employee.Project);
            }
        }
        public static int CheckIdExists(string id)
        {
            for (int i = 0; i < EmployeeList.Count; i++)
            {
                if (EmployeeList[i].Id == id)
                    return i;
            }
            return -1;
        }
        private EmployeeModel GetEmployeeInputValues(EmployeeModel employee)
        {
            employee.FirstName = _employeePropertyEntryManager.GetFirstName();
            employee.LastName = _employeePropertyEntryManager.GetLastName();
            employee.DateOfBirth = _employeePropertyEntryManager.GetDateOfBirth();
            employee.Email = _employeePropertyEntryManager.GetEmail();
            employee.MobileNumber = _employeePropertyEntryManager.GetMobileNo();
            employee.JoinDate = _employeePropertyEntryManager.GetJoiningDate();
            employee.Location = _locationPropertyEntryManager.ChooseLocation(ref StartApp.LocationList);
            employee.JobTitle = _employeePropertyEntryManager.ChooseRole(ref RoleManagement.RoleList);
            employee.Department = _departmentPropertyEntryManager.ChooseDepartment(ref StartApp.DepartmentList);
            employee.ManagerId = _employeePropertyEntryManager.ChooseManager(employee, EmployeeList);
            employee.Project = _employeePropertyEntryManager.GetProjectName();
            return employee;
        }
        public void AddEmployee()
        {
            bool flag = true;
            while (flag)
            {
                Console.Write("Enter Employee Id(TZ0001)*:");
                string empId = Console.ReadLine().ToUpper();
                if (Validation.ValidateEmployeeId(empId) && CheckIdExists(empId) == -1)
                {
                    EmployeeModel emp = new EmployeeModel();
                    emp.Id = empId;
                    GetEmployeeInputValues(emp);
                    _employeeManager.Create(emp, ref EmployeeList);
                    flag = false;
                }
                else { Console.WriteLine("Employee Id Exists or Employee Id not following the Pattern('TZ0101') so enter again"); }
            }

        }
    }
}
