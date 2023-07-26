using TeduMicroservices.IDP.Infrastructure.Domains;
using TeduMicroservices.IDP.Infrastructure.Entities;
using TeduMicroservices.IDP.Infrastructure.ViewModels;

namespace TeduMicroservices.IDP.Infrastructure.Repositories;

public interface IPermissionsRepository : IRepositoryBase<Permission, long>
{
    Task<IReadOnlyList<PermissionViewModel>> GetPermissionsByRole(string roleId);
    
    void UpdatePermissionsByRoleId(string roleId, IEnumerable<Permission> permissions, bool trackChanges);
}