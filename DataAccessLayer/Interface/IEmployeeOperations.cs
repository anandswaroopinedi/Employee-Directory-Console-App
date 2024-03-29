using Models;

namespace DataAccessLayer.Interface
{
    public interface IEmployeeOperations
    {
        public List<EmployeeModel> read();
        public void write(List<EmployeeModel> employeesList);
    }
}
