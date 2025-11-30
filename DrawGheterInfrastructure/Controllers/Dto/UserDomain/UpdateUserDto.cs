using System.ComponentModel.DataAnnotations;
using DrawGheterInfrastructure.Models;

namespace DrawGheterInfrastructure.Controllers.Dto.UserDomain;

public class UpdateUserDto(Guid id, string email, string password, string username, bool rememberMe = false)
    : CreateUserDto(email, password, username, rememberMe)
{
    [Required] public Guid Id { get; set; } = id;

    public override User ToModel()
    {
        var user = base.ToModel();
        user.Id = Id;
        return user;
    }
}