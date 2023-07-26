using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using TeduMicroservices.IDP.Infrastructure.Domains;

namespace TeduMicroservices.IDP.Infrastructure.Entities;

public class Permission : EntityBase<long>
{
    [Key]
    [MaxLength(50)]
    [Column(TypeName = "varchar(50)")]
    public string Function { get; set; }
    
    [Key]
    [MaxLength(50)]
    [Column(TypeName = "varchar(50)")]
    public string Command { get; set; }

    [Required]
    [MaxLength(50)]
    [Column(TypeName = "varchar(50)")]
    public string RoleId { get; set; }

    [ForeignKey("RoleId")] 
    
    public virtual IdentityRole Role { get; set; } = default!;

    public Permission(string function, string command, string roleId)
    {
        Function = function;
        Command = command;
        RoleId = roleId;
    }
}