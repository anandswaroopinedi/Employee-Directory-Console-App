using DataAccessLayer.Interface;
using BusinessLogicLayer.Interfaces;
using Models;

namespace BusinessLogicLayer.Managers
{
    public class LocationManager : ILocationManager
    {
        private readonly ILocationOperations _locationOperations;
        public LocationManager(ILocationOperations locationOperations)
        {
            _locationOperations = locationOperations;
        }

        public bool AddLocation(Location location)
        {
            List<Location> locationList = _locationOperations.read();

            if (!CheckLocationExists(location.Name, locationList))
            {
                location.Id = locationList.Count + 1;
                locationList.Add(location);
                if(_locationOperations.write(locationList))
                {
                    return true;
                }
            }
                return false;
        }

        public List<Location> GetAll()
        {
            return _locationOperations.read();
        }
        public string GetLocationName(int id)
        {
            List<Location> locationList = _locationOperations.read();
            for (int i = 0; i < locationList.Count; i++)
            {
                if (locationList[i].Id == id)
                {
                    return locationList[i].Name;
                }
            }
            return "None";
        }
        public static bool CheckLocationExists(string loc, List<Location> locationList)
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
