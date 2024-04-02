﻿using BusinessLogicLayer.Interfaces;
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
        private readonly ILocationManager _locationManager;
        private readonly IDepartmentManager _departmentManager;
        public RoleManagement(IRoleManager roleManager, ILocationPropertyEntryManager locationPropertyEntryManager, IDepartmentPropertyEntryManager departmentPropertyEntryManager, IRolePropertyEntryManager rolePropertyEntryManager, ILocationManager locationManager, IDepartmentManager departmentManager)
        {
            _roleManager = roleManager;
            _departmentPropertyEntryManager = departmentPropertyEntryManager;
            _locationPropertyEntryManager = locationPropertyEntryManager;
            _rolePropertyEntryManager = rolePropertyEntryManager;
            _locationManager = locationManager;
            _departmentManager = departmentManager;
        }

        private bool GetRoleDetailsInput(Roles role)
        {
            Console.WriteLine("Roles");
            role.DepartmentId = _departmentPropertyEntryManager.ChooseDepartment();
            if (role.DepartmentId == 0)
            {
                return false;
            }
            Console.WriteLine("Roles");
            role.LocationId = _locationPropertyEntryManager.ChooseLocation();
            if (role.LocationId == 0)
            {
                return false;
            }
            role.Description = _rolePropertyEntryManager.GetDescription();
            if (role.Description == "Abort")
            {
                return false;
            }
            return true;
        }
        public int AddRole()
        {
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Enter New Role:");
            Console.Write("Choose option from above:");
            int.TryParse(Console.ReadLine(), out int option);
            if (option == 0)
            {
                return 0;
            }
            else if (option == 1)
            {
                Console.Write("Enter Role Name:");
                string roleName = Console.ReadLine()!.ToUpper();
                if (!_roleManager.CheckRoleExists(roleName))
                {
                    Roles roleModel = new Roles();
                    roleModel.Name = roleName;
                    bool result = GetRoleDetailsInput(roleModel);
                    if (result && _roleManager.AddRole(roleModel))
                    {
                        Console.WriteLine($"RoleList Added Successfully with Id:{roleModel.Id}");
                        return roleModel.Id;
                    }
                    else
                    {
                        Console.WriteLine("Failed to Add Role");
                        return -1;
                    }
                   
                }
                else
                {
                    Console.WriteLine("Role Exists Previously in the database so u can't add again");
                    return -1;
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
            List<Roles> roleList = _roleManager.GetAll();
            Console.WriteLine("{0,-18} {1,-18} {2,-12} {3,-18}", "Role Name", "Department", "Location", "Description");
            for (int i = 0; i < roleList.Count; i++)
            {
                Console.WriteLine(new string('-', 66));
                Console.WriteLine("{0,-18} {1,-18} {2,-12} {3,-18}", roleList[i].Name, _departmentManager.GetDepartmentName(roleList[i].DepartmentId), _locationManager.GetLocationName(roleList[i].LocationId), roleList[i].Description);
            }
        }

    }
}
