using Models;

namespace DataLinkLibrary.Interface
{
    public interface IDepartmentOperations
    {
        public List<DepartmentModel> read();
        public void write(List<DepartmentModel> deptList);
    }
}
