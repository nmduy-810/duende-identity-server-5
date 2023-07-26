using TeduMicroservices.IDP.Infrastructure.Domains;

namespace TeduMicroservices.IDP.Infrastructure.ViewModels;

public class PermissionViewModel : EntityBase<long>
{
    public string Function { get; set; } = default!;
    
    public string Command { get; set; } = default!;

    public string RoleId { get; set; } = default!;
}