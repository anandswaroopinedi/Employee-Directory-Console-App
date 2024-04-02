using Models;

namespace DataAccessLayer.Interface
{
    public interface IRoleOperations
    {
        public List<Roles> read();
        public bool write(List<Roles> roleList);
    }
}
