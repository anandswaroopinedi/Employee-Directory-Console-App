using Models;

namespace DepartmentManagementLibrary.Interfaces
{
    public interface IDepartmentManager
    {
        public void AddDepartment(DepartmentModel dept, ref List<DepartmentModel> departmentList);
    }
}
