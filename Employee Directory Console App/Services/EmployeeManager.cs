using EmployeeDirectoryConsoleApp.Interfaces;
using EmployeeDirectoryConsoleApp.Models;
using EmployeeDirectoryConsoleApp.StreamOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.Services
{
    public class EmployeeManager:IEmployeeManager
    {
        private readonly IEmployeePropertyEntries _employeePropertyEntries;
        public EmployeeManager(IEmployeePropertyEntries employeePropertyEntries) {
        this._employeePropertyEntries = employeePropertyEntries;
        }
        public void Create(EmployeeModel employee)
        {
            employee.FirstName = _employeePropertyEntries.GetFirstName();
            employee.LastName = _employeePropertyEntries.GetLastName();
            employee.DateOfBirth = _employeePropertyEntries.GetDateOfBirth();
            employee.Email = _employeePropertyEntries.GetEmail();
            employee.MobileNumber = _employeePropertyEntries.GetMobileNo();
            employee.JoinDate = _employeePropertyEntries.GetJoiningDate();
            employee.Location = _employeePropertyEntries.ChooseLocation();
            employee.JobTitle = _employeePropertyEntries.ChooseRole();
            employee.Department = _employeePropertyEntries.ChooseDepartment();
            employee.ManagerId = _employeePropertyEntries.ChooseManager(employee);
            employee.Project = _employeePropertyEntries.GetProjectName();
        }
        public void Update(EmployeeModel employee)
        {
            _employeePropertyEntries.DisplayHeaders();
            Console.Write("\nChoose the details to change:");
            int.TryParse(Console.ReadLine(), out int option);
            switch (option)
            {
                case 1:
                    employee.FirstName = _employeePropertyEntries.GetFirstName();
                    break;
                case 2:
                    employee.LastName = _employeePropertyEntries.GetLastName();
                    break;
                case 3:
                    employee.DateOfBirth = _employeePropertyEntries.GetDateOfBirth();
                    break;
                case 4:
                    employee.Email = _employeePropertyEntries.GetEmail();
                    break;
                case 5:
                    employee.MobileNumber = _employeePropertyEntries.GetMobileNo();
                    break;
                case 6:
                    employee.JoinDate = _employeePropertyEntries.GetJoiningDate();
                    break;
                case 7:
                    employee.Location = _employeePropertyEntries.ChooseLocation();
                    break;
                case 8:
                    employee.JobTitle = _employeePropertyEntries.ChooseRole();
                    break;
                case 9:
                    employee.Department = _employeePropertyEntries.ChooseDepartment();
                    break;
                case 10:
                    employee.ManagerId = _employeePropertyEntries.ChooseManager(employee);
                    break;
                 case 11:
                    employee.Project = _employeePropertyEntries.GetProjectName();
                    break;
                default:
                    Console.WriteLine("Modification can only be done on the above properties only");
                    break;
            }
            Console.WriteLine("{0,-8} {1,-18} {2,-12} {3,-18} {4,-12} {5,-12} {6,-12} {7,-12} {8,-12} {9,-15} {10,-12} ", "Id", "Full Name", "DateOfBirth", "Email", "MobileNumber", "JoinDate", "Location", "JobTitle", "Department", "ManagerName", "Project");
            Display(employee);
        }
        public void Display(EmployeeModel e)
        {
            string managerName = GetManagerName(e);
            Console.WriteLine(new string('-', 145));
            Console.WriteLine("{0,-8} {1,-18} {2,-12} {3,-18} {4,-12} {5,-12} {6,-12} {7,-12} {8,-12} {9,-15} {10,-12} ", e.Id,e.FirstName+" "+e.LastName, e.DateOfBirth,e.Email, e.MobileNumber, e.JoinDate, e.Location, e.JobTitle, e.Department, managerName, e.Project);           
        }
        public void Delete(EmployeeModel e)
        {
            EmployeeManagement.EmployeeList.Remove(e);
        }
        public static string GetManagerName(EmployeeModel e)
        {
            for(int i = 0; i < EmployeeManagement.EmployeeList.Count; i++)
            {
                if (EmployeeManagement.EmployeeList[i].Id == e.ManagerId)
                {
                    return EmployeeManagement.EmployeeList[i].FirstName +" "+ EmployeeManagement.EmployeeList[i].LastName;
                }
            }
            return "No Manager";
        }
    }

}
