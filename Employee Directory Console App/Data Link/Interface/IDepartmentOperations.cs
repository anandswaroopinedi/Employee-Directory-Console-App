using EmployeeDirectoryConsoleApp.Models;

namespace EmployeeDirectoryConsoleApp.DataPresentation.Interface
{
    public interface IDepartmentOperations
    {
        public List<DepartmentModel> read();
        public void write();
    }
}
