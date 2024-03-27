

using DataLinkLibrary.Interface;
using LocationManagementLibrary.Interfaces;
using Models;

namespace LocationManagementLibrary
{
    public class LocationPropertyEntryManager : ILocationPropertyEntryManager
    {
        private readonly ILocationManager _locationManager;
        private readonly ILocationOperations _locationOperations;
        public LocationPropertyEntryManager(ILocationManager locationManager, ILocationOperations locationOperations)
        {
            _locationManager = locationManager;
            _locationOperations = locationOperations;
        }

        public string CreateLocationRef(ref List<LocationModel> locationList)
        {
            LocationModel locationModel = new LocationModel();
            _locationManager.AddLocation(locationModel, ref locationList);
            _locationOperations.write(locationList);
            return locationModel.Name;
        }
        public static void DisplayLocationList(List<LocationModel> locationList)
        {
            for (int i = 0; i < locationList.Count; i++)
            {
                Console.WriteLine($"{i + 1}.  {locationList[i].Name}");
            }
        }
        public string ChooseLocation(ref List<LocationModel> locationList)
        {
            Console.WriteLine("Locations:");
            Console.WriteLine("0.  Add New Location");
            DisplayLocationList(locationList);
            Console.Write("Choose Location from above options:");
            int option;
            int.TryParse(Console.ReadLine(), out option);
            if (option == 0)
            {
                return this.CreateLocationRef(ref locationList);
            }
            if (option > 0 && option <= locationList.Count)
            {
                return locationList[option - 1].Name;
            }
            else
            {
                Console.WriteLine("Select option from the above list only");
                return ChooseLocation(ref locationList);
            }
        }
    }
}
