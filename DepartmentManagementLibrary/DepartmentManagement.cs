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
            Console.WriteLine("Enter Department Name:");
            string department = Console.ReadLine();
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
