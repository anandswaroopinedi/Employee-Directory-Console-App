using Models;

namespace DepartmentManagementLibrary.Interfaces
{
    public interface IDepartmentManager
    {
        public bool AddDepartment(DepartmentModel dept);
        public List<DepartmentModel> GetAll();
        public string GetDepartmentName(int id);
    }
}
