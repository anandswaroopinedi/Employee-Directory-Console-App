using Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IDepartmentManager
    {
        public bool AddDepartment(Department dept);
        public List<Department> GetAll();
        public string GetDepartmentName(int id);
    }
}
