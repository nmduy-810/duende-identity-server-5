using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using TeduMicroservices.IDP.Infrastructure.Repositories;
using TeduMicroservices.IDP.Infrastructure.ViewModels;

namespace TeduMicroservices.IDP.Presentation.Controllers;

[ApiController]
[Route("api/[controller]/roles/{roleId}")]
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
    
    [HttpPost]
    [ProducesResponseType(typeof(PermissionViewModel), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreatePermission(string roleId, [FromBody] PermissionAddModel model)
    {
        var result = await _repositoryManager.Permissions.CreatePermission(roleId, model);
        return result != null ? Ok(result) : NoContent();
    }
    
    [HttpDelete("function/{function}/command/{command}")]
    [ProducesResponseType(typeof(PermissionViewModel), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeletePermission(string roleId, [Required] string function, [Required] string command)
    {
        await _repositoryManager.Permissions.DeletePermission(roleId, function, command);
        return NoContent();
    }
    
    [HttpPut("update-permissions")]
    [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdatePermissions(string roleId, [FromBody]IEnumerable<PermissionAddModel> permissions)
    {
        await _repositoryManager.Permissions.UpdatePermissionsByRoleId(roleId, permissions);
        return NoContent(); 
    }
}