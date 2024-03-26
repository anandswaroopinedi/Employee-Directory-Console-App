using EmployeeDirectoryConsoleApp.DataPresentation.Interface;
using EmployeeDirectoryConsoleApp.Interfaces;
using EmployeeDirectoryConsoleApp.Models;
using EmployeeDirectoryConsoleApp.Presentation;

namespace EmployeeDirectoryConsoleApp.Services
{


    public class DepartmentManager : IDepartmentManager
    {

        private readonly IDepartmentOperations _departmentHandler;
        public DepartmentManager(IDepartmentOperations departmentHandler)
        {
            _departmentHandler = departmentHandler;
        }

        public static bool CheckDepartmentExists(string name)
        {
            for (int i = 0; i < StartApp.DepartmentList.Count; i++)
            {
                if (StartApp.DepartmentList[i].Name == name)
                    return true;
            }
            return false;
        }
        public void AddDepartment(DepartmentModel dept)
        {
            Console.Write("Enter New DepartMent Name:");
            string name = Console.ReadLine().ToUpper();
            if (!CheckDepartmentExists(name))
            {
                dept.Name = name;
                StartApp.DepartmentList.Add(dept);
                _departmentHandler.write();
            }
        }
    }
}
