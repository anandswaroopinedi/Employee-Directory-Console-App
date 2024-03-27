using Models;

namespace LocationManagementLibrary.Interfaces
{
    public interface ILocationPropertyEntryManager
    {
        public string ChooseLocation(ref List<LocationModel> locationList);
        public string CreateLocationRef(ref List<LocationModel> locationList);
    }
}
