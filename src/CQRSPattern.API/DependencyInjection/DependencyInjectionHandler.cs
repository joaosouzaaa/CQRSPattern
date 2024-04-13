using CQRSPattern.DatabaseSettings.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace CQRSPattern.API.DependencyInjection;

internal static class DependencyInjectionHandler
{
    internal static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration["ConnectionStrings:DefaultConnection"]!;

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        services.AddRepositoriesDependencyInjection();
    }
}
