using Models;

namespace DataAccessLayer.Interface
{
    public interface IProjectOperations
    {
        public List<ProjectModel> read();
        public void write(List<ProjectModel> deptList);
    }
}
