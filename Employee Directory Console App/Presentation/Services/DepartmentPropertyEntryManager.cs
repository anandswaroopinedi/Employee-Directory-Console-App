using EmployeeDirectoryConsoleApp.Presentation.Interfaces;
using EmployeeDirectoryConsoleApp.DataPresentation.Interface;
using EmployeeDirectoryConsoleApp.Interfaces;
using EmployeeDirectoryConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.Presentation.Services
{
    public class DepartmentPropertyEntryManager:IDepartmentPropertyEntryManager
    {
        private readonly IDepartmentManager _departmentManager;
        private readonly IDepartmentOperations _departmentOperations;
        public DepartmentPropertyEntryManager(IDepartmentManager departmentManager, IDepartmentOperations departmentOperations)
        {
            _departmentManager = departmentManager;
            _departmentOperations = departmentOperations;
        }

        public static void DisplayDepartmentList()
        {
            for (int i = 0; i < StartApp.DepartmentList.Count; i++)
            {
                Console.WriteLine($"{i + 1}.  {StartApp.DepartmentList[i].Name}");
            }
        }
        public  string CreateDepartmentRef()
        {
            DepartmentModel departmentModel = new DepartmentModel();
            _departmentManager.AddDepartment(departmentModel);
            _departmentOperations.write();
            return departmentModel.Name;
        }
        public string ChooseDepartment()
        {
            int option;
            Console.WriteLine("Departments:");
            Console.WriteLine("0. Add New Department");
            DisplayDepartmentList();
            Console.Write("Choose Department from above options*:");
            int.TryParse(Console.ReadLine(), out option);
            if (option == 0)
            {
                return this.CreateDepartmentRef();
            }
            if (option > 0 && option <= StartApp.DepartmentList.Count)
            {
                return StartApp.DepartmentList[option - 1].Name;
            }
            else
            {
                Console.WriteLine("Select option from the above list only");
                return ChooseDepartment();
            }
        }
    }
}
