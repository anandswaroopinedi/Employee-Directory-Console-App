using EmployeeDirectoryConsoleApp.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.Presentation.Services
{
    public class RolePropertyEntryManager : IRolePropertyEntryManager
    {
/*        private IRoleManagement _roleManagement;
        *//* public IRoleManagement roleManagement
         {
             get { return _roleManagement; }
             set { _roleManagement = value; }
         }*//*
        public RolePropertyEntryManager(IRoleManagement roleManagement)
        {
            _roleManagement = roleManagement;
        }
        private readonly IDisplayMenuManagement _displayMenuManagement;
        public static void DisplayRolesNames()
        {
            for (int i = 0; i < RoleManagement.RoleList.Count; i++)
            {
                Console.WriteLine($"{i + 1}.  {RoleManagement.RoleList[i].Name}");
            }
        }
        public string ChooseRole()
        {
            int option;
            Console.WriteLine("Roles:");
            Console.WriteLine("0. Enter New Role:");
            DisplayRolesNames();
            Console.Write("Choose Roles from above options*:");
            int.TryParse(Console.ReadLine(), out option);
            if (option == 0)
            {
                *//*RoleManagement roleManagement = new RoleManagement();*//*
                //_roleManagement.AddRole();
                return RoleManagement.RoleList[RoleManagement.RoleList.Count - 1].Name;
            }
            if (option > 0 && option <= RoleManagement.RoleList.Count)
            {
                return RoleManagement.RoleList[option - 1].Name;
            }
            else
            {
                Console.WriteLine("Select option from the above list only");
                return ChooseRole();
            }
        }*/
        public string GetDescription()
        {
            string description = "";
            Console.WriteLine("Description:");
            Console.WriteLine("1. Upload Later");
            Console.WriteLine("2. Enter Description");
            Console.Write("Choose from above options:");
            int.TryParse(Console.ReadLine(), out int option);
            switch (option)
            {
                case 1:
                    description = "None";
                    return description;
                case 2:
                    Console.Write("Enter the Description:");
                    description = Console.ReadLine();
                    if (description == "")
                    {
                        return GetDescription();
                    }
                    else
                    {
                        return description;
                    }
                default:
                    Console.WriteLine("Select option from the above list only");
                    return GetDescription();
            }
        }
    }
}
