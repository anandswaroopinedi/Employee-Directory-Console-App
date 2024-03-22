using EmployeeDirectoryConsoleApp.Interfaces;
using EmployeeDirectoryConsoleApp.Models;
using EmployeeDirectoryConsoleApp.StreamOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.Services
{
    public  sealed class RoleManagement:IRoleManagement
    {
        public static List<RolesModel> RoleList=new List<RolesModel>();
        /*        public static Role RoleHandler = new Role();*/
        private readonly IStartApp _employeeDirectory;
        private readonly IRoleManager Role;
        public RoleManagement(IRoleManager role)
        {
               Role = role;
        }
        public void DisplayMenu()
        {
            Console.WriteLine("Options :");
            Console.WriteLine("1. Add Role");
            Console.WriteLine("2. Display All");
            Console.WriteLine("3. Go Back");
            Console.Write("Choose any option from above:");
            int option;
            int.TryParse(Console.ReadLine(), out option);
            switch (option)
            {
                case 1:
                    this.AddRole();
                    break;
                case 2:
                    this.DisplayAll();
                    break;
                case 3:
                    _employeeDirectory.Run();
                    break;
                default:
                    Console.WriteLine("Select option from the above list only\n");
                    break;
            }
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
            if(!CheckRoleExists(roleName))
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
            for (int i = 0;i < RoleList.Count;i++)
            {
                Role.Display(RoleList[i]);
            }
        }

    }
}
