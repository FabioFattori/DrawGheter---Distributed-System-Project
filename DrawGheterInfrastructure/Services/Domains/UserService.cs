using DrawGheterInfrastructure.Controllers.Dto.UserDomain;
using DrawGheterInfrastructure.Models;
using DrawGheterInfrastructure.Repositories.Intefaces;
using DrawGheterInfrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DrawGheterInfrastructure.Services.Domains;

public class UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
    : BaseService<User, CreateUserDto, UpdateUserDto>(userRepository), IUserService
{
    public async Task<bool> Register(CreateUserDto user)
    {
        return await userRepository.Register(user.ToModel());
    }

    public async Task<bool> Login(UpdateUserDto user)
    {
        return await userRepository.Login(user.ToModel());
    }
}