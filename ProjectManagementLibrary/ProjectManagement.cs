using DataAccessLayer.Interface;
using Models;
using ProjectManagementLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementLibrary
{
    public class ProjectManagement:IProjectManagement
    {
        private readonly IProjectManager _projectManager;
        public ProjectManagement(IProjectManager projectManager)
        {
            _projectManager = projectManager;
        }
        public string AddProject()
        {
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Add Project:");
            Console.Write("Choose options from above:");
            int.TryParse(Console.ReadLine(), out int option);
            if (option == 0)
            {
                return "Abort";
            }
            else if (option == 1)
            {
                Console.Write("1. Enter Project Name:");
                string project = Console.ReadLine();
                if (!string.IsNullOrEmpty(project))
                {
                    ProjectModel projectModel = new ProjectModel();
                    projectModel.Name = project;
                    if (_projectManager.AddProject(projectModel))
                    {
                        Console.WriteLine("Project Added Successfully");
                        return project;
                    }
                    else
                    {
                        Console.WriteLine("Project already exists");
                        return "failed";
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
                Console.WriteLine($"{projectList[i].Id}. {projectList[i].Name}");
            }
        }
    }
}
