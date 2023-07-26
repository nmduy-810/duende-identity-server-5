using TeduMicroservices.IDP.Infrastructure.Domains;
using TeduMicroservices.IDP.Infrastructure.Entities;
using TeduMicroservices.IDP.Infrastructure.Persistence;

namespace TeduMicroservices.IDP.Infrastructure.Repositories;

public class PermissionRepository : RepositoryBase<Permission, long>, IPermissionsRepository
{
    public PermissionRepository(TeduIdentityContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
    {
    }

    public Task<IEnumerable<Permission>> GetPermissionsByRole(string roleId, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public void UpdatePermissionsByRoleId(string roleId, IEnumerable<Permission> permissions, bool trackChanges)
    {
        throw new NotImplementedException();
    }
}