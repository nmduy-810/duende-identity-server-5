using Microsoft.AspNetCore.Mvc;
using TeduMicroservices.IDP.Infrastructure.Repositories;

namespace TeduMicroservices.IDP.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissionsController : ControllerBase
{
    private readonly IRepositoryManager _repositoryManager;
    
    public PermissionsController(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetPermissions(string roleId)
    {
        var result = await _repositoryManager.Permissions.GetPermissionsByRole(roleId);
        return Ok(result);
    }
}