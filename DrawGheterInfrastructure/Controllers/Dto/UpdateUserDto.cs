using System.ComponentModel.DataAnnotations;
using DrawGheterInfrastructure.Models;

namespace DrawGheterInfrastructure.Controllers.Dto;

public class UpdateUserDto(int id, string email, string password, string username)
    : CreateUserDto(email, password, username)
{
    [Required] public int Id { get; set; } = id;

    public override User ToModel()
    {
        var user = base.ToModel();
        user.Id = Id;
        return user;
    }

    public override bool IsValid()
    {
        return Id >= 0 && base.IsValid();
    }
}