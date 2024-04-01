using Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IRoleManager
    {
        public void AddRole(RolesModel rolesModel);
        public bool CheckRoleExists(string roleName);
        public List<RolesModel> GetAll();
    }
}
