using DataLinkLibrary.Interface;
using DepartmentManagementLibrary.Interfaces;
using Models;
namespace DepartmentManagementLibrary
{


    public class DepartmentManager : IDepartmentManager
    {

        private readonly IDepartmentOperations _departmentHandler;
        public DepartmentManager(IDepartmentOperations departmentHandler)
        {
            _departmentHandler = departmentHandler;
        }

        public static bool CheckDepartmentExists(string name, List<DepartmentModel>departmentList)
        {
            for (int i = 0; i < departmentList.Count; i++)
            {
                if (departmentList[i].Name == name)
                    return true;
            }
            return false;
        }
        public void AddDepartment(DepartmentModel dept,ref List<DepartmentModel> departmentList)
        {
            Console.Write("Enter New DepartMent Name:");
            string name = Console.ReadLine().ToUpper();
            if (!CheckDepartmentExists(name,departmentList))
            {
                dept.Name = name;
                departmentList.Add(dept);
                _departmentHandler.write(departmentList);
            }
        }
    }
}
