using Models;

namespace DepartmentManagementLibrary.Interfaces
{
    public interface IDepartmentPropertyEntryManager
    {
        public string CreateDepartmentRef(ref List<DepartmentModel> departmentList);
        public string ChooseDepartment(ref List<DepartmentModel> departmentList);
    }
}
