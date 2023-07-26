using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeduMicroservices.IDP.Infrastructure.Entities;

namespace TeduMicroservices.IDP.Infrastructure.Persistence;

public class TeduIdentityContext : IdentityDbContext<User>
{
    public TeduIdentityContext(DbContextOptions<TeduIdentityContext> options) : base(options)
    {
        
    }
    
    public DbSet<Permission> Permissions { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // co 2 cach code de apply configuration
        //builder.ApplyConfiguration(new RoleConfiguration());
        builder.ApplyConfigurationsFromAssembly(typeof(TeduIdentityContext).Assembly);
        builder.ApplyIdentityConfiguration();
    }
}