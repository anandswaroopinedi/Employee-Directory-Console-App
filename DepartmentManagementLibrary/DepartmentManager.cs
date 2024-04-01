using DataAccessLayer.Interface;
using DepartmentManagementLibrary.Interfaces;
using Models;
namespace DepartmentManagementLibrary
{
    public class DepartmentManager : IDepartmentManager
    {

        private readonly IDepartmentOperations _departmentOperations;
        public DepartmentManager(IDepartmentOperations departmentHandler)
        {
            _departmentOperations = departmentHandler;
        }

        public static bool CheckDepartmentExists(string name, List<DepartmentModel> departmentList)
        {
            for (int i = 0; i < departmentList.Count; i++)
            {
                if (departmentList[i].Name == name)
                    return true;
            }
            return false;
        }
        public bool AddDepartment(DepartmentModel dept)
        {
            
            List<DepartmentModel>departmentList= _departmentOperations.read();
            if (!CheckDepartmentExists(dept.Name, departmentList))
            {
                dept.Id=departmentList.Count+1;
                departmentList.Add(dept);

                _departmentOperations.write(departmentList);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<DepartmentModel> GetAll()
        {
            return _departmentOperations.read();
        }
    }
}
