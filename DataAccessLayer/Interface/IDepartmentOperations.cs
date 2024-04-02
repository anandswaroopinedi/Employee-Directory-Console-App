using Models;

namespace DataAccessLayer.Interface
{
    public interface IDepartmentOperations
    {
        public List<Department> read();
        public  bool write(List<Department> deptList);
    }
}
