using DrawGheterInfrastructure.Controllers.Dto;
using DrawGheterInfrastructure.Models;
using DrawGheterInfrastructure.Repositories;
using DrawGheterInfrastructure.Services.Interfaces;

namespace DrawGheterInfrastructure.Services;

public class UserService(UserRepository userRepository)
    : BaseService<User, CreateUserDto, UpdateUserDto>(userRepository), IUserService
{
}