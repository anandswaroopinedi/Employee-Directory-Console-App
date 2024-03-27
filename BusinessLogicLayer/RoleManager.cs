using BusinessLogicLayer.Interfaces;
using DepartmentManagementLibrary.Interfaces;
using InputEntryManagersLibrary.Interfaces;
using LocationManagementLibrary.Interfaces;
using Models;

namespace BusinessLogicLayer
{
    public class RoleManager : IRoleManager
    {
        private readonly IDepartmentPropertyEntryManager _departmentPropertyEntries;
        private readonly IRolePropertyEntryManager _rolePropertyEntries;
        private readonly ILocationPropertyEntryManager _locationPropertyEntries;
        public RoleManager(IDepartmentPropertyEntryManager departmentPropertyEntries, IRolePropertyEntryManager rolePropertyEntries, ILocationPropertyEntryManager locationPropertyEntries)
        {
            _departmentPropertyEntries = departmentPropertyEntries;
            _rolePropertyEntries = rolePropertyEntries;
            _locationPropertyEntries = locationPropertyEntries;
        }

        public void AddRole(RolesModel role,ref List<LocationModel> locationList,ref List<DepartmentModel> departmentList)
        {
            Console.WriteLine("Roles");
            role.Department = _departmentPropertyEntries.ChooseDepartment(ref departmentList);
            Console.WriteLine("Roles");
            role.Location = _locationPropertyEntries.ChooseLocation(ref locationList);
            role.Description = _rolePropertyEntries.GetDescription();
        }
        public void Display(RolesModel role)
        {
            Console.WriteLine(new string('-', 66));
            Console.WriteLine("{0,-18} {1,-18} {2,-12} {3,-18}", role.Name, role.Department, role.Location, role.Description);
        }
    }
}
