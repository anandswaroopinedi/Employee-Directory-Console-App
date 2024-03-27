

using BusinessLogicLayer.Interfaces;
using DataLinkLibrary.Interface;
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
        public EmployeeModel Display(string id)
        {
            int index = GetIdExists(id);
            if (index >= 0)
            {
                List<EmployeeModel> employeeList = _employeeOperations.read();
                return employeeList[index];
            }
            return new EmployeeModel();
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
        private int GetIdExists(string id)
        {
            List<EmployeeModel> employeeList = _employeeOperations.read();
            for (int i = 0; i < employeeList.Count; i++)
            {
                if (employeeList[i].Id == id)
                {
                    return i;

                }

            }
            return -1;
        }

    }

}
