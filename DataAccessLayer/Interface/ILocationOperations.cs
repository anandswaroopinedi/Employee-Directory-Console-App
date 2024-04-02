using Models;

namespace DataAccessLayer.Interface
{
    public interface ILocationOperations
    {
        public List<Location> read();
        public bool write(List<Location> locationsList);
    }
}
