using Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IRoleManager
    {
        public void AddRole(RolesModel rolesModel,ref List<LocationModel> locationList,ref List<DepartmentModel> departmentList);
        public void Display(RolesModel rolesModel);
    }
}
