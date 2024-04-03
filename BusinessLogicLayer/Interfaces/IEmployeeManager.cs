using Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEmployeeManager
    {
        public Task<bool> Create(Employee employee);
        public Task<bool> Update(Employee employee, int index);
        public Task<bool> Delete(string id);
        public Task<int> CheckIdExists(string id);
        public Task<List<Employee>> GetAll();
    }
}
