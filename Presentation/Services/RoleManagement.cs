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
        private bool GetRoleDetailsInput(RolesModel role)
        {
            Console.WriteLine("Roles");
            role.Department = _departmentPropertyEntryManager.ChooseDepartment(ref StartApp.DepartmentList);
            if (role.Department == "Abort")
            {
                return false;
            }
            Console.WriteLine("Roles");
            role.Location = _locationPropertyEntryManager.ChooseLocation(ref StartApp.LocationList);
            if(role.Location=="Abort")
            {
                return false;
            }
            role.Description = _rolePropertyEntryManager.GetDescription();
            if (role.Description =="Abort")
            {
                return false;
            }
            return true;
        }
        public void AddRole()
        {
            
            Console.WriteLine("0. Enter New Role:");
            Console.WriteLine("1. Exit");
            Console.Write("Choose option from above:");
            int.TryParse(Console.ReadLine(), out int option);
            if (option == 1)
            {
                return;
            }
            else if (option == 0)
            {
                Console.Write("Enter Role Name:");
                string roleName = Console.ReadLine()!.ToUpper();
                if (!CheckRoleExists(roleName))
                {
                    RolesModel roleModel = new RolesModel();
                    roleModel.Name = roleName;
                    bool result = GetRoleDetailsInput(roleModel);
                    if (result)
                    {
                        _role.AddRole(roleModel, ref RoleList);
                        Console.WriteLine("RoleList Added Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Failed to Add Role");
                    }
                }
                else
                {
                    Console.WriteLine("Role Exists Previously in the database so u can't add again");
                }
            }
            else
            { Console.WriteLine("Choose from above options only."); }
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
