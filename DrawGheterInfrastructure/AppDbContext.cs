using DrawGheterInfrastructure.Models;
using DrawGheterInfrastructure.Repositories;
using DrawGheterInfrastructure.Services;
using DrawGheterInfrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DrawGheterInfrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    public static void AddRepositories(IServiceCollection services)
    {
        services
            .AddScoped<UserRepository>();
    }

    public static void AddServices(IServiceCollection services)
    {
        services
            .AddScoped<IUserService, UserService>()
            .AddScoped<RedisSessionService>()
            .AddScoped<SnapshotService>();
    }
}