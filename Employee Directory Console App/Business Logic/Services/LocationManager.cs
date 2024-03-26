using EmployeeDirectoryConsoleApp.DataPresentation.Interface;
using EmployeeDirectoryConsoleApp.Interfaces;
using EmployeeDirectoryConsoleApp.Models;
using EmployeeDirectoryConsoleApp.Presentation;

namespace EmployeeDirectoryConsoleApp.Services
{
    public class LocationManager : ILocationManager
    {
        private readonly ILocationOperations _locationOperations;
        public LocationManager(ILocationOperations locationOperations)
        {
            _locationOperations = locationOperations;
        }

        public void AddLocation(LocationModel location)
        {
            Console.Write("Enter new Location:");
            string loc = Console.ReadLine().ToUpper();
            if (!CheckLocationExists(loc))
            {
                location.Name = loc;
                StartApp.LocationList.Add(location);
                _locationOperations.write();
            }
        }
        public static bool CheckLocationExists(string loc)
        {
            for (int i = 0; i < StartApp.LocationList.Count; i++)
            {
                if (StartApp.LocationList[i].Name == loc)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
