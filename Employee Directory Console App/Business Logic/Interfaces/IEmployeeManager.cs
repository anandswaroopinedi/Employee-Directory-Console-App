using EmployeeDirectoryConsoleApp.Models;

namespace EmployeeDirectoryConsoleApp.Interfaces
{
    public interface IEmployeeManager
    {
        public void Create(EmployeeModel model);
        public void Update(EmployeeModel model);
        public void Delete(EmployeeModel model);
        public void Display(EmployeeModel model);
    }
}
