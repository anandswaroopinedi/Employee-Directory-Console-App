using EmployeeDirectoryConsoleApp.Interfaces;
using EmployeeDirectoryConsoleApp.Models;
using EmployeeDirectoryConsoleApp.Presentation.Interfaces;
using EmployeeDirectoryConsoleApp.StreamOperations;

namespace EmployeeDirectoryConsoleApp.Presentation.Services
{
    public sealed class RoleManagement : IRoleManagement
    {
        public static List<RolesModel> RoleList = new List<RolesModel>();
        /*        public static Role RoleHandler = new Role();*/
        private readonly IRoleManager Role;
        public RoleManagement(IRoleManager role)
        {
            Role = role;
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
                Role.AddRole(roleModel);
                RoleList.Add(roleModel);
                ByteStreamOperations.StoreRolesData();
            }
        }
        public void DisplayAll()
        {
            Console.WriteLine("{0,-18} {1,-18} {2,-12} {3,-18}", "Role Name", "Department", "Location", "Description");
            for (int i = 0; i < RoleList.Count; i++)
            {
                Role.Display(RoleList[i]);
            }
        }

    }
}
