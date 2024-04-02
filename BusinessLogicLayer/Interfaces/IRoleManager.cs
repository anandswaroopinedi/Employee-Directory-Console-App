using Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IRoleManager
    {
        public bool AddRole(Roles rolesModel);
        public bool CheckRoleExists(string roleName);
        public List<Roles> GetAll();
        public string GetRoleName(int id);
    }
}
