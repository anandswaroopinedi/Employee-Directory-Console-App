using EmployeeDirectoryConsoleApp.DataPresentation.Interface;
using EmployeeDirectoryConsoleApp.Interfaces;
using EmployeeDirectoryConsoleApp.Models;
using EmployeeDirectoryConsoleApp.StreamOperations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.Services
{
    public class EmployeePropertyEntries: IDuplicate2, IEmployeePropertyEntries
    {
        private readonly IRoleManagement _roleManagement;
        private readonly IDepartment _departmentHandler;
        private readonly ILocation _locationHandler;
        private readonly IDepartmentOperations _departmentOperations;
        private readonly ILocationOperations _locationOperations;
        public EmployeePropertyEntries(IRoleManagement roleManagement,IDepartment department,ILocation location,IDepartmentOperations departmentOperations,ILocationOperations locationOperations)
        {
            this._roleManagement = roleManagement;
            this._departmentHandler = department;
            this._locationHandler = location;
            this._departmentOperations = departmentOperations;
            this._locationOperations = locationOperations;
        }

        public string GetFirstName()
        {
            Console.Write("Enter Employee First Name*:");
            string empFirstName = Console.ReadLine();
            if(Validations.ValidateName(empFirstName))
            {
                return empFirstName;
            }
            else
            {
                Console.WriteLine("Enter FirstName Correctly");
                return GetFirstName();
            }
        }
        public string GetLastName()
        {
            Console.Write("Enter Employee Last Name*:");
            string empLastName = Console.ReadLine();
            if (Validations.ValidateName(empLastName))
            {
                return empLastName;
            }
            else
            {
                Console.WriteLine("Enter LastName Correctly");
                return GetLastName();
            }
        }
        public  string GetDateOfBirth()
        {
            Console.WriteLine("Date Of Birth:");
            Console.WriteLine("1. Upload Later");
            Console.WriteLine("2. Enter Manually Now");
            Console.Write("Choose from above options:");
            int.TryParse(Console.ReadLine(), out int option);
            switch (option)
            {
                case 1:
                    return "None";
                case 2:
                    Console.Write("Enter Date Of Birth(DD|MM|YYYY):");
                    string dob = Console.ReadLine();
                    DateTime dateTime= DateTime.Parse("2000-01-01");
                    DateTime date=new DateTime();
                    if(DateTime.TryParse(dob,out date)&&date<dateTime)
                    {
                        return dob;
                    }
                    Console.WriteLine("Enter Date Of Birth Correctly");
                    return GetDateOfBirth();
                default:
                    Console.WriteLine("Select option from the above list only");
                    return GetDateOfBirth();
            }
        }
        public  string GetEmail() 
        {
            Console.Write("Enter Employee Email*:");
            string empEmail = Console.ReadLine();
            if (Validations.ValidateEmail(empEmail))
            {
                return empEmail;
            }
            else
            {
                Console.WriteLine("The entered email is not valid");
                return GetEmail();
            }
        }
        public  string GetMobileNo()
        {
            Console.WriteLine("Mobile Number:");
            Console.WriteLine("1. Upload Later");
            Console.WriteLine("2. Enter Manually Now");
            Console.Write("Choose from above options:");
            int.TryParse(Console.ReadLine(), out int option);
            switch (option)
            {
                case 1:
                    return "None";
                case 2:
                    Console.Write("Enter Mobile No:");
                    string mobNo = Console.ReadLine();
                    if (Validations.ValidateMobileNumber(mobNo))
                    {
                        return mobNo;
                    }
                    else
                    {
                        Console.WriteLine("Entered mobile number is invalid");
                        return GetMobileNo();
                    }
                default:
                    Console.WriteLine("Select option from the above list only");
                    return GetMobileNo();
            }
        }
        public  string GetJoiningDate()
        {
            Console.Write("Enter Joining Date(DD/MM/YYYY)*:");
            string JoiningDate = Console.ReadLine();
            if (Validations.ValidateJoiningDate(JoiningDate))
            {
                return JoiningDate;
            }
            else
            {
                Console.WriteLine("Entered Joining Date is Invalid");
                return GetJoiningDate();
            }
        }
        public  string GetProjectName()
        {
            Console.WriteLine("Project Details:");
            Console.WriteLine("1. Upload Later");
            Console.WriteLine("2. Enter Manually Now");
            Console.Write("Choose from above options:");
            int.TryParse(Console.ReadLine(), out int option);
            switch (option)
            {
                case 1:
                    return "None";
                case 2:
                    Console.Write("Enter the Project Name Working On:");
                    string projectNmae = Console.ReadLine();
                    if (projectNmae != "")
                    {
                        return projectNmae;
                    }
                    else
                    {
                        Console.WriteLine("Enter Project Name or Upload it later");
                    }
                    break;
                default:
                    Console.WriteLine("Select option from the above list only");
                    return GetProjectName();
            }
            return "None";

        }
        public static  string CreateLocationRef(ILocation location,ILocationOperations locationOperations)
        {
            LocationModel locationModel = new LocationModel();
            location.AddLocation(locationModel);
            locationOperations.write();
            return locationModel.Name;
        }
        public static  void DisplayLocationList()
        {
            for (int i = 0; i < StartApp.LocationList.Count; i++)
            {
                Console.WriteLine($"{i + 1}.  {StartApp.LocationList[i].Name}");
            }
        }
        public  string ChooseLocation()
        {
            Console.WriteLine("Locations:");
            Console.WriteLine("0.  Add New Location");
            DisplayLocationList();
            Console.Write("Choose Location from above options:");
            int option;
            int.TryParse(Console.ReadLine(), out option);
            if (option == 0)
            {
                return CreateLocationRef(_locationHandler, _locationOperations);
            }
            if (option > 0 && option <= StartApp.LocationList.Count)
            {
                return StartApp.LocationList[option-1].Name;
            }
            else
            {
                Console.WriteLine("Select option from the above list only");
                return ChooseLocation();
            }
        }
        public static void DisplayDepartmentList()
        {
            for (int i = 0; i < StartApp.DepartmentList.Count; i++)
            {
                Console.WriteLine($"{i + 1}.  {StartApp.DepartmentList[i].Name}");
            }
        }
        public static string CreateDepartmentRef(IDepartment department,IDepartmentOperations departmentOperations)
        {
            DepartmentModel departmentModel = new DepartmentModel();
            department.AddDepartment(departmentModel);
            departmentOperations.write();
            return departmentModel.Name;
        }
        public  string ChooseDepartment()
        {
            int option;
            Console.WriteLine("Departments:");
            Console.WriteLine("0. Add New Department");
            DisplayDepartmentList();
            Console.Write("Choose Department from above options*:");
            int.TryParse(Console.ReadLine(), out option);
            if(option==0)
            {
                return CreateDepartmentRef(_departmentHandler, _departmentOperations);
            }
            if (option > 0 && option <= StartApp.DepartmentList.Count)
            {
                return StartApp.DepartmentList[option-1].Name;
            }
            else
            {
                Console.WriteLine("Select option from the above list only");
                return ChooseDepartment();
            }
        }
        public static void DisplayRolesNames()
        {
            for (int i = 0; i < RoleManagement.RoleList.Count; i++)
            {
                Console.WriteLine($"{i + 1}.  {RoleManagement.RoleList[i].Name}");
            }
        }
        public  string ChooseRole()
        {
            int option;
            Console.WriteLine("Roles:");
            Console.WriteLine("0. Enter New Role:");
            DisplayRolesNames();
            Console.Write("Choose Roles from above options*:");
            int.TryParse(Console.ReadLine(), out option);
            if(option==0)
            {
                _roleManagement.AddRole();
                return RoleManagement.RoleList[RoleManagement.RoleList.Count-1].Name;
            }
            if (option > 0 && option <= RoleManagement.RoleList.Count)
            {
                return RoleManagement.RoleList[option-1].Name;
            }
            else
            {
                Console.WriteLine("Select option from the above list only");
                return ChooseRole();
            }
        }
        public static string DisplayEmployeeId(EmployeeModel employee)
        {
            for(int i = 0;i<EmployeeManagement.EmployeeList.Count && EmployeeManagement.EmployeeList[i].Id!=employee.Id;i++)
            {
                Console.WriteLine($"{i + 1}  {EmployeeManagement.EmployeeList[i].Id}  {EmployeeManagement.EmployeeList[i].FirstName+"  "+ EmployeeManagement.EmployeeList[i].LastName}");
            }
            Console.Write("Choose from above options:");
            int.TryParse(Console.ReadLine(), out int option);
            if(option>0 && option<= EmployeeManagement.EmployeeList.Count)
            {
                return EmployeeManagement.EmployeeList[option - 1].Id;
            }
            else
            {
                return DisplayEmployeeId(employee);
            }
        }
        public  string ChooseManager(EmployeeModel emp)
        {
            string managerId = "";
            Console.WriteLine("Manager Details:");
            Console.WriteLine("1. Upload Later");
            Console.WriteLine("2. Enter Manually");
            Console.Write("Choose from above options:");
            int.TryParse(Console.ReadLine(), out int option);
            switch (option)
            {
                case 1:
                    managerId = "None";
                    break;
                case 2:
                    managerId = DisplayEmployeeId(emp);
                    if (Validations.ValidateManagerId(managerId))
                    {
                        return managerId;
                    }
                    else
                    {
                        Console.WriteLine("The ManagerId entered is invalid or not in records or matching the Employee id itself");
                        return ChooseManager(emp);
                    }
                default:
                    Console.WriteLine("Select option from the above list only");
                    return ChooseManager(emp);
            }
            return managerId;
        }
        public  string GetDescription()
        {
            string description = "";
            Console.WriteLine("Description:");
            Console.WriteLine("1. Upload Later");
            Console.WriteLine("2. Enter Description");
            Console.Write("Choose from above options:");
            int.TryParse(Console.ReadLine(), out int option);
            switch (option)
            {
                case 1:
                    description = "None";
                    return description;
                case 2:
                    Console.Write("Enter the Manger Id:");
                    description = Console.ReadLine();
                    if(description=="")
                    {
                        return GetDescription();
                    }
                    else
                    {
                        return description;
                    }
                default:
                    Console.WriteLine("Select option from the above list only");
                    return GetDescription();
            }
        }
        public  void DisplayHeaders()
        {

            for (int j = 1; j < EmployeeModel.Headers.Length; j++)
            {
                Console.WriteLine($"{j}. {EmployeeModel.Headers[j]}");
            }
        }
    }
}
