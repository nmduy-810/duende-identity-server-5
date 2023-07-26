using System.ComponentModel.DataAnnotations;

namespace TeduMicroservices.IDP.Infrastructure.ViewModels;

public class PermissionAddModel
{
    [Required] 
    public string Function { get; set; } = default!;
    
    [Required]
    public string Command { get; set; } = default!;
}