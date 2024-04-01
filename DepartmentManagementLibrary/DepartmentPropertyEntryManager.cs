
using DataAccessLayer;
using DataAccessLayer.Interface;
using DepartmentManagementLibrary.Interfaces;
using Models;
namespace DepartmentManagementLibrary
{
    public class DepartmentPropertyEntryManager : IDepartmentPropertyEntryManager
    {
        private readonly IDepartmentManager _departmentManager;
        public DepartmentPropertyEntryManager(IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }

        public static void DisplayDepartmentList(List<DepartmentModel> departmentList)
        {
            for (int i = 0; i < departmentList.Count; i++)
            {
                Console.WriteLine($"{i + 2}.  {departmentList[i].Name}");
            }
        }
        public string CreateDepartmentRef()
        {
            DepartmentModel departmentModel = new DepartmentModel();
            Console.Write("Enter New DepartMent Name:");
            string name = Console.ReadLine().ToUpper();
            departmentModel.Name = name;
            _departmentManager.AddDepartment(departmentModel);
            Console.WriteLine("Department Added successfully");
            return departmentModel.Name;
        }
        public string ChooseDepartment()
        {
            List<DepartmentModel> departmentList = _departmentManager.GetAll();
            int option;
            Console.WriteLine("Departments:");
            Console.WriteLine("0.Exit");
            Console.WriteLine("1. Add New Department");
            DisplayDepartmentList(departmentList);
            Console.Write("Choose Department from above options*:");
            int.TryParse(Console.ReadLine(), out option);
            if (option == 0)
            {
                return "Abort";
            }
            if (option == 1)
            {
                return this.CreateDepartmentRef();
            }
            if (option > 1 && option <= departmentList.Count+1)
            {
                return departmentList[option - 2].Name;
            }
            else
            {
                Console.WriteLine("Select option from the above list only");
                return ChooseDepartment();
            }
        }
    }
}
