using BusinessLogicLayer.Interfaces;
using DepartmentManagementLibrary.Interfaces;
using LocationManagementLibrary;
using LocationManagementLibrary.Interfaces;
using Models;
using Presentation.Interfaces;
using ProjectManagementLibrary;
using ProjectManagementLibrary.Interfaces;

namespace Presentation.Services
{
    public class DisplayMenuManagement : IDisplayMenuManagement
    {
        private readonly IEmployeeManagement _employeeManagement;
        private readonly ILocationManagement _locationManagement;
        private readonly IDepartmentManagement _departmentManagement;
        private readonly IRoleManagement _roleManagement;
        private readonly IEmployeeManager _employeeManager;
        private readonly IProjectManagement _projectManagement;
        private static List<String> _startAppDisplayMenu=new List<String>() { "Exit", "Employee Management", "Role Management", "Department and Location Management" };
        private static List<String> _employeeDisplayMenu = new List<string>() { "Go Back", "Add Employee", "Display All", "Display One", "Edit Employee", "Delete Employee" };
        private static List<String> _roleDisplaymenu = new List<string>() { "Go Back", "Add Role", "Display All" };
        public static List<String> _departmentLocationDisplaymenu = new List<String>() { "Go Back", "Add Department", "Display Departments", "Add Location", "Display Locations","Add Project","Display Projects" };
        public DisplayMenuManagement(IEmployeeManagement employeeManagement, ILocationManagement locationManagement, IDepartmentManagement departmentManagement, IRoleManagement roleManagement,IEmployeeManager employeeManager,IProjectManagement projectManagement)
        {
            _employeeManagement = employeeManagement;
            _departmentManagement = departmentManagement;
            _locationManagement = locationManagement;
            _roleManagement = roleManagement;
            _employeeManager = employeeManager;
            _projectManagement = projectManagement;
        }
        private static void DisplayMenus(List<string> menu)
        {
            for (int i = 0;i<menu.Count;i++)
            {
                Console.WriteLine($"{i}. {menu[i]}");
            }
        }
        public void StartAppDisplayOptionMenu()
        {
            Console.WriteLine("Welcome to Employee Directory Console App");
            bool flag = true;
            while (flag)
            {
                DisplayMenus(_startAppDisplayMenu);
                Console.Write("Choose any option from above:");
                int option;
                int.TryParse(Console.ReadLine(), out option);
                switch (option)
                {
                    case 0:
                        flag = false;
                        break;
                    case 1:
                        this.EmployeeManagementDisplayMenu();
                        break;
                    case 2:
                        this.RoleManagementDisplayMenu();
                        break;
                    case 3:
                        this.DepartmentLocationDisplayMenu();
                        break;
                    
                    default:
                        Console.WriteLine("Select option from the above list only\n");
                        break;
                }
            }
            Console.WriteLine("Thank You for visiting our application");
        }
        private bool EmployeeDisplayDefaultMenu()
        {
            bool flag = true;
            Console.WriteLine("Options :");
            Console.WriteLine("0. Go Back");
            Console.WriteLine("1. Add Employee");
            Console.Write("Choose any1 option from above:");
            int option;
            int.TryParse(Console.ReadLine(), out option);
            switch (option)
            {
                case 0:
                    flag = false;
                    break;
                case 1:
                    _employeeManagement.AddEmployee();
                    break;
                
                default:
                    Console.WriteLine("Select option from the above list only");
                    break;
            }
            return flag;
        }
        //Displaying Menu When Employee Json has more than 1 employee count

        private bool EmployeeDisplayAdjustedMenu()
        {
            bool flag = true;
            
            Console.WriteLine("Options :");
            DisplayMenus(_employeeDisplayMenu);
            Console.Write("Choose any option from above:");
            int option;
            int.TryParse(Console.ReadLine(), out option);
            switch (option)
            {
                case 0:
                    flag = false;
                    break;
                case 1:
                    _employeeManagement.AddEmployee();
                    break;
                case 2:
                    _employeeManagement.DisplayAll();
                    break;
                case 3:
                    _employeeManagement.DisplayOne();
                    break;
                case 4:
                    _employeeManagement.UpdateEmployee();
                    break;
                case 5:
                    _employeeManagement.DeleteEmployee();
                    break;
                default:
                    Console.WriteLine("Select option from the above list only\n");
                    break;
            }
            return flag;
        }
        //To Display Menu
        private void EmployeeManagementDisplayMenu()
        {

            bool flag = true;
            while (flag)
            {
                if (_employeeManager.GetAll().Count< 1)
                {
                    flag = EmployeeDisplayDefaultMenu();
                }

                else
                {
                    flag = EmployeeDisplayAdjustedMenu();
                }
            }
        }
        private void RoleManagementDisplayMenu()
        {
            bool flag = true;
            while (flag)
            {

                Console.WriteLine("Options :");
                DisplayMenus(_roleDisplaymenu);
                Console.Write("Choose any option from above:");
                int option;
                int.TryParse(Console.ReadLine(), out option);
                switch (option)
                {
                    case 0:
                        flag = false;
                        break;
                    case 1:
                        _roleManagement.AddRole();
                        break;
                    case 2:
                        _roleManagement.DisplayAll();
                        break;
                    
                    default:
                        Console.WriteLine("Select option from the above list only\n");
                        break;
                }
            }
        }
        private void DepartmentLocationDisplayMenu()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Options:");
                DisplayMenus(_departmentLocationDisplaymenu);
                int option;
                Console.Write("Choose any option from above:");
                int.TryParse(Console.ReadLine(), out option);
                switch (option)
                {
                    case 0:
                        flag = false;
                        break;
                    case 1:
                        _departmentManagement.AddDepartment();
                        break;
                    case 2:
                        _departmentManagement.DisplayAll();
                        break;
                    case 3:
                        _locationManagement.AddLocation();
                        break;
                    case 4:
                        _locationManagement.DisplayAll();
                        break;
                    case 5:
                        _projectManagement.AddProject();
                        break;
                    case 6:
                        _projectManagement.DisplayAll();
                        break;
                    default:
                        Console.WriteLine("Select option from the above list only\n");
                        break;
                }
            }
        }
    }
}
