using BusinessLogicLayer.Interfaces;
using DataLinkLibrary.Interface;
using Models;
using Presentation.Interfaces;
using Validations;

namespace Presentation.Services
{
    public class EmployeeManagement : IEmployeeManagement
    {

        public static List<EmployeeModel> EmployeeList = new List<EmployeeModel>();
        private readonly IEmployeeManager _employeeManager;
        private readonly IEmployeeOperations _employeeOperations;
        private readonly IRoleManagement _roleManagement;
        //public static Employee EmpHandler=new Employee();
        //Displaying Menu When Employee Json has 0 employee count
        public EmployeeManagement(IEmployeeManager emp, IEmployeeOperations employeeOperations, IRoleManagement roleManagement)
        {
            _employeeManager = emp;
            _employeeOperations = employeeOperations;
            //this._emp = emp;
            _roleManagement = roleManagement;

        }
        //To Record the details of employee for update.
        public void UpdateEmployee()
        {
            Console.Write("Enter Employee Id:");
            string id = Console.ReadLine()!.ToUpper();
            int index = CheckIdExists(id);
            if (index != -1)
            {
                _employeeManager.Update(EmployeeList[index],ref EmployeeList,ref StartApp.LocationList,ref StartApp.DepartmentList,ref RoleManagement.RoleList);
                /*                this.my_implementations.Single(x=>x is Employee2).Update(EmployeeList[index]);*/
                /* ByteStreamOperations.StoreEmployeeData();*/
                _employeeOperations.write(EmployeeList);
                Console.WriteLine("Employee Updated successfully");
            }
            else
            {
                Console.WriteLine("Employee Id doesn't exists");
            }
        }
        //To make the managerId's of employee that are containing the deleted id should be made default None
        public static void RemoveManagerIdInSubordinates(string id)
        {
            for (int i = 0; i < EmployeeList.Count; i++)
            {
                if (EmployeeList[i].ManagerId == id)
                {
                    EmployeeList[i].ManagerId = "None";
                }
            }

        }
        //To Record the details of employee to perform deletion Operation
        public void DeleteEmployee()
        {
            Console.Write("Enter Employee Id:");
            string id = Console.ReadLine()!.ToUpper();
            int index = CheckIdExists(id);
            if (index != -1)
            {
                _employeeManager.Delete(EmployeeList[index],ref EmployeeList);
                _employeeOperations.write(EmployeeList);
                RemoveManagerIdInSubordinates(id);
                Console.WriteLine("Employee deleted successfully");
            }
            else
            {
                Console.WriteLine("Employee Id doesn't exists");
            }
        }
        //To Display Employee through their id
        public void DisplayOne()
        {
            Console.Write("Enter Employee Id:");
            string id = Console.ReadLine().ToUpper();
            int index = CheckIdExists(id);
            if (index != -1)
            {
                Console.WriteLine("{0,-8} {1,-18} {2,-12} {3,-18} {4,-12} {5,-12} {6,-12} {7,-12} {8,-12} {9,-15} {10,-12} ", "Id", "Full Name", "DateOfBirth", "Email", "MobileNumber", "JoinDate", "Location", "JobTitle", "Department", "ManagerName", "Project");
                _employeeManager.Display(EmployeeList[index],ref EmployeeList);
            }
            else
            {
                Console.WriteLine("Employee Id doesn't exists");
            }
        }
        public void DisplayAll()
        {
            Console.WriteLine($"\nNo of Employee records in the Database are: {EmployeeList.Count}");
            Console.WriteLine("{0,-8} {1,-18} {2,-12} {3,-18} {4,-12} {5,-12} {6,-12} {7,-12} {8,-12} {9,-15} {10,-12} ", "Id", "Full Name", "DateOfBirth", "Email", "MobileNumber", "JoinDate", "Location", "JobTitle", "Department", "ManagerName", "Project");
            foreach (var employee in EmployeeList)
            {
                _employeeManager.Display(employee,ref EmployeeList);
            }
        }
        public static int CheckIdExists(string id)
        {
            for (int i = 0; i < EmployeeList.Count; i++)
            {
                if (EmployeeList[i].Id == id)
                    return i;
            }
            return -1;
        }
        public void AddEmployee()
        {
            bool flag = true;
            while (flag)
            {
                Console.Write("Enter Employee Id(TZ0001)*:");
                string empId = Console.ReadLine().ToUpper();
                if (Validation.ValidateEmployeeId(empId) && CheckIdExists(empId) == -1)
                {
                    EmployeeModel emp = new EmployeeModel();
                    emp.Id = empId;
                    _employeeManager.Create(emp, ref EmployeeList,ref StartApp.LocationList,ref StartApp.DepartmentList,ref RoleManagement.RoleList);
                    EmployeeList.Add(emp);
                    _employeeOperations.write(EmployeeList);
                    flag = false;
                }
                else { Console.WriteLine("Employee Id Exists or Employee Id not following the Pattern('TZ0101') so enter again"); }
            }

        }
    }
}
