using Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface ILocationManager
    {
        public bool AddLocation(Location location);
        public List<Location> GetAll();
        public string GetLocationName(int id);
    }
}
