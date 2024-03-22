using EmployeeDirectoryConsoleApp.DataPresentation;
using EmployeeDirectoryConsoleApp.DataPresentation.Interface;
using EmployeeDirectoryConsoleApp.Interfaces;
using EmployeeDirectoryConsoleApp.Models;
using EmployeeDirectoryConsoleApp.StreamOperations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.Services
{
    public  class EmployeeManagement: IEmployeeManagement
    {
       
        public static List<EmployeeModel> EmployeeList = new List<EmployeeModel>();
        private readonly IEmployeeManager _emp;
        private readonly IEmployeeOperations _employeeOperations;
        private readonly IDuplicate _startApp;
        //public static Employee EmpHandler=new Employee();
        //Displaying Menu When Employee Json has 0 employee count
        public EmployeeManagement(IEmployeeManager emp,IEmployeeOperations employeeOperations, IDuplicate employeeDirectory)
        {
            this._emp = emp;
            this._employeeOperations = employeeOperations;
            this._startApp = employeeDirectory;
            //this._emp = emp;

        }
        public static bool DisplayDefaultMenu(IEmployeeManagement employeeManagement)
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
                    employeeManagement.AddEmployee();
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

        public static bool DisplayAdjustedMenu(IEmployeeManagement employeeManagement)
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
                    employeeManagement.AddEmployee();
                    break;
                case 2:
                    employeeManagement.DisplayAll();
                    break;
                case 3:
                    employeeManagement.DisplayOne();
                    break;
                case 4:
                    employeeManagement.UpdateEmployee();
                    break;
                case 5:
                    employeeManagement.DeleteEmployee();
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
        public  void DisplayMenu()
        {
            
            bool flag;
            if (EmployeeList.Count < 1)
            {
               flag=DisplayDefaultMenu(this);
            }

            else
            {
                flag = DisplayAdjustedMenu(this);              
            }
            if (!flag)
            {
                _startApp.Run();
            }
        }
        //To Record the details of employee for update.
        public  void UpdateEmployee()
        {
            Console.Write("Enter Employee Id:");
            string id = Console.ReadLine()!.ToUpper();
            int index = CheckIdExists(id);
            if (index != -1)
            {
                this._emp.Update(EmployeeList[index]);
                /*                this.my_implementations.Single(x=>x is Employee2).Update(EmployeeList[index]);*/
               /* ByteStreamOperations.StoreEmployeeData();*/
                _employeeOperations.write();
                Console.WriteLine("Employee added successfully");
            }
            else
            {
                Console.WriteLine("Employee Id doesn't exists");
            }
        }
        //To make the managerId's of employee that are containing the deleted id should be made default None
        public static void RemoveManagerIdInSubordinates(string id) {
        for (int i = 0;i<EmployeeList.Count;i++)
            {
                if (EmployeeList[i].ManagerId==id)
                {
                   EmployeeList[i].ManagerId = "None" ;
                }
            }
        
        }
        //To Record the details of employee to perform deletion Operation
        public  void DeleteEmployee()
        {
            Console.Write("Enter Employee Id:");
            string id = Console.ReadLine()!.ToUpper();
            int index = CheckIdExists(id);
            if (index != -1)
            {
                _emp.Delete(EmployeeList[index]);
                _employeeOperations.write();
                RemoveManagerIdInSubordinates(id);
                Console.WriteLine("Employee deleted successfully");
            }
            else
            {
                Console.WriteLine("Employee Id doesn't exists");
            }
        }
        //To Display Employee through their id
        public  void DisplayOne()
        {
            Console.Write("Enter Employee Id:");
            string id=Console.ReadLine().ToUpper();
            int index = CheckIdExists(id);
            if (index!=-1)
            {
                Console.WriteLine("{0,-8} {1,-18} {2,-12} {3,-18} {4,-12} {5,-12} {6,-12} {7,-12} {8,-12} {9,-15} {10,-12} ", "Id", "Full Name", "DateOfBirth", "Email", "MobileNumber", "JoinDate", "Location", "JobTitle", "Department", "ManagerName", "Project");
                this._emp.Display(EmployeeList[index]);
            }
            else
            {
                Console.WriteLine("Employee Id doesn't exists");
            }
        }
        public  void DisplayAll()
        {
            Console.WriteLine($"\nNo of Employee records in the Database are: {EmployeeList.Count}");
            Console.WriteLine("{0,-8} {1,-18} {2,-12} {3,-18} {4,-12} {5,-12} {6,-12} {7,-12} {8,-12} {9,-15} {10,-12} ", "Id", "Full Name", "DateOfBirth", "Email", "MobileNumber", "JoinDate", "Location", "JobTitle", "Department", "ManagerName", "Project");
            foreach (var employee in EmployeeList)
            {
                this._emp.Display(employee);
            }
        }
        public static int CheckIdExists(string id)
        {
            for(int i = 0; i < EmployeeList.Count; i++)
            {
                if (EmployeeList[i].Id==id)
                    return i;
            }
            return -1;
        }
        public  void AddEmployee()
        {
            bool flag = true;
            while(flag)
            {
                Console.Write("Enter Employee Id(TZ0001)*:");
                string empId = Console.ReadLine().ToUpper();
                if (Validations.ValidateEmployeeId(empId) && (CheckIdExists(empId)==-1))
                {
                    EmployeeModel emp = new EmployeeModel();
                    emp.Id = empId;
                    this._emp.Create(emp);
                    EmployeeList.Add(emp);
                    /*ByteStreamOperations.StoreEmployeeData();*/
                    _employeeOperations.write();
                    flag = false;
                }
                else { Console.WriteLine("Employee Id Exists or Employee Id not following the Pattern('TZ0101') so enter again"); }
            }
            
        }
    }
}
