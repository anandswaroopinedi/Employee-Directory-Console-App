using EmployeeDirectoryConsoleApp.Models;

namespace EmployeeDirectoryConsoleApp.DataPresentation.Interface
{
    public interface IRoleOperations
    {
        public List<RolesModel> read();
        public void write();
    }
}
