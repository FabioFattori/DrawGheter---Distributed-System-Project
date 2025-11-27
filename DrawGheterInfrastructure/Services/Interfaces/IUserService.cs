using DrawGheterInfrastructure.Controllers.Dto;
using DrawGheterInfrastructure.Models;

namespace DrawGheterInfrastructure.Services.Interfaces;

public interface IUserService : IBaseService<User, CreateUserDto, UpdateUserDto>
{
    
}