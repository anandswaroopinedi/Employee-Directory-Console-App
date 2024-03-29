using Models;

namespace DataAccessLayer.Interface
{
    public interface ILocationOperations
    {
        public List<LocationModel> read();
        public void write(List<LocationModel> locationsList);
    }
}
