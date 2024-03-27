using Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEmployeeManager
    {
        public void Create(EmployeeModel employee,ref List<EmployeeModel> employeeList,ref List<LocationModel> locationList,ref List<DepartmentModel> departmentList,ref List<RolesModel> rolesList);
        public void Update(EmployeeModel employee,ref List<EmployeeModel> employeeList,ref List<LocationModel> locationList,ref List<DepartmentModel> departmentList,ref List<RolesModel> rolesList);
        public void Delete(EmployeeModel model,ref List<EmployeeModel> employeeModels);
        public void Display(EmployeeModel model,ref List<EmployeeModel> employeeModels);
    }
}
