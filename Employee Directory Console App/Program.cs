using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interface;
using DepartmentManagementLibrary;
using DepartmentManagementLibrary.Interfaces;
using LocationManagementLibrary;
using LocationManagementLibrary.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Interfaces;
using Presentation.Services;
using ProjectManagementLibrary;
using ProjectManagementLibrary.Interfaces;

namespace EmployeeDirectoryConsoleApp
{

    class Program
    {
        public static void Main(String[] args)
        {

            var services = new ServiceCollection();
            services.AddTransient<IEmployeeManager, EmployeeManager>();
            services.AddTransient<IRoleManager, RoleManager>();
            services.AddTransient<IRoleManagement, RoleManagement>();
            services.AddTransient<IEmployeeManagement, EmployeeManagement>();
            services.AddTransient<IEmployeePropertyEntryManager, EmployeePropertyEntryManager>();
            services.AddTransient<IDepartmentManager, DepartmentManager>();
            services.AddTransient<ILocationManager, LocationManager>();
            services.AddTransient<IEmployeeOperations, EmployeeOperations>();
            services.AddTransient<IRoleOperations, RoleOperations>();
            services.AddTransient<IDepartmentOperations, DepartmentOperations>();
            services.AddTransient<ILocationOperations, LocationOperations>();
            services.AddTransient<ILocationPropertyEntryManager, LocationPropertyEntryManager>();
            services.AddTransient<IRolePropertyEntryManager, RolePropertyEntryManager>();
            services.AddTransient<IDepartmentPropertyEntryManager, DepartmentPropertyEntryManager>();
            services.AddTransient<IProjectOperations, ProjectOperations>();
            services.AddTransient<IProjectManagement, ProjectManagement>();
            services.AddTransient<IProjectManager, ProjectManager>();
            services.AddTransient<IDepartmentManagement, DepartmentManagement>();
            services.AddTransient<ILocationManagement, LocationManagement>();
            services.AddSingleton<StartApp>();
            services.AddTransient<IDisplayMenuManagement, DisplayMenuManagement>();
            var serviceProvider = services.BuildServiceProvider();
            var startApp = serviceProvider.GetRequiredService<StartApp>();
            startApp.Run();
        }
    }
}
