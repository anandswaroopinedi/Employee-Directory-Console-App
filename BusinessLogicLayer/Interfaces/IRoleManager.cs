using Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IRoleManager
    {
        public void AddRole(RolesModel rolesModel, ref List<RolesModel> roleList);
    }
}
