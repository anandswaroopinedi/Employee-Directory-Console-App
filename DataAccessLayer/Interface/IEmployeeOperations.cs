using Models;

namespace DataAccessLayer.Interface
{
    public interface IEmployeeOperations
    {
        public List<Employee> read();
        public bool write(List<Employee> employeesList);
    }
}
