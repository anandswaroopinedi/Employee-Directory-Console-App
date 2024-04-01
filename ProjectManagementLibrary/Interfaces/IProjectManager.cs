using Models;

namespace ProjectManagementLibrary.Interfaces
{
    public interface IProjectManager
    {
        public bool AddProject(ProjectModel project);
        public List<ProjectModel> GetAll();
        public string GetProjectName(int id);
    }
}
