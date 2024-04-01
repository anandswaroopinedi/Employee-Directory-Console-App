using Models;

namespace LocationManagementLibrary.Interfaces
{
    public interface ILocationManager
    {
        public bool AddLocation(LocationModel location);
        public List<LocationModel> GetAll();
        public string GetLocationName(int id);
    }
}
