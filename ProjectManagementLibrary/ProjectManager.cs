using DataAccessLayer.Interface;
using Models;
using ProjectManagementLibrary.Interfaces;

namespace ProjectManagementLibrary
{
    public class ProjectManager:IProjectManager
    {
        private readonly IProjectOperations _projectOperations;
        public ProjectManager(IProjectOperations projectOperations)
        {
            _projectOperations = projectOperations;
        }

        public bool AddProject(ProjectModel project)
        {
            List<ProjectModel> projectList = _projectOperations.read();

            if (!CheckProjectExists(project.Name, projectList))
            {
                project.Id = projectList.Count + 1;
                projectList.Add(project);
                _projectOperations.write(projectList);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<ProjectModel> GetAll()
        {
            return _projectOperations.read();
        }
        public static bool CheckProjectExists(string project, List<ProjectModel> projectList)
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
    }
}
