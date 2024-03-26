using EmployeeDirectoryConsoleApp.Models;

namespace EmployeeDirectoryConsoleApp.DataPresentation.Interface
{
    public interface ILocationOperations
    {
        public List<LocationModel> read();
        public void write();
    }
}
