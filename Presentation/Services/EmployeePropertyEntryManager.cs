/*using Presentation.Interfaces;*/
using Models;
using Presentation.Interfaces;
using Validations;

namespace Presentation.Services
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
            Console.WriteLine("Options:");
            Console.WriteLine("1. Choose to Enter First Name");
            Console.WriteLine("2. Exit");
            Console.Write("Choose options from above List:");
            int.TryParse(Console.ReadLine(), out int option);
            if (option == 2)
            {
                return "Abort";
            }
            else if (option == 1) 
            {
                Console.Write("Enter Employee FirstName*:");
                string empFirstName = Console.ReadLine();
                if (Validation.ValidateName(empFirstName))
                {
                    return empFirstName;
                }
                else
                {
                    Console.WriteLine("The First Name should only contains alphabets");
                    return GetFirstName();
                }
            }
            else {
                Console.WriteLine("You should choose options from above List only");
                return  GetFirstName(); }
        }
        public string GetLastName()
        {
            Console.WriteLine("Options:");
            Console.WriteLine("1. Choose to Enter LastName");
            Console.WriteLine("2. Exit");
            Console.Write("Choose options from above List:");
            int.TryParse(Console.ReadLine(), out int option);
            if (option == 2)
            {
                return "Abort";
            }
            else if (option == 1)
            {
                Console.Write("Enter Employee Last Name*:");
                string empLastName = Console.ReadLine();
                if (Validation.ValidateName(empLastName))
                {
                    return empLastName;
                }
                else
                {
                    Console.WriteLine("The Last Name should only contains alphabets");
                    return GetLastName();
                }
            }
            else
            {
                Console.WriteLine("You should choose options from above List only");
                return GetLastName();
            }
        }
        public string GetDateOfBirth()
        {
                Console.WriteLine("Date Of Birth:");
                Console.WriteLine("1. Upload Later");
                Console.WriteLine("2. Enter Manually Now");
                Console.WriteLine("3. Exit");
                Console.Write("Choose from above options:");
                int.TryParse(Console.ReadLine(), out int res);
                switch (res)
                {
                    case 1:
                        return "None";
                    case 2:
                        Console.Write("Enter Date Of Birth(DD/MM/YYYY):");
                        string dob = Console.ReadLine();
                        DateTime dateTime = DateTime.Parse("01/01/2003");
                        DateTime date = new DateTime();
                        if (DateTime.TryParse(dob, out date) && date < dateTime)
                        {
                            return dob;
                        }
                        Console.WriteLine("Enter Date Of Birth Correctly(It should be dd/mm/yyyy format and should be less than 01/01/2003)");
                        return GetDateOfBirth();
                    case 3:return "Abort";
                    default:
                        Console.WriteLine("Select option from the above list only");
                        return GetDateOfBirth();
                }
        }
        public string GetEmail()
        {
            Console.WriteLine("Options:");
            Console.WriteLine("1. Choose to Enter Email");
            Console.WriteLine("2. Exit");
            Console.Write("Choose options from above List:");
            int.TryParse(Console.ReadLine(), out int option);
            if (option == 2)
            {
                return "Abort";
            }
            else if (option == 1)
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
            else
            {
                Console.WriteLine("You should choose options from above List only");
                return GetEmail();
            }
        }
        public string GetMobileNo()
        {
                Console.WriteLine("Mobile Number:");
                Console.WriteLine("1. Upload Later");
                Console.WriteLine("2. Enter Manually Now");
                Console.WriteLine("3. Exit");
                Console.Write("Choose from above options:");
                int.TryParse(Console.ReadLine(), out int res);
                switch (res)
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
                            Console.WriteLine("Entered mobile number is invalid(It should contain only numeric characters and of length 10)");
                            return GetMobileNo();
                        }
                    case 3:return "Abort";
                    default:
                        Console.WriteLine("Select option from the above list only");
                        return GetMobileNo();
                }
        }
        public string GetJoiningDate()
        {
            Console.WriteLine("Options:");
            Console.WriteLine("1. Choose to Enter Joining Date");
            Console.WriteLine("2. Exit");
            Console.Write("Choose options from above List:");
            int.TryParse(Console.ReadLine(), out int option);
            if (option == 2)
            {
                return "Abort";
            }
            else if (option == 1)
            {
                
                Console.Write("Enter Joining Date(DD/MM/YYYY)*:");
                string JoiningDate = Console.ReadLine();
                if (Validation.ValidateJoiningDate(JoiningDate))
                {
                    return JoiningDate;
                }
                else
                {
                    Console.WriteLine("Entered Joining Date is Invalid(It should follow dd/mm/yyyy format and less than today date)");
                    return GetJoiningDate();
                }
            }
            else
            {
                Console.WriteLine("You should choose options from above List only");
                return GetJoiningDate();
            }
        }
        public string GetProjectName(List<string> projectDetails)
        {
                Console.WriteLine("Project Details:");
                Console.WriteLine("0. Enter Manually");
                for (int i = 0; i < projectDetails.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.  {projectDetails[i]}");
                }
                Console.WriteLine($"{projectDetails.Count+1}. Exit");
                Console.Write("Choose from above options:");
                int.TryParse(Console.ReadLine(), out int option);
                if(option == projectDetails.Count + 1)
                {
                    return "Abort";
                }
                if (option == 0)
                {
                    Console.Write("Input the Project Name:");
                    string name = Console.ReadLine();
                    if (Validation.ValidateName(name))
                    {
                        return name;
                    }
                    Console.WriteLine("Enter the project name Correctly (It should not contain numeric characters).");
                    return GetProjectName(projectDetails);
                }
                if (option > 0 && option <= projectDetails.Count)
                {
                    return projectDetails[option - 1];
                }
                else
                {
                    Console.WriteLine("Select option from the above list only");
                    return this.GetProjectName(projectDetails);
                }

        }




        public static string DisplayEmployeeId(EmployeeModel employee, List<EmployeeModel> employeeList)
        {
            for (int i = 0; i < employeeList.Count && employeeList[i].Id != employee.Id; i++)
            {
                Console.WriteLine($"{i + 1}  {employeeList[i].Id}  {employeeList[i].FirstName + "  " + employeeList[i].LastName}");
            }
            Console.Write("Choose from above options:");
            int.TryParse(Console.ReadLine(), out int option);
            if (option > 0 && option <= employeeList.Count)
            {
                return employeeList[option - 1].Id;
            }
            else
            {
                return DisplayEmployeeId(employee, employeeList);
            }
        }
        public static int CheckIdExists(string id, List<EmployeeModel> employeeList)
        {
            for (int i = 0; i < employeeList.Count; i++)
            {
                if (employeeList[i].Id == id)
                    return i;
            }

            return -1;
        }
        public string ChooseManager(EmployeeModel emp, List<EmployeeModel> employeeList)
        {
                string managerId = "";
                Console.WriteLine("Manager Details:");
                Console.WriteLine("1. Upload Later");
                Console.WriteLine("2. Enter Manually");
                Console.WriteLine("3. Exit");
                Console.Write("Choose from above options:");
                int.TryParse(Console.ReadLine(), out int option);
                switch (option)
                {
                    case 1:
                        managerId = "None";
                        break;
                    case 2:
                        managerId = DisplayEmployeeId(emp, employeeList);
                        if (Validation.ValidateManagerId(managerId) || CheckIdExists(managerId, employeeList) != -1)
                        {
                            return managerId;
                        }
                        else
                        {
                            Console.WriteLine("The ManagerId entered is invalid or not in records or matching the Employee id itself");
                            return ChooseManager(emp, employeeList);
                        }
                    case 3:return "Abort";
                    default:
                        Console.WriteLine("Select option from the above list only");
                        return ChooseManager(emp, employeeList);
                }
                return managerId;
        }
        public static void DisplayRolesNames(List<RolesModel> rolesList)
        {
            for (int i = 0; i < rolesList.Count; i++)
            {
                Console.WriteLine($"{i + 1}.  {rolesList[i].Name}");
            }
        }
        public string ChooseRole(ref List<RolesModel> rolesList)
        {
                int option;
                Console.WriteLine("Roles:");
                Console.WriteLine("0. Enter New Role:");
                DisplayRolesNames(rolesList);
                Console.WriteLine($"{rolesList.Count+1}. Exit");
                Console.Write("Choose Roles from above options*:");
                int.TryParse(Console.ReadLine(), out option);
                if(option == rolesList.Count+1)
                {
                    return "Abort";
                }
                if (option == 0)
                {
                    /*RoleManagement roleManagement = new RoleManagement();*/
                    _roleManagement.AddRole();
                    return rolesList[rolesList.Count - 1].Name;
                }
                if (option > 0 && option <= rolesList.Count)
                {
                    return rolesList[option - 1].Name;
                }
                else
                {
                    Console.WriteLine("Select option from the above list only");
                    return ChooseRole(ref rolesList);
                }
        }

        public void DisplayHeaders()
        {

            for (int j = 1; j < EmployeeModel.Headers.Length; j++)
            {
                Console.WriteLine($"{j}. {EmployeeModel.Headers[j]}");
            }
        }
        public string ChooseDepartment(EmployeeModel employee, List<RolesModel> rolesList)
        {
                List<string> departments = new List<string>();
                Console.WriteLine("Select Department:");
                for (int j = 0; j < rolesList.Count; j++)
                {
                    if (rolesList[j].Name == employee.JobTitle)
                    {
                        departments.Add(rolesList[j].Department);
                        Console.WriteLine($"{departments.Count}. {rolesList[j].Department}");
                    }
                }
                Console.WriteLine($"{departments.Count+1}. Exit");
                Console.Write("Choose from the above options:");
                int.TryParse(Console.ReadLine(), out int option);
                if(option == departments.Count + 1)
                {
                    return "Abort";
                }
                if (option > 0 && option <= departments.Count)
                {
                    return departments[option - 1];
                }
                else
                {
                    Console.WriteLine("You can only choose from above list");
                }
                return ChooseDepartment(employee, rolesList);
        }
        public string ChooseLocation(EmployeeModel employee, List<RolesModel> rolesList)
        {
                List<string> locations = new List<string>();
                Console.WriteLine("Select Location:");
                for (int j = 0; j < rolesList.Count; j++)
                {
                    if (rolesList[j].Name == employee.JobTitle)
                    {
                        locations.Add(rolesList[j].Location);
                        Console.WriteLine($"{locations.Count}. {rolesList[j].Location}");
                    }
                }
                Console.WriteLine($"{locations.Count+1}. Exit");
                Console.Write("Choose from the above options:");
                int.TryParse(Console.ReadLine(), out int option);
                if (option ==locations.Count+1)
                {
                    return "Abort";
                }
                if (option > 0 && option <= locations.Count)
                {
                    return locations[option - 1];
                }
                else
                {
                    Console.WriteLine("You can only choose from above list");
                }
                return ChooseLocation(employee, rolesList);
        }
    }
}
