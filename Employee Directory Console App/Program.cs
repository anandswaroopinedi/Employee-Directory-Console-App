using EmployeeDirectoryConsoleApp.Models;
using EmployeeDirectoryConsoleApp.Services;
using EmployeeDirectoryConsoleApp.StreamOperations;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Authentication.ExtendedProtection;
using EmployeeDirectoryConsoleApp.Interfaces;
using EmployeeDirectoryConsoleApp.DataPresentation.Interface;
using EmployeeDirectoryConsoleApp.DataPresentation;

namespace EmployeeDirectoryConsoleApp
{

    class EmployeeDirectory
    {
        

        public EmployeeDirectory() { }

        public static void Main(String[] args)
        {

            var services = new ServiceCollection();
            services.AddSingleton<IEmployeeManager, Services.EmployeeManager>();
            services.AddSingleton<IRoleManager, RoleManager>();
            services.AddSingleton<IRoleManagement, RoleManagement>();
            services.AddSingleton<IEmployeeManagement, EmployeeManagement>();
            services.AddSingleton<IEmployeePropertyEntries, EmployeePropertyEntries>();
            services.AddSingleton<IDepartment, Services.Department>();
            services.AddSingleton<ILocation, Location>();
            services.AddSingleton<IEmployeeOperations, EmployeeOperations>();
            services.AddSingleton<IRoleOperations, RoleOperations>();
            services.AddSingleton<IDepartmentOperations, DepartmentOperations>();
            services.AddSingleton<ILocationOperations, LocationOperations>();
            services.AddSingleton<IDepartmentLocationManagement, DepartmentLocationManagement>();
            services.AddSingleton<IStartApp, StartApp>();
            var serviceProvider = services.BuildServiceProvider();
            var startApp=serviceProvider.GetRequiredService<IStartApp>();
            startApp.Register();
        }
        
    
    }


}
