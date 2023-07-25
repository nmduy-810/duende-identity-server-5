using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using TeduMicroservices.IDP.Common.Domains;
using TeduMicroservices.IDP.Entities;
using TeduMicroservices.IDP.Persistence;

namespace TeduMicroservices.IDP.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly TeduIdentityContext _dbContext;
    public UserManager<User> UserManager { get; }
    public RoleManager<User> RoleManager { get; }

    public RepositoryManager(TeduIdentityContext dbContext, IUnitOfWork unitOfWork, UserManager<User> userManager, RoleManager<User> roleManager)
    {
        _dbContext = dbContext;
        _unitOfWork = unitOfWork;
        UserManager = userManager;
        RoleManager = roleManager;
    }
    
    public Task<int> SaveAsync() => _unitOfWork.CommitAsync();

    public Task<IDbContextTransaction> BeginTransactionAsync() => _dbContext.Database.BeginTransactionAsync();

    public Task EndTransactionAsync() => _dbContext.Database.CommitTransactionAsync();

    public void RollbackTransaction() => _dbContext.Database.RollbackTransactionAsync();
}