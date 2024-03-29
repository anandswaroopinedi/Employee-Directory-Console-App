using DataAccessLayer.Interface;
using LocationManagementLibrary.Interfaces;
using Models;

namespace LocationManagementLibrary
{
    public class LocationManager : ILocationManager
    {
        private readonly ILocationOperations _locationOperations;
        public LocationManager(ILocationOperations locationOperations)
        {
            _locationOperations = locationOperations;
        }

        public void AddLocation(LocationModel location, ref List<LocationModel> locationList)
        {
            Console.Write("Enter new Location:");
            string loc = Console.ReadLine().ToUpper();
            if (!CheckLocationExists(loc, locationList))
            {
                location.Name = loc;
                locationList.Add(location);
                Console.WriteLine("Location Added Successfully");
                _locationOperations.write(locationList);
            }
        }
        public static bool CheckLocationExists(string loc, List<LocationModel> locationList)
        {
            for (int i = 0; i < locationList.Count; i++)
            {
                if (locationList[i].Name == loc)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
