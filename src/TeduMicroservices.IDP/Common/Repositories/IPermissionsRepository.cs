using TeduMicroservices.IDP.Common.Domains;
using TeduMicroservices.IDP.Entities;

namespace TeduMicroservices.IDP.Common.Repositories;

public interface IPermissionsRepository : IRepositoryBase<Permission, long>
{
    Task<IEnumerable<Permission>> GetPermissionsByRole(string roleId, bool trackChanges);
    void UpdatePermissionsByRoleId(string roleId, IEnumerable<Permission> permissions, bool trackChanges);
}