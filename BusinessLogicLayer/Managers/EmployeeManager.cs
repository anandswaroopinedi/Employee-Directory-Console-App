using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interface;
using Models;


namespace BusinessLogicLayer.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeOperations _employeeOperations;

        public EmployeeManager(IEmployeeOperations employeeOperations)
        {
            _employeeOperations = employeeOperations;

        }
        public bool Create(Employee employee)
        {
            List<Employee> employeeList = _employeeOperations.read();
            employeeList.Add(employee);
            if(_employeeOperations.write(employeeList))
            {
                return true;
            }
            return false;
        }
        public bool Update(Employee employee, int index)
        {
            List<Employee> employeeList = _employeeOperations.read();
            employeeList[index] = employee;
            if (_employeeOperations.write(employeeList))
            {
                return true;
            }
            return false;
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
                List<Employee> employeeList = _employeeOperations.read();
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
            List<Employee> employeeList = _employeeOperations.read();
            for (int i = 0; i < employeeList.Count; i++)
            {
                if (employeeList[i].Id == id)
                    return i;
            }
            return -1;
        }
        public List<Employee> GetAll()
        {
            return _employeeOperations.read();
        }

    }

}
