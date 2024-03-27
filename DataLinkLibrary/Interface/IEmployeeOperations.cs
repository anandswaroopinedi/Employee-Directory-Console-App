using Models;

namespace DataLinkLibrary.Interface
{
    public interface IEmployeeOperations
    {
        public List<EmployeeModel> read();
        public void write(List<EmployeeModel> employeesList);
    }
}
