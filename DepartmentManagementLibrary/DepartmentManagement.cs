using DepartmentManagementLibrary.Interfaces;
using Models;

namespace DepartmentManagementLibrary
{
    public class DepartmentManagement : IDepartmentManagement
    {
        private readonly IDepartmentManager _departmentManager;
        public DepartmentManagement(IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }
        public void AddDepartment()
        {
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Enter Department");
            Console.Write("Choose options from above:");
            int.TryParse(Console.ReadLine(), out int option);
            if (option == 0)
            {
                return;
            }
            else if (option == 1)
            {
                Console.Write("Enter Department Name:");
                string department = Console.ReadLine().ToUpper();
                if (!string.IsNullOrEmpty(department))
                {
                    DepartmentModel departmentModel = new DepartmentModel();
                    departmentModel.Name = department;
                    if (_departmentManager.AddDepartment(departmentModel))
                    {
                        Console.WriteLine("Department Added Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Department already exists");
                    }
                }
                else
                {
                    Console.WriteLine("Department can't be null");
                }
            }
        }
        public void DisplayAll()
        {
            List<DepartmentModel> departmentList = _departmentManager.GetAll();
            Console.WriteLine($"Department List(Count:{departmentList.Count}):");
            for (int i = 0; i < departmentList.Count; i++)
            {
                Console.WriteLine($"{departmentList[i].Id}. {departmentList[i].Name}");
            }
        }
    }
}
