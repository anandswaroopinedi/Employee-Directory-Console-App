using BusinessLogicLayer.Interfaces;
using DataLinkLibrary.Interface;
using Models;
using Presentation.Interfaces;

namespace Presentation.Services
{
    public sealed class RoleManagement : IRoleManagement
    {
        public static List<RolesModel> RoleList = new List<RolesModel>();
        /*        public static Role RoleHandler = new Role();*/
        private readonly IRoleManager _role;
        private readonly IRoleOperations _roleOperations;
        public RoleManagement(IRoleManager role, IRoleOperations roleOperations)
        {
            _role = role;
            _roleOperations = roleOperations;
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
        public void AddRole()
        {
            Console.Write("Enter New Role Name:");
            string roleName = Console.ReadLine()!.ToUpper();
            if (!CheckRoleExists(roleName))
            {
                RolesModel roleModel = new RolesModel();
                roleModel.Name = roleName;
                _role.AddRole(roleModel,ref StartApp.LocationList,ref StartApp.DepartmentList);
                RoleList.Add(roleModel);
                _roleOperations.write(RoleList);
            }
        }
        public void DisplayAll()
        {
            Console.WriteLine("{0,-18} {1,-18} {2,-12} {3,-18}", "Role Name", "Department", "Location", "Description");
            for (int i = 0; i < RoleList.Count; i++)
            {
                _role.Display(RoleList[i]);
            }
        }

    }
}
