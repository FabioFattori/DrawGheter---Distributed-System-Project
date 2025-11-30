using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DrawGheterInfrastructure.Models;

public class User : IdentityUser<Guid>
{
    public override required Guid Id { get; set; }

    [MaxLength(50)] public required string Username { get; init; }

    [MaxLength(50)] public override required string? Email { get; set; }

    [MaxLength(30)] public required string Password { get; init; }
    public bool RememberMe { get; set; } = false;
}