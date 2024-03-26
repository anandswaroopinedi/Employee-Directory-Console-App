using EmployeeDirectoryConsoleApp.DataPresentation;
using EmployeeDirectoryConsoleApp.DataPresentation.Interface;
using EmployeeDirectoryConsoleApp.Interfaces;
using EmployeeDirectoryConsoleApp.Presentation;
using EmployeeDirectoryConsoleApp.Presentation.Interfaces;
using EmployeeDirectoryConsoleApp.Presentation.Services;
using EmployeeDirectoryConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeDirectoryConsoleApp
{

    class Program
    {


        public Program() { }

        public static void Main(String[] args)
        {

            var services = new ServiceCollection();
            services.AddTransient<IEmployeeManager, Services.EmployeeManager>();
            /*services.AddTransient<IRoleDisplayMenuManagement, RoleDisplayMenuManagement>();*/
            services.AddTransient<IRoleManager, RoleManager>();
            services.AddTransient<IRoleManagement, RoleManagement>();
            services.AddTransient<IEmployeeManagement, EmployeeManagement>();
            services.AddTransient<IEmployeePropertyEntryManager, EmployeePropertyEntryManager>();
            services.AddTransient<IDepartmentManager, Services.DepartmentManager>();
            services.AddTransient<ILocationManager, LocationManager>();
            services.AddTransient<IEmployeeOperations, EmployeeOperations>();
            services.AddTransient<IRoleOperations, RoleOperations>();
            services.AddTransient<IDepartmentOperations, DepartmentOperations>();
            services.AddTransient<ILocationOperations, LocationOperations>();
            services.AddTransient<ILocationPropertyEntryManager, LocationPropertyEntryManager>();
            services.AddTransient<IRolePropertyEntryManager, RolePropertyEntryManager>();
            services.AddTransient<IDepartmentPropertyEntryManager, DepartmentPropertyEntryManager>();
            services.AddSingleton<StartApp>();
          //  services.AddTransient<IStartApp, StartApp>();
            services.AddTransient<IDisplayMenuManagement, DisplayMenuManagement>();
            var serviceProvider = services.BuildServiceProvider();
            var startApp = serviceProvider.GetRequiredService<StartApp>();
            startApp.Run();
        }


    }


}
