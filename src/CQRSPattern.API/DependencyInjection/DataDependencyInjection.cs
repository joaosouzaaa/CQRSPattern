using CQRSPattern.CrossCutting.Interfaces.DataStore;
using CQRSPattern.DatabaseSettings.DatabaseContexts;
using CQRSPattern.DataStore;
using Microsoft.EntityFrameworkCore;

namespace CQRSPattern.API.DependencyInjection;

internal static class DataDependencyInjection
{
    internal static void AddDataDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration["ConnectionStrings:DefaultConnection"]!;

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        services.AddRepositoriesDependencyInjection();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
