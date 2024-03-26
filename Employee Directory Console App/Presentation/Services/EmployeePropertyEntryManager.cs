using EmployeeDirectoryConsoleApp.Models;
using EmployeeDirectoryConsoleApp.Presentation.Interfaces;
using EmployeeDirectoryConsoleApp.Validations;

namespace EmployeeDirectoryConsoleApp.Presentation.Services
{
    public class EmployeePropertyEntryManager : IEmployeePropertyEntryManager
    {
        private readonly IRoleManagement _roleManagement;
        public EmployeePropertyEntryManager(IRoleManagement roleManagement)
        {
            _roleManagement = roleManagement;
        }
        public string GetFirstName()
        {
            Console.Write("Enter Employee First Name*:");
            string empFirstName = Console.ReadLine();
            if (Validation.ValidateName(empFirstName))
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
            if (Validation.ValidateName(empLastName))
            {
                return empLastName;
            }
            else
            {
                Console.WriteLine("Enter LastName Correctly");
                return GetLastName();
            }
        }
        public string GetDateOfBirth()
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
                    DateTime dateTime = DateTime.Parse("2000-01-01");
                    DateTime date = new DateTime();
                    if (DateTime.TryParse(dob, out date) && date < dateTime)
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
        public string GetEmail()
        {
            Console.Write("Enter Employee Email*:");
            string empEmail = Console.ReadLine();
            if (Validation.ValidateEmail(empEmail))
            {
                return empEmail;
            }
            else
            {
                Console.WriteLine("The entered email is not valid");
                return GetEmail();
            }
        }
        public string GetMobileNo()
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
                    if (Validation.ValidateMobileNumber(mobNo))
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
        public string GetJoiningDate()
        {
            Console.Write("Enter Joining Date(DD/MM/YYYY)*:");
            string JoiningDate = Console.ReadLine();
            if (Validation.ValidateJoiningDate(JoiningDate))
            {
                return JoiningDate;
            }
            else
            {
                Console.WriteLine("Entered Joining Date is Invalid");
                return GetJoiningDate();
            }
        }
        public string GetProjectName()
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




        public static string DisplayEmployeeId(EmployeeModel employee)
        {
            for (int i = 0; i < EmployeeManagement.EmployeeList.Count && EmployeeManagement.EmployeeList[i].Id != employee.Id; i++)
            {
                Console.WriteLine($"{i + 1}  {EmployeeManagement.EmployeeList[i].Id}  {EmployeeManagement.EmployeeList[i].FirstName + "  " + EmployeeManagement.EmployeeList[i].LastName}");
            }
            Console.Write("Choose from above options:");
            int.TryParse(Console.ReadLine(), out int option);
            if (option > 0 && option <= EmployeeManagement.EmployeeList.Count)
            {
                return EmployeeManagement.EmployeeList[option - 1].Id;
            }
            else
            {
                return DisplayEmployeeId(employee);
            }
        }
        public string ChooseManager(EmployeeModel emp)
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
                    if (Validation.ValidateManagerId(managerId) && EmployeeManagement.CheckIdExists(managerId) != -1)
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
        public static void DisplayRolesNames()
        {
            for (int i = 0; i < RoleManagement.RoleList.Count; i++)
            {
                Console.WriteLine($"{i + 1}.  {RoleManagement.RoleList[i].Name}");
            }
        }
        public string ChooseRole()
        {
            int option;
            Console.WriteLine("Roles:");
            Console.WriteLine("0. Enter New Role:");
            DisplayRolesNames();
            Console.Write("Choose Roles from above options*:");
            int.TryParse(Console.ReadLine(), out option);
            if (option == 0)
            {
                /*RoleManagement roleManagement = new RoleManagement();*/
                _roleManagement.AddRole();
                return RoleManagement.RoleList[RoleManagement.RoleList.Count - 1].Name;
            }
            if (option > 0 && option <= RoleManagement.RoleList.Count)
            {
                return RoleManagement.RoleList[option - 1].Name;
            }
            else
            {
                Console.WriteLine("Select option from the above list only");
                return ChooseRole();
            }
        }

        public void DisplayHeaders()
        {

            for (int j = 1; j < EmployeeModel.Headers.Length; j++)
            {
                Console.WriteLine($"{j}. {EmployeeModel.Headers[j]}");
            }
        }
    }
}
