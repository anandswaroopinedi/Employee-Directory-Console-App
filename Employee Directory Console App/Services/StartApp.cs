using EmployeeDirectoryConsoleApp.DataPresentation;
using EmployeeDirectoryConsoleApp.DataPresentation.Interface;
using EmployeeDirectoryConsoleApp.Interfaces;
using EmployeeDirectoryConsoleApp.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.Services
{
    public class StartApp:IStartApp,IDuplicate
    {
        public static List<DepartmentModel> DepartmentList = new List<DepartmentModel>();
        public static List<LocationModel> LocationList = new List<LocationModel>();
        private readonly ILocationOperations _locationOperations;
        private readonly IRoleOperations _roleOperations;
        private readonly IDepartmentOperations _departmentOperations;
        private readonly IEmployeeManagement _employeeManagement;
        private readonly IRoleManagement _roleManagement;
        private readonly IDepartmentLocationManagement _departmentLocationManagement;
        private readonly IEmployeeOperations _employeeOperations;
        public StartApp(ILocationOperations locationOperations, IRoleOperations roleOperations, IDepartmentOperations departmentOperations, IEmployeeManagement employeeManagement, IRoleManagement roleManagement, IDepartmentLocationManagement departmentLocationManagement, IEmployeeOperations employeeOperations)
        {
            _locationOperations = locationOperations;
            _roleOperations = roleOperations;
            _departmentOperations = departmentOperations;
            _employeeManagement = employeeManagement;
            _roleManagement = roleManagement;
            _departmentLocationManagement = departmentLocationManagement;
            _employeeOperations = employeeOperations;
        }
        public void Register()
        {

            this.Run();
        }
        public void DisplayOptionMenu()
        {
            Console.WriteLine("Welcome to Employee Directory Console App");
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1. Employee Management");
                Console.WriteLine("2. Role Management");
                Console.WriteLine("3. Department and Location Management");
                Console.WriteLine("4. Exit");
                Console.Write("Choose any option from above:");
                int option;
                int.TryParse(Console.ReadLine(), out option);
                switch (option)
                {
                    case 1:
                        _employeeManagement.DisplayMenu();
                        break;
                    case 2:
                        _roleManagement.DisplayMenu();
                        break;
                    case 3:
                        _departmentLocationManagement.DisplayMenu();
                        break;
                    case 4:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Select option from the above list only\n");
                        break;
                }
            }
            Console.WriteLine("Thank You for visiting our application");
        }
        public void Run()
        {
            DepartmentList = _departmentOperations.read();
            LocationList = _locationOperations.read();
            RoleManagement.RoleList = _roleOperations.read();
            EmployeeManagement.EmployeeList = _employeeOperations.read();
            this.DisplayOptionMenu();
        }
    }
}
