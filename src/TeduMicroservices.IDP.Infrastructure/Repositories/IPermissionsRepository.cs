using TeduMicroservices.IDP.Infrastructure.Domains;
using TeduMicroservices.IDP.Infrastructure.Entities;
using TeduMicroservices.IDP.Infrastructure.ViewModels;

namespace TeduMicroservices.IDP.Infrastructure.Repositories;

public interface IPermissionsRepository : IRepositoryBase<Permission, long>
{
    Task<IReadOnlyList<PermissionViewModel>> GetPermissionsByRole(string roleId);
    
    Task<PermissionViewModel?> CreatePermission(string roleId, PermissionAddModel model);
    
    Task DeletePermission(string roleId, string function, string command);
    
    Task UpdatePermissionsByRoleId(string roleId, IEnumerable<PermissionAddModel> permissionCollection);
}