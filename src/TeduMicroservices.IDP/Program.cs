using TeduMicroservices.IDP.Extensions;
using Serilog;
using TeduMicroservices.IDP.Persistence;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.AddAppConfigurations();
    builder.Host.ConfigureSerilog();
    
    var app = builder
        .ConfigureServices()
        .ConfigurePipeline();
    
    // Seed user data
    SeedUserData.EnsureSeedData(builder.Configuration.GetConnectionString("IdentitySqlConnection"));
    
    app.MigrateDatabase().Run();
}
catch (Exception ex)
{
    var type = ex.GetType().Name;
    if (type.Equals("HostAbortedException", StringComparison.Ordinal)) throw;
    Log.Fatal(ex, "Unhandled exception: {EMessage}", ex.Message);
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}