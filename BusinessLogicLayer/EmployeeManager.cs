

using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interface;
using Models;


namespace BusinessLogicLayer
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeOperations _employeeOperations;
        public EmployeeManager(IEmployeeOperations employeeOperations)
        {
            _employeeOperations = employeeOperations;
        }
        public void Create(EmployeeModel employee, ref List<EmployeeModel> employeeList)
        {
            employeeList.Add(employee);
            _employeeOperations.write(employeeList);
        }
        public void Update(EmployeeModel employee, ref List<EmployeeModel> employeeList)
        {
            _employeeOperations.write(employeeList);
        }
        public void Delete(EmployeeModel e, ref List<EmployeeModel> employeeList)
        {
            employeeList.Remove(e);
            for (int i = 0; i < employeeList.Count; i++)
            {
                if (employeeList[i].ManagerId == e.Id)
                {
                    employeeList[i].ManagerId = "None";
                }
            }
            _employeeOperations.write(employeeList);
        }

    }

}
