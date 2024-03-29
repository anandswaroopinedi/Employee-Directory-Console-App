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
        private static List<string> _projectList = new List<string>() { "Bavy's", "Console Project", "Internal Project", "Microsoft Project" };
        private readonly IEmployeeManager _employeeManager;
        private readonly IEmployeePropertyEntryManager _employeePropertyEntryManager;
        public EmployeeManagement(IEmployeeManager emp, IEmployeePropertyEntryManager employeePropertyEntryManager, ILocationPropertyEntryManager locationPropertyEntryManager, IDepartmentPropertyEntryManager departmentPropertyEntryManager)
        {
            _employeeManager = emp;
            _employeePropertyEntryManager = employeePropertyEntryManager;
        }
        public bool GetUpdateDetails(EmployeeModel employee)
        {
            _employeePropertyEntryManager.DisplayHeaders();
            Console.WriteLine("12: Exit By Applying Changes");
            Console.Write("\nChoose the details to change:");
            int.TryParse(Console.ReadLine(), out int option);
            bool res = false;
            string value;
            while (option <= 11 && option >= 1)
            {
                bool operation = true;
                switch (option)
                {
                    case 1:

                        value = _employeePropertyEntryManager.GetFirstName();
                        if (value == "Abort")
                        {
                            operation = false;
                        }
                        else
                        {
                            employee.FirstName = value;
                        }
                        break;
                    case 2:
                        value = _employeePropertyEntryManager.GetLastName();
                        if (value == "Abort")
                        {
                            operation = false;
                        }
                        else
                        {
                            employee.LastName = value;
                        }
                        break;
                    case 3:
                        value = _employeePropertyEntryManager.GetDateOfBirth();
                        if (value == "Abort")
                        {
                            operation = false;
                        }
                        else
                        {
                            employee.DateOfBirth = value;
                        }
                        break;
                    case 4:
                        value = _employeePropertyEntryManager.GetEmail();
                        if (value == "Abort")
                        {
                            operation = false;
                        }
                        else
                        {
                            employee.Email = value;
                        }
                        break;
                    case 5:
                        value = _employeePropertyEntryManager.GetMobileNo();
                        if (value == "Abort")
                        {
                            operation = false;
                        }
                        else
                        {
                            employee.MobileNumber = value;
                        }
                        break;
                    case 6:
                        value = _employeePropertyEntryManager.GetJoiningDate();
                        if (value == "Abort")
                        {
                            operation = false;
                        }
                        else
                        {
                            employee.JoinDate = value;
                        }
                        break;
                    case 7:
                        value = _employeePropertyEntryManager.ChooseRole(ref RoleManagement.RoleList);
                        if (value == "Abort")
                        {
                            operation = false;
                        }
                        else
                        {
                            employee.JobTitle = value;
                        }
                        break;
                    case 8:
                        value = _employeePropertyEntryManager.ChooseLocation(employee, RoleManagement.RoleList);
                        if (value == "Abort")
                        {
                            operation = false;
                        }
                        else
                        {
                            employee.Location = value;
                        }
                        break;
                    case 9:
                        value = _employeePropertyEntryManager.ChooseDepartment(employee, RoleManagement.RoleList);
                        if (value == "Abort")
                        {
                            operation = false;
                        }
                        else
                        {
                            employee.Department = value;
                        }
                        break;
                    case 10:
                        value = _employeePropertyEntryManager.ChooseManager(employee, EmployeeList);
                        if (value == "Abort")
                        {
                            operation = false;
                        }
                        else
                        {
                            employee.ManagerId = value;
                        }
                        break;
                    case 11:
                        value = _employeePropertyEntryManager.GetProjectName(_projectList);
                        if (value == "Abort")
                        {
                            operation = false;
                        }
                        else
                        {
                            employee.Project = value;
                        }
                        break;
                    default:
                        Console.WriteLine("Modification can only be done on the above properties only");
                        break;
                }
                if (operation == true)
                {
                    res = true;
                    _employeePropertyEntryManager.DisplayHeaders();
                    Console.WriteLine("12: Exit By Applying Changes");
                    Console.Write("\nChoose the details to change:");
                    int.TryParse(Console.ReadLine(), out option);
                }
                else
                {
                    option = 0;
                }

            }
            return res;
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
        public static void DisplayEmployeeID()
        {
            for (int i = 0; i < EmployeeList.Count; i++)
            {
                Console.WriteLine("{0,-4}{1,-8}", $"{i + 1}.", $"{EmployeeList[i].Id}");
            }
        }
        public void UpdateEmployee()
        {
            Console.WriteLine("Employee Id's:");
            DisplayEmployeeID();
            Console.WriteLine($"{EmployeeList.Count + 1}. Exit");
            Console.Write("Choose from the above list:");
            int.TryParse(Console.ReadLine(), out int index);
            if (index == EmployeeList.Count + 1)
            {
                return;
            }
            if (index > 0 && index <= EmployeeList.Count)
            {
                bool res = GetUpdateDetails(EmployeeList[index]);
                if (res)
                {
                    _employeeManager.Update(EmployeeList[index], ref EmployeeList);
                    string managerName = GetManagerName(EmployeeList[index]);
                    Console.WriteLine("{0,-8} {1,-18} {2,-12} {3,-18} {4,-12} {5,-12} {6,-12} {7,-12} {8,-12} {9,-15} {10,-12} ", "Id", "Full Name", "DateOfBirth", "Email", "MobileNumber", "JoinDate", "Location", "JobTitle", "Department", "ManagerName", "Project");
                    Console.WriteLine(new string('-', 158));
                    Console.WriteLine("{0,-8} {1,-18} {2,-12} {3,-18} {4,-12} {5,-12} {6,-12} {7,-12} {8,-12} {9,-15} {10,-12} ", EmployeeList[index].Id, EmployeeList[index].FirstName + " " + EmployeeList[index].LastName, EmployeeList[index].DateOfBirth, EmployeeList[index].Email, EmployeeList[index].MobileNumber, EmployeeList[index].JoinDate, EmployeeList[index].Location, EmployeeList[index].JobTitle, EmployeeList[index].Department, managerName, EmployeeList[index].Project);
                    Console.WriteLine("Employee Updated successfully");
                }
                else
                {
                    Console.WriteLine("Updation Unsuccessful");
                }
            }
            else
            {
                Console.WriteLine("Choose from above options only.");
                UpdateEmployee();
            }
        }
        //To make the managerId's of employee that are containing the deleted id should be made default None
        //To Record the details of employee to perform deletion Operation
        public void DeleteEmployee()
        {
            Console.WriteLine("Employee Id's:");
            DisplayEmployeeID();
            Console.WriteLine($"{EmployeeList.Count + 1}. Exit");
            Console.Write("Enter Employee Id/Enter exit:");
            string id = Console.ReadLine()!.ToUpper();
            if (id == "EXIT")
            {
                return;
            }
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
            Console.WriteLine("Employee Id's:");
            DisplayEmployeeID();
            Console.WriteLine($"{EmployeeList.Count + 1}. Exit");
            Console.Write("Choose from the above list:");
            int.TryParse(Console.ReadLine(), out int index);
            if (index == EmployeeList.Count + 1)
            {
                return;
            }
            if (index > 0 && index <= EmployeeList.Count)
            {
                if (EmployeeList[index - 1].Id != "None")
                {
                    string managerName = GetManagerName(EmployeeList[index - 1]);
                    Console.WriteLine("{0,-8} {1,-24} {2,-12} {3,-18} {4,-12} {5,-12} {6,-15} {7,-12} ", "Id", "Full Name", "JoinDate", "Location", "JobTitle", "Department", "ManagerName", "Project");
                    Console.WriteLine(new string('-', 125));
                    Console.WriteLine("{0,-8} {1,-24} {2,-12} {3,-18} {4,-12} {5,-12} {6,-15} {7,-12} ", EmployeeList[index - 1].Id, EmployeeList[index - 1].FirstName + " " + EmployeeList[index - 1].LastName, EmployeeList[index - 1].JoinDate, EmployeeList[index - 1].Location, EmployeeList[index - 1].JobTitle, EmployeeList[index - 1].Department, managerName, EmployeeList[index - 1].Project);
                }
                else
                {
                    Console.WriteLine("Employee Id doesn't exists");
                }
            }
            else
            {
                Console.WriteLine("Choose from above options only.");
            }
        }
        public void DisplayAll()
        {
            Console.WriteLine($"\nNo of Employee records in the Database are: {EmployeeList.Count}");
            Console.WriteLine("{0,-8} {1,-24} {2,-12} {3,-18} {4,-12} {5,-12} {6,-15} {7,-12} ", "Id", "Full Name", "JoinDate", "Location", "JobTitle", "Department", "ManagerName", "Project");
            foreach (var employee in EmployeeList)
            {
                string managerName = GetManagerName(employee);
                Console.WriteLine(new string('-', 125));
                Console.WriteLine("{0,-8} {1,-24} {2,-12} {3,-18} {4,-12} {5,-12} {6,-15} {7,-12} ", employee.Id, employee.FirstName + " " + employee.LastName, employee.JoinDate, employee.Location, employee.JobTitle, employee.Department, managerName, employee.Project);
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
        private bool GetEmployeeInputValues(EmployeeModel employee)
        {
            employee.FirstName = _employeePropertyEntryManager.GetFirstName();
            if (employee.FirstName == "Abort")
            {
                return false;
            }
            employee.LastName = _employeePropertyEntryManager.GetLastName();
            if (employee.LastName == "Abort")
            {
                return false;
            }
            employee.DateOfBirth = _employeePropertyEntryManager.GetDateOfBirth();
            if (employee.DateOfBirth == "Abort")
            {
                return false;
            }
            employee.Email = _employeePropertyEntryManager.GetEmail();
            if (employee.Email == "Abort")
            {
                return false;
            }
            employee.MobileNumber = _employeePropertyEntryManager.GetMobileNo();
            if (employee.MobileNumber == "Abort")
            {
                return false;
            }
            employee.JoinDate = _employeePropertyEntryManager.GetJoiningDate();
            if (employee.JoinDate == "Abort")
            {
                return false;
            }
            employee.JobTitle = _employeePropertyEntryManager.ChooseRole(ref RoleManagement.RoleList);
            if (employee.JobTitle == "Abort")
            {
                return false;
            }
            employee.Location = _employeePropertyEntryManager.ChooseLocation(employee, RoleManagement.RoleList);
            if (employee.Location == "Abort")
            {
                return false;
            }
            employee.Department = _employeePropertyEntryManager.ChooseDepartment(employee, RoleManagement.RoleList);
            if (employee.Department == "Abort")
            {
                return false;
            }
            employee.ManagerId = _employeePropertyEntryManager.ChooseManager(employee, EmployeeList);
            if (employee.ManagerId == "Abort")
            {
                return false;
            }
            employee.Project = _employeePropertyEntryManager.GetProjectName(_projectList);
            if (employee.Project == "Abort")
            {
                return false;
            }
            return true;
        }
        public void AddEmployee()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Options:");
                Console.WriteLine("1. Choose to Enter Id");
                Console.WriteLine("2. Exit");
                Console.Write("Choose options from above List:");
                int.TryParse(Console.ReadLine(), out int option);
                if (option == 2)
                {
                    flag = false;
                }
                else if (option == 1)
                {
                    Console.Write("Enter Employee Id(TZ0001)*:");
                    string empId = Console.ReadLine().ToUpper();
                    if (Validation.ValidateEmployeeId(empId) && CheckIdExists(empId) == -1)
                    {
                        EmployeeModel emp = new EmployeeModel();
                        emp.Id = empId;
                        bool addResult = GetEmployeeInputValues(emp);
                        if (addResult)
                        {
                            _employeeManager.Create(emp, ref EmployeeList);
                        }
                        flag = false;
                    }
                    else { Console.WriteLine("Employee Id Exists or Employee Id not following the Pattern('TZ0101') so enter again"); }
                }
                else
                {
                    Console.WriteLine("Choose from above options only.");
                }

            }

        }
    }
}
