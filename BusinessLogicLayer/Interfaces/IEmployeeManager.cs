using Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEmployeeManager
    {
        public void Create(EmployeeModel employee,ref List<EmployeeModel> employeeList);
        public void Update(EmployeeModel employee,ref List<EmployeeModel> employeeList);
        public void Delete(EmployeeModel model,ref List<EmployeeModel> employeeModels);
    }
}
