using Models;

namespace DataLinkLibrary.Interface
{
    public interface ILocationOperations
    {
        public List<LocationModel> read();
        public void write(List<LocationModel> locationsList);
    }
}
