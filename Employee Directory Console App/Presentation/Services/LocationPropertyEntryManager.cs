using EmployeeDirectoryConsoleApp.Presentation.Interfaces;
using EmployeeDirectoryConsoleApp.DataPresentation.Interface;
using EmployeeDirectoryConsoleApp.Interfaces;
using EmployeeDirectoryConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.Presentation.Services
{
    public class LocationPropertyEntryManager:ILocationPropertyEntryManager
    {
        private readonly ILocationManager _locationManager;
        private readonly ILocationOperations _locationOperations;
        public LocationPropertyEntryManager(ILocationManager locationManager, ILocationOperations locationOperations)
        {
            _locationManager = locationManager;
            _locationOperations = locationOperations;
        }

        public string CreateLocationRef()
        {
            LocationModel locationModel = new LocationModel();
            _locationManager.AddLocation(locationModel);
            _locationOperations.write();
            return locationModel.Name;
        }
        public static void DisplayLocationList()
        {
            for (int i = 0; i < StartApp.LocationList.Count; i++)
            {
                Console.WriteLine($"{i + 1}.  {StartApp.LocationList[i].Name}");
            }
        }
        public string ChooseLocation()
        {
            Console.WriteLine("Locations:");
            Console.WriteLine("0.  Add New Location");
            DisplayLocationList();
            Console.Write("Choose Location from above options:");
            int option;
            int.TryParse(Console.ReadLine(), out option);
            if (option == 0)
            {
                return this.CreateLocationRef();
            }
            if (option > 0 && option <= StartApp.LocationList.Count)
            {
                return StartApp.LocationList[option - 1].Name;
            }
            else
            {
                Console.WriteLine("Select option from the above list only");
                return ChooseLocation();
            }
        }
    }
}
