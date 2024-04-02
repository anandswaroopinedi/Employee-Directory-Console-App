using DataAccessLayer.Interface;
using Models;
using BusinessLogicLayer.Interfaces;

namespace BusinessLogicLayer.Managers
{
    public class ProjectManager : IProjectManager
    {
        private readonly IProjectOperations _projectOperations;
        public ProjectManager(IProjectOperations projectOperations)
        {
            _projectOperations = projectOperations;
        }

        public bool AddProject(Project project)
        {
            List<Project> projectList = _projectOperations.read();

            if (!CheckProjectExists(project.Name, projectList))
            {
                project.Id = projectList.Count + 1;
                projectList.Add(project);
                if (_projectOperations.write(projectList))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Project> GetAll()
        {
            return _projectOperations.read();
        }
        public static bool CheckProjectExists(string project, List<Project> projectList)
        {
            for (int i = 0; i < projectList.Count; i++)
            {
                if (projectList[i].Name == project)
                {
                    return true;
                }
            }
            return false;
        }
        public string GetProjectName(int id)
        {
            List<Project> projectList = _projectOperations.read();
            for (int i = 0; i < projectList.Count; i++)
            {
                if (projectList[i].Id == id)
                {
                    return projectList[i].Name;
                }
            }
            return "";
        }
    }
}
