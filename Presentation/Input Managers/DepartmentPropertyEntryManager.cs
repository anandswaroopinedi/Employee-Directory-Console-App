using BusinessLogicLayer.Interfaces;
using Models;
using Presentation.Interfaces;
namespace DepartmentManagementLibrary
{
    public class DepartmentPropertyEntryManager : IDepartmentPropertyEntryManager
    {
        private readonly IDepartmentManager _departmentManager;
        public DepartmentPropertyEntryManager(IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }

        public static void DisplayDepartmentList(List<Department> departmentList)
        {
            for (int i = 0; i < departmentList.Count; i++)
            {
                Console.WriteLine($"{i + 2}.  {departmentList[i].Name}");
            }
        }
        public int ChooseDepartment()
        {
            List<Department> departmentList = _departmentManager.GetAll();
            int option;
            Console.WriteLine("Departments:");
            Console.WriteLine("0.Exit");
            Console.WriteLine("1. Add New Department");
            DisplayDepartmentList(departmentList);
            Console.Write("Choose Department from above options*:");
            int.TryParse(Console.ReadLine(), out option);
            if (option == 0)
            {
                return 0;
            }
            if (option == 1)
            {
                Department departmentModel = new Department();
                Console.Write("Enter New DepartMent Name:");
                string name = Console.ReadLine().ToUpper();
                departmentModel.Name = name;
                if (_departmentManager.AddDepartment(departmentModel))
                {
                    Console.WriteLine("Department Added successfully");
                    return departmentModel.Id;
                }
                else
                {
                    Console.WriteLine("Entered Department is previously exists in the database.");
                    return ChooseDepartment();
                }
            }
            if (option > 1 && option <= departmentList.Count + 1)
            {
                return departmentList[option - 2].Id;
            }
            else
            {
                Console.WriteLine("Select option from the above list only");
                return ChooseDepartment();
            }
        }
    }
}
