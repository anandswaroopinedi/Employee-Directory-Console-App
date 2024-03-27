
using DataLinkLibrary.Interface;
using DepartmentManagementLibrary.Interfaces;
using Models;
namespace DepartmentManagementLibrary
{
    public class DepartmentPropertyEntryManager : IDepartmentPropertyEntryManager
    {
        private readonly IDepartmentManager _departmentManager;
        private readonly IDepartmentOperations _departmentOperations;
        public DepartmentPropertyEntryManager(IDepartmentManager departmentManager, IDepartmentOperations departmentOperations)
        {
            _departmentManager = departmentManager;
            _departmentOperations = departmentOperations;
        }

        public static void DisplayDepartmentList(List<DepartmentModel> departmentList)
        {
            for (int i = 0; i < departmentList.Count; i++)
            {
                Console.WriteLine($"{i + 1}.  {departmentList[i].Name}");
            }
        }
        public string CreateDepartmentRef(ref List<DepartmentModel> departmentList)
        {
            DepartmentModel departmentModel = new DepartmentModel();
            _departmentManager.AddDepartment(departmentModel, ref departmentList);
            _departmentOperations.write(departmentList);
            return departmentModel.Name;
        }
        public string ChooseDepartment(ref List<DepartmentModel> departmentList)
        {
            int option;
            Console.WriteLine("Departments:");
            Console.WriteLine("0. Add New Department");
            DisplayDepartmentList(departmentList);
            Console.Write("Choose Department from above options*:");
            int.TryParse(Console.ReadLine(), out option);
            if (option == 0)
            {
                return this.CreateDepartmentRef(ref departmentList);
            }
            if (option > 0 && option <= departmentList.Count)
            {
                return departmentList[option - 1].Name;
            }
            else
            {
                Console.WriteLine("Select option from the above list only");
                return ChooseDepartment(ref departmentList);
            }
        }
    }
}
