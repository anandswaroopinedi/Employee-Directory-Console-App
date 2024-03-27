using Models;

namespace LocationManagementLibrary.Interfaces
{
    public interface ILocationManager
    {
        public void AddLocation(LocationModel location,ref List<LocationModel> locationList);
    }
}
