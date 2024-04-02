using Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IProjectManager
    {
        public bool AddProject(Project project);
        public List<Project> GetAll();
        public string GetProjectName(int id);
    }
}
