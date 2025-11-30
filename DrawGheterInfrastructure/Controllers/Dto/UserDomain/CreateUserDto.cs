using System.ComponentModel.DataAnnotations;
using DrawGheterInfrastructure.Models;

namespace DrawGheterInfrastructure.Controllers.Dto.UserDomain;

public class CreateUserDto(string email, string password, string username, bool rememberMe = false) : IBaseDto<User>
{
    [Required]
    [EmailAddress]
    [MaxLength(50)]
    public string Email { get; set; } = email;

    [Required]
    [MinLength(5)]
    [MaxLength(30)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = password;

    [Required]
    [MinLength(5)]
    [MaxLength(30)]
    public string Username { get; set; } = username;

    public bool RememberMe { get; set; } = rememberMe;


    public virtual User ToModel()
    {
        return new User
        {
            Id = Guid.Empty,
            Email = Email,
            Password = Password,
            Username = Username,
            RememberMe = RememberMe
        };
    }

    public virtual bool IsValid()
    {
        return true;
    }
}