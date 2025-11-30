using DrawGheterInfrastructure.Models;
using DrawGheterInfrastructure.Repositories;
using DrawGheterInfrastructure.Repositories.Intefaces;
using DrawGheterInfrastructure.Services;
using DrawGheterInfrastructure.Services.Domains;
using DrawGheterInfrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DrawGheterInfrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Game> Games { get; set; }

    public static void AddRepositories(IServiceCollection services)
    {
        services
            .AddScoped<IGameRepository, GameRepository>()
            .AddScoped<IUserRepository, UserRepository>();
    }

    public static void AddServices(IServiceCollection services)
    {
        services
            .AddScoped<IGameService, GameService>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<RedisSessionService>()
            .AddScoped<SnapshotService>();
    }
}