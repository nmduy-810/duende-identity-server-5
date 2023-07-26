using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using TeduMicroservices.IDP.Infrastructure.Entities;

namespace TeduMicroservices.IDP.Infrastructure.Repositories;

public interface IRepositoryManager
{
    UserManager<User> UserManager { get; }
    RoleManager<IdentityRole> RoleManager { get; }

    IPermissionsRepository Permissions { get; }
    
    Task<int> SaveAsync();
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task EndTransactionAsync();
    void RollbackTransaction();
}