using Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEmployeeManager
    {
        public bool Create(Employee employee);
        public bool Update(Employee employee, int index);
        public bool Delete(string id);
        public int CheckIdExists(string id);
        public List<Employee> GetAll();
    }
}
