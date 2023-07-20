using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeduMicroservices.IDP.Entities;
using TeduMicroservices.IDP.Entities.Configuration;

namespace TeduMicroservices.IDP.Persistence;

public class TeduIdentityContext : IdentityDbContext<User>
{
    public TeduIdentityContext(DbContextOptions<TeduIdentityContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // co 2 cach code de apply configuration
        //builder.ApplyConfiguration(new RoleConfiguration());
        builder.ApplyConfigurationsFromAssembly(typeof(TeduIdentityContext).Assembly);
        builder.ApplyIdentityConfiguration();
    }
}