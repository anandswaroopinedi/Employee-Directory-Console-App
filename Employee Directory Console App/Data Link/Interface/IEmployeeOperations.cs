using EmployeeDirectoryConsoleApp.Models;

namespace EmployeeDirectoryConsoleApp.DataPresentation.Interface
{
    public interface IEmployeeOperations
    {
        public List<EmployeeModel> read();
        public void write();
    }
}
