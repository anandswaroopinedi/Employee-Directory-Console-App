using DataAccessLayer.Interface;
using BusinessLogicLayer.Interfaces;
using Models;
namespace BusinessLogicLayer.Managers
{
    public class DepartmentManager : IDepartmentManager
    {

        private readonly IDepartmentOperations _departmentOperations;
        public DepartmentManager(IDepartmentOperations departmentHandler)
        {
            _departmentOperations = departmentHandler;
        }

        public static bool CheckDepartmentExists(string name, List<Department> departmentList)
        {
            for (int i = 0; i < departmentList.Count; i++)
            {
                if (departmentList[i].Name == name)
                    return true;
            }
            return false;
        }
        public string GetDepartmentName(int id)
        {
            List<Department> departmentList = _departmentOperations.read();
            for (int i = 0; i < departmentList.Count; i++)
            {
                if (departmentList[i].Id == id)
                {
                    return departmentList[i].Name;
                }
            }
            return "None";
        }
        public bool AddDepartment(Department dept)
        {

            List<Department> departmentList = _departmentOperations.read();
            if (!CheckDepartmentExists(dept.Name, departmentList))
            {
                dept.Id = departmentList.Count + 1;
                departmentList.Add(dept);
                Console.WriteLine(dept.Name);
                if(_departmentOperations.write(departmentList))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Department> GetAll()
        {
            return _departmentOperations.read();
        }
    }
}
