

using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interface;
using DepartmentManagementLibrary.Interfaces;
using LocationManagementLibrary.Interfaces;
using Models;
using ProjectManagementLibrary.Interfaces;


namespace BusinessLogicLayer
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeOperations _employeeOperations;

        public EmployeeManager(IEmployeeOperations employeeOperations)
        {
            _employeeOperations = employeeOperations;

        }
        public void Create(EmployeeModel employee)
        {
            List<EmployeeModel> employeeList = _employeeOperations.read();
            employeeList.Add(employee);
            _employeeOperations.write(employeeList);
        }
        public void Update(EmployeeModel employee, int index)
        {
            List<EmployeeModel> employeeList = _employeeOperations.read();
            employeeList[index] = employee;
            _employeeOperations.write(employeeList);
        }
        public bool Delete(string id)
        {
            int index = CheckIdExists(id);
            if (index == -1)
            {
                return false;
            }
            else
            {
                List<EmployeeModel> employeeList = _employeeOperations.read();
                for (int i = 0; i < employeeList.Count; i++)
                {
                    if (employeeList[i].ManagerId == employeeList[index].Id)
                    {
                        employeeList[i].ManagerId = "None";
                    }
                }
                employeeList.Remove(employeeList[index]);
                _employeeOperations.write(employeeList);
                return true;
            }
        }
        public int CheckIdExists(string id)
        {
            List<EmployeeModel> employeeList = _employeeOperations.read();
            for (int i = 0; i < employeeList.Count; i++)
            {
                if (employeeList[i].Id == id)
                    return i;
            }
            return -1;
        }
        public List<EmployeeModel> GetAll()
        {
            return _employeeOperations.read();
        }

    }

}
