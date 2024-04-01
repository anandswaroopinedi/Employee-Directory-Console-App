using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementLibrary.Interfaces
{
    public interface IProjectManager
    {
        public bool AddProject(ProjectModel project);
        public List<ProjectModel> GetAll();
    }
}
