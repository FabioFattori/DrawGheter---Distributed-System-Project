using System.ComponentModel.DataAnnotations;
using DrawGheterInfrastructure.Models;

namespace DrawGheterInfrastructure.Controllers.Dto;

public class CreateUserDto(string email, string password, string username) : IBaseDto<User>
{
    [Required] 
    [EmailAddress]
    [MaxLength(50)]
    public string Email { get; set; } = email;

    [Required]
    [MinLength(5)]
    [MaxLength(30)]
    public string Password { get; set; } = password;

    [Required]
    [MinLength(5)]
    [MaxLength(30)]
    public string Username { get; set; } = username;


    public virtual User ToModel()
    {
        return new User
        {
            Email = Email,
            Password = Password,
            Username = Username
        };
    }

    public virtual bool IsValid()
    {
        return true;
    }
}