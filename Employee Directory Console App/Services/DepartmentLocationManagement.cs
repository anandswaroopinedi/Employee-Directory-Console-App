using EmployeeDirectoryConsoleApp.Interfaces;
using EmployeeDirectoryConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.Services
{
    public class DepartmentLocationManagement:IDepartmentLocationManagement
    {
        private readonly IStartApp _employeeDirectory;
        private readonly IDepartment _department;
        private readonly ILocation _location;
        public DepartmentLocationManagement(IStartApp employeeDirectory, IDepartment department, ILocation location)
        {
            _employeeDirectory = employeeDirectory;
            _department = department;
            _location = location;
        }

        public  void DisplayMenu()
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
                    _department.AddDepartment(model);
                    break;
                case 2:
                    LocationModel model1 = new LocationModel();
                    _location.AddLocation(model1);
                    break;
                case 3:
                    _employeeDirectory.Run();
                    break;
                default:
                    Console.WriteLine("Select option from the above list only\n");
                    break;
            }
        }
    }
}
