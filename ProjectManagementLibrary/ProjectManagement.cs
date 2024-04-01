using Models;
using ProjectManagementLibrary.Interfaces;

namespace ProjectManagementLibrary
{
    public class ProjectManagement : IProjectManagement
    {
        private readonly IProjectManager _projectManager;
        public ProjectManagement(IProjectManager projectManager)
        {
            _projectManager = projectManager;
        }
        public int AddProject()
        {
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Enter Project");
            Console.Write("Choose options from above:");
            int.TryParse(Console.ReadLine(), out int option);
            if (option == 0)
            {
                return 0;
            }
            else if (option == 1)
            {
                Console.Write("Enter Project Name:");
                string project = Console.ReadLine().ToUpper();
                if (!string.IsNullOrEmpty(project))
                {
                    ProjectModel projectModel = new ProjectModel();
                    projectModel.Name = project;
                    if (_projectManager.AddProject(projectModel))
                    {
                        Console.WriteLine("Project Added Successfully");
                        return projectModel.Id;
                    }
                    else
                    {
                        Console.WriteLine("Project already exists");
                        return -1;
                    }
                }
                else
                {
                    Console.WriteLine("Project can't be null");
                    return AddProject();
                }
            }
            else
            {
                return AddProject();
            }
        }
        public void DisplayAll()
        {
            List<ProjectModel> projectList = _projectManager.GetAll();
            Console.WriteLine($"Projects(Count:{projectList.Count}):");
            for (int i = 0; i < projectList.Count; i++)
            {
                Console.WriteLine($"{i+1}. {projectList[i].Name}");
            }
        }
    }
}
