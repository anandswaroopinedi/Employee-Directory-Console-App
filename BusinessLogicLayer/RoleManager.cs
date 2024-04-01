using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interface;
using Models;

namespace BusinessLogicLayer
{
    public class RoleManager : IRoleManager
    {
        private readonly IRoleOperations _roleOperations;
        public RoleManager(IRoleOperations roleOperations)
        {
            _roleOperations = roleOperations;
        }

        public void AddRole(RolesModel role)
        {
            List<RolesModel> roleList = _roleOperations.read();
            roleList.Add(role);
            _roleOperations.write(roleList);
        }
        public  bool CheckRoleExists(string roleName)
        {
            List<RolesModel> roleList = _roleOperations.read();
            for (int i = 0; i < roleList.Count; i++)
            {
                if (roleList[i].Name == roleName)
                {
                    return true;
                }
            }
            return false;
        }
        public List<RolesModel> GetAll()
        {
            return _roleOperations.read();
        }
    }
}
