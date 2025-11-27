using System.ComponentModel.DataAnnotations;

namespace DrawGheterInfrastructure.Models;

public class User
{
    public int Id { get; set; }
    
    [MaxLength(50)] public required string Username { get; init; }

    [MaxLength(50)] public required string Email { get; init; }

    [MaxLength(30)] public required string Password { get; init; }
}