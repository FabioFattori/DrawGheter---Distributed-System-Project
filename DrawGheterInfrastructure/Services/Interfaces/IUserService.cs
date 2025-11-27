using DrawGheterInfrastructure.Controllers.Dto.UserDomain;
using DrawGheterInfrastructure.Models;

namespace DrawGheterInfrastructure.Services.Interfaces;

public interface IUserService : IBaseService<User, CreateUserDto, UpdateUserDto>
{
    public Task<bool> Register(CreateUserDto user);
    public Task<bool> Login(UpdateUserDto user);
}