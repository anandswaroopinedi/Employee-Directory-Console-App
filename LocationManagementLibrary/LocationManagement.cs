using LocationManagementLibrary.Interfaces;
using Models;

namespace LocationManagementLibrary
{
    public class LocationManagement : ILocationManagement
    {
        private readonly ILocationManager _locationManager;
        public LocationManagement(ILocationManager locationManager)
        {
            _locationManager = locationManager;
        }
        public void AddLocation()
        {
            Console.WriteLine("Enter Location Name:");
            string location = Console.ReadLine();
            
            if (!string.IsNullOrEmpty(location))
            {
                LocationModel locationModel = new LocationModel();
                locationModel.Name = location;
                if (_locationManager.AddLocation(locationModel))
                {
                    Console.WriteLine("Location Added Successfully");
                }
                else
                {
                    Console.WriteLine("Location already exists");
                }
            }
            else
            {
                Console.WriteLine("Location can't be null");
            }
        }
        public void DisplayAll()
        {
            List<LocationModel> locationList = _locationManager.GetAll();
            Console.WriteLine($"Locations(Count:{locationList.Count}):");
            for (int i = 0; i < locationList.Count; i++)
            {
                Console.WriteLine($"{locationList[i].Id}. {locationList[i].Name}");
            }
        }
    }
}
