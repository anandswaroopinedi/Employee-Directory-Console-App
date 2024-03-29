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

        public void AddRole(RolesModel role, ref List<RolesModel> roleList)
        {
            roleList.Add(role);
            _roleOperations.write(roleList);
        }
    }
}
