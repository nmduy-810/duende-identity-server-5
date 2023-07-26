using TeduMicroservices.IDP.Infrastructure.Domains;
using TeduMicroservices.IDP.Infrastructure.Entities;

namespace TeduMicroservices.IDP.Infrastructure.Repositories;

public interface IPermissionsRepository : IRepositoryBase<Permission, long>
{
    Task<IEnumerable<Permission>> GetPermissionsByRole(string roleId, bool trackChanges);
    void UpdatePermissionsByRoleId(string roleId, IEnumerable<Permission> permissions, bool trackChanges);
}