using Models;

namespace DataAccessLayer.Interface
{
    public interface IDepartmentOperations
    {
        public List<DepartmentModel> read();
        public void write(List<DepartmentModel> deptList);
    }
}
