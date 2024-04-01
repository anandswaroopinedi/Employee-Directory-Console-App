using Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEmployeeManager
    {
        public void Create(EmployeeModel employee);
        public void Update(EmployeeModel employee,int index);
        public bool Delete(string id);
        public int CheckIdExists(string id);
        public List<EmployeeModel> GetAll();
    }
}
