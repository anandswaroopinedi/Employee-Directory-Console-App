using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interface;
using Models;


namespace BusinessLogicLayer.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IDataOperations _dataOperations;
        private static string filePath=@"C:\Users\anand.i\source\repos\Employee Directory Console App\Data\Repository\Employee.json";
        public EmployeeManager( IDataOperations dataOperations)
        {
            _dataOperations = dataOperations;
        }
        public async Task<bool> Create(Employee employee)
        {
            List<Employee> employeeList = GetAll().Result;
            employeeList.Add(employee);
            if(await _dataOperations.Write(employeeList, filePath))
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Update(Employee employee, int index)
        {
            List<Employee> employeeList = GetAll().Result;
            employeeList[index] = employee;
            if (await _dataOperations.Write(employeeList, filePath))
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(string id)
        {
            int index = await CheckIdExists(id);
            if (index == -1)
            {
                return false;
            }
            else
            {
                List<Employee> employeeList = GetAll().Result;
                for (int i = 0; i < employeeList.Count; i++)
                {
                    if (employeeList[i].ManagerId == employeeList[index].Id)
                    {
                        employeeList[i].ManagerId = "None";
                    }
                }
                employeeList.Remove(employeeList[index]);
                if(await _dataOperations.Write(employeeList, filePath))
                {
                    return true;
                }
                return false;  
            }
        }
        public async Task<int> CheckIdExists(string id)
        {
            List<Employee> employeeList = await GetAll();
            for (int i = 0; i < employeeList.Count; i++)
            {
                if (employeeList[i].Id == id)
                    return i;
            }
            return -1;
        }
        public async Task<List<Employee>> GetAll()
        {
            return await _dataOperations.Read<Employee>(filePath);
        }

    }

}
