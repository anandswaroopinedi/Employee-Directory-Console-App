using BusinessLogicLayer.Interfaces;
using DepartmentManagementLibrary.Interfaces;
using LocationManagementLibrary.Interfaces;
using Models;
using Presentation.Interfaces;

namespace Presentation.Services
{
    public sealed class RoleManagement : IRoleManagement
    {
        public static List<RolesModel> RoleList = new List<RolesModel>();
        /*        public static Role RoleHandler = new Role();*/
        private readonly IRoleManager _role;
        private readonly IDepartmentPropertyEntryManager _departmentPropertyEntryManager;
        private readonly ILocationPropertyEntryManager _locationPropertyEntryManager;
        private readonly IRolePropertyEntryManager _rolePropertyEntryManager;
        public RoleManagement(IRoleManager role, ILocationPropertyEntryManager locationPropertyEntryManager, IDepartmentPropertyEntryManager departmentPropertyEntryManager, IRolePropertyEntryManager rolePropertyEntryManager)
        {
            _role = role;
            _departmentPropertyEntryManager = departmentPropertyEntryManager;
            _locationPropertyEntryManager = locationPropertyEntryManager;
            _rolePropertyEntryManager = rolePropertyEntryManager;
        }
        public static bool CheckRoleExists(string roleName)
        {
            for (int i = 0; i < RoleList.Count; i++)
            {
                if (RoleList[i].Name == roleName)
                {
                    return true;
                }
            }
            return false;
        }
        private void GetRoleDetailsInput(RolesModel role)
        {
            Console.WriteLine("Roles");
            role.Department = _departmentPropertyEntryManager.ChooseDepartment(ref StartApp.DepartmentList);
            Console.WriteLine("Roles");
            role.Location = _locationPropertyEntryManager.ChooseLocation(ref StartApp.LocationList);
            role.Description = _rolePropertyEntryManager.GetDescription();
        }
        public void AddRole()
        {
            Console.Write("Enter New Role Name:");
            string roleName = Console.ReadLine()!.ToUpper();
            if (!CheckRoleExists(roleName))
            {
                RolesModel roleModel = new RolesModel();
                roleModel.Name = roleName;
                GetRoleDetailsInput(roleModel);
                _role.AddRole(roleModel, ref RoleList);
            }
        }
        public void DisplayAll()
        {
            Console.WriteLine("{0,-18} {1,-18} {2,-12} {3,-18}", "Role Name", "Department", "Location", "Description");
            for (int i = 0; i < RoleList.Count; i++)
            {
                Console.WriteLine(new string('-', 66));
                Console.WriteLine("{0,-18} {1,-18} {2,-12} {3,-18}", RoleList[i].Name, RoleList[i].Department, RoleList[i].Location, RoleList[i].Description);
            }
        }

    }
}
