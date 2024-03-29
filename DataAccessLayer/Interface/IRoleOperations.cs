using Models;

namespace DataAccessLayer.Interface
{
    public interface IRoleOperations
    {
        public List<RolesModel> read();
        public void write(List<RolesModel> roleList);
    }
}
