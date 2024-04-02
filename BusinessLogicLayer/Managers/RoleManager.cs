using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interface;
using Models;

namespace BusinessLogicLayer.Managers
{
    public class RoleManager : IRoleManager
    {
        private readonly IRoleOperations _roleOperations;
        private readonly ILocationOperations _locationOperations;
        private readonly IDepartmentOperations _departmentOperations;
        public RoleManager(IRoleOperations roleOperations, ILocationOperations locationOperations, IDepartmentOperations departmentOperations)
        {
            _roleOperations = roleOperations;
            _locationOperations = locationOperations;
            _departmentOperations = departmentOperations;
        }

        public bool AddRole(Roles role)
        {
            List<Roles> roleList = _roleOperations.read();
            role.Id = roleList.Count + 1;
            roleList.Add(role);
            if(_roleOperations.write(roleList))
            {
                return true;
            }
            return false;
        }
        public bool CheckRoleExists(string roleName)
        {
            List<Roles> roleList = _roleOperations.read();
            for (int i = 0; i < roleList.Count; i++)
            {
                if (roleList[i].Name == roleName)
                {
                    return true;
                }
            }
            return false;
        }
        public List<Roles> GetAll()
        {
            return _roleOperations.read();
        }
        public string GetRoleName(int id)
        {
            List<Roles> rolesList = _roleOperations.read();
            for (int i = 0; i < rolesList.Count; i++)
            {
                if (rolesList[i].Id == id)
                {
                    return rolesList[i].Name;
                }
            }
            return "None";
        }
    }
}
