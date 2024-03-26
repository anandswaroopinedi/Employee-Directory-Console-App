using EmployeeDirectoryConsoleApp.DataPresentation.Interface;
using EmployeeDirectoryConsoleApp.Models;
using EmployeeDirectoryConsoleApp.Presentation.Interfaces;
using EmployeeDirectoryConsoleApp.Presentation.Services;

namespace EmployeeDirectoryConsoleApp.Presentation
{
    public class StartApp : IStartApp
    {
        public static List<DepartmentModel> DepartmentList = new List<DepartmentModel>();
        public static List<LocationModel> LocationList = new List<LocationModel>();
        private readonly ILocationOperations _locationOperations;
        private readonly IRoleOperations _roleOperations;
        private readonly IDepartmentOperations _departmentOperations;
        private readonly IEmployeeOperations _employeeOperations;
        public readonly IDisplayMenuManagement _displayMenuManagement;
        public StartApp(ILocationOperations locationOperations, IRoleOperations roleOperations, IDepartmentOperations departmentOperations, IEmployeeManagement employeeManagement, IRoleManagement roleManagement, IEmployeeOperations employeeOperations, IDisplayMenuManagement displayMenuManagement)
        {
            _locationOperations = locationOperations;
            _roleOperations = roleOperations;
            _departmentOperations = departmentOperations;
            _employeeOperations = employeeOperations;
            _displayMenuManagement = displayMenuManagement;
        }
        public void Run()
        {
            DepartmentList = _departmentOperations.read();
           LocationList = _locationOperations.read();
            RoleManagement.RoleList = _roleOperations.read();
            EmployeeManagement.EmployeeList = _employeeOperations.read();
          _displayMenuManagement.StartAppDisplayOptionMenu();
        }
    }
}
