using TeduMicroservices.IDP.Infrastructure.Persistence;

namespace TeduMicroservices.IDP.Infrastructure.Domains;

public class UnitOfWork : IUnitOfWork
{
    private readonly TeduIdentityContext _context;

    public UnitOfWork(TeduIdentityContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public Task<int> CommitAsync()
    {
        return _context.SaveChangesAsync();
    }
}