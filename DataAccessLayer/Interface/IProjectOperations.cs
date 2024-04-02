using Models;

namespace DataAccessLayer.Interface
{
    public interface IProjectOperations
    {
        public List<Project> read();
        public bool write(List<Project> deptList);
    }
}
