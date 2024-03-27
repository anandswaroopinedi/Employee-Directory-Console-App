using DepartmentManagementLibrary.Interfaces;
using LocationManagementLibrary.Interfaces;
using Models;
using Presentation.Interfaces;

namespace Presentation.Services
{
    public class DisplayMenuManagement : IDisplayMenuManagement
    {
        private readonly IEmployeeManagement _employeeManagement;
        /*private readonly IRoleDisplayMenuManagement _roleDisplayMenuManagement;*/
        private readonly ILocationManager _locationManager;
        private readonly IDepartmentManager _departmentManager;
        private readonly IRoleManagement _roleManagement;
        public DisplayMenuManagement(IEmployeeManagement employeeManagement,/* IRoleDisplayMenuManagement roleDisplayMenuManagement,*/ ILocationManager locationManager, IDepartmentManager departmentManager, IRoleManagement roleManagement)
        {
            _employeeManagement = employeeManagement;
            /*_roleDisplayMenuManagement = roleDisplayMenuManagement;*/
            _departmentManager = departmentManager;
            _locationManager = locationManager;
            _roleManagement = roleManagement;

        }
        public void StartAppDisplayOptionMenu()
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
                        this.EmployeeManagementDisplayMenu();
                        break;
                    case 2:
                        this.RoleManagementDisplayMenu();
                        break;
                    case 3:
                        this.DepartmentLocationDisplayMenu();
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
        private bool EmployeeDisplayDefaultMenu()
        {
            bool flag = true;
            Console.WriteLine("Options :");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Go Back");
            Console.Write("Choose any1 option from above:");
            int option;
            int.TryParse(Console.ReadLine(), out option);
            switch (option)
            {

                case 1:
                    _employeeManagement.AddEmployee();
                    break;
                case 2:
                    flag = false;
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
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Display All");
            Console.WriteLine("3. Display One");
            Console.WriteLine("4. Edit Employee");
            Console.WriteLine("5. Delete Employees");
            Console.WriteLine("6. Go Back");
            Console.Write("Choose any option from above:");
            int option;
            int.TryParse(Console.ReadLine(), out option);
            switch (option)
            {
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
                case 6:
                    flag = false;
                    break;
                default:
                    Console.WriteLine("Select option from the above list only\n");
                    break;
            }
            return flag;
        }
        //To Display Menu
        public void EmployeeManagementDisplayMenu()
        {

            bool flag = true;
            while (flag)
            {
                if (EmployeeManagement.EmployeeList.Count < 1)
                {
                    flag = EmployeeDisplayDefaultMenu();
                }

                else
                {
                    flag = EmployeeDisplayAdjustedMenu();
                }
            }
        }
        public void RoleManagementDisplayMenu()
        {
            bool flag = true;
            while (flag)
            {

                Console.WriteLine("Options :");
                Console.WriteLine("1. Add Role");
                Console.WriteLine("2. Display All");
                Console.WriteLine("3. Go Back");
                Console.Write("Choose any option from above:");
                int option;
                int.TryParse(Console.ReadLine(), out option);
                switch (option)
                {
                    case 1:
                        _roleManagement.AddRole();
                        break;
                    case 2:
                        _roleManagement.DisplayAll();
                        break;
                    case 3:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Select option from the above list only\n");
                        break;
                }
            }
        }
        public void DepartmentLocationDisplayMenu()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Options:");
                Console.WriteLine("1. Add Department");
                Console.WriteLine("2. Add Location");
                Console.WriteLine("3. Go Back");
                int option;
                Console.Write("Choose any option from above:");
                int.TryParse(Console.ReadLine(), out option);
                switch (option)
                {
                    case 1:
                        DepartmentModel model = new DepartmentModel();
                        _departmentManager.AddDepartment(model,ref StartApp.DepartmentList);
                        break;
                    case 2:
                        LocationModel model1 = new LocationModel();
                        _locationManager.AddLocation(model1,ref StartApp.LocationList);
                        break;
                    case 3:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Select option from the above list only\n");
                        break;
                }
            }
        }
    }
}
