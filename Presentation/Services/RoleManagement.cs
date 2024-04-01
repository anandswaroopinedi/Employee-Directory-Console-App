using BusinessLogicLayer.Interfaces;
using DepartmentManagementLibrary.Interfaces;
using LocationManagementLibrary.Interfaces;
using Models;
using Presentation.Interfaces;

namespace Presentation.Services
{
    public sealed class RoleManagement : IRoleManagement
    {

        private readonly IRoleManager _roleManager;
        private readonly IDepartmentPropertyEntryManager _departmentPropertyEntryManager;
        private readonly ILocationPropertyEntryManager _locationPropertyEntryManager;
        private readonly IRolePropertyEntryManager _rolePropertyEntryManager;
        public RoleManagement(IRoleManager roleManager, ILocationPropertyEntryManager locationPropertyEntryManager, IDepartmentPropertyEntryManager departmentPropertyEntryManager, IRolePropertyEntryManager rolePropertyEntryManager)
        {
            _roleManager = roleManager;
            _departmentPropertyEntryManager = departmentPropertyEntryManager;
            _locationPropertyEntryManager = locationPropertyEntryManager;
            _rolePropertyEntryManager = rolePropertyEntryManager;
        }

        private bool GetRoleDetailsInput(RolesModel role)
        {
            Console.WriteLine("Roles");
            role.Department = _departmentPropertyEntryManager.ChooseDepartment();
            if (role.Department == "Abort")
            {
                return false;
            }
            Console.WriteLine("Roles");
            role.Location = _locationPropertyEntryManager.ChooseLocation();
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
        public string AddRole()
        {
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Enter New Role:");
            Console.Write("Choose option from above:");
            int.TryParse(Console.ReadLine(), out int option);
            if (option == 0)
            {
                return "Abort";
            }
            else if (option == 1)
            {
                Console.Write("Enter Role Name:");
                string roleName = Console.ReadLine()!.ToUpper();
                if (!_roleManager.CheckRoleExists(roleName))
                {
                    RolesModel roleModel = new RolesModel();
                    roleModel.Name = roleName;
                    bool result = GetRoleDetailsInput(roleModel);
                    if (result)
                    {
                        _roleManager.AddRole(roleModel);
                        
                        Console.WriteLine("RoleList Added Successfully");
                        return roleName;
                    }
                    else
                    {
                        Console.WriteLine("Failed to Add Role");
                        return "failed";
                    }
                }
                else
                {
                    Console.WriteLine("Role Exists Previously in the database so u can't add again");
                    return "failed";
                }
            }
            else
            { 
                Console.WriteLine("Choose from above options only.");
                return AddRole();
            }
        }
        public void DisplayAll()
        {
            List<RolesModel> roleList = _roleManager.GetAll();
            Console.WriteLine("{0,-18} {1,-18} {2,-12} {3,-18}", "Role Name", "Department", "Location", "Description");
            for (int i = 0; i < roleList.Count; i++)
            {
                Console.WriteLine(new string('-', 66));
                Console.WriteLine("{0,-18} {1,-18} {2,-12} {3,-18}", roleList[i].Name, roleList[i].Department, roleList[i].Location, roleList[i].Description);
            }
        }

    }
}
