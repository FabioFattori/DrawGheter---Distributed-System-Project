using System.ComponentModel.DataAnnotations;

namespace DrawGheterInfrastructure.Models;

public class User
{
    public int Id { get; init; }
    
    [MaxLength(20)] public required string Username { get; init; }

    [MaxLength(20)] public required string Email { get; init; }

    [MaxLength(25)] public required string Password { get; init; }
}