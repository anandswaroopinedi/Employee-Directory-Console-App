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

        public bool AddLocation(LocationModel location)
        {
            List<LocationModel> locationList = _locationOperations.read();

            if (!CheckLocationExists(location.Name, locationList))
            {
                location.Id=locationList.Count+1;
                locationList.Add(location);
                _locationOperations.write(locationList);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<LocationModel> GetAll()
        {
            return _locationOperations.read();
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
