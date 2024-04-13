using CQRSPattern.CrossCutting.Interfaces.DataLayer;
using CQRSPattern.CrossCutting.Options;
using CQRSPattern.DatabaseSettings.DatabaseContexts;
using CQRSPattern.DataStore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CQRSPattern.API.DependencyInjection;

internal static class DataDependencyInjection
{
    internal static void AddDataDependencyInjection(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>((serviceProvider, options) =>
        {
            var connectionString = serviceProvider.GetRequiredService<IOptions<ConnectionStringsOptions>>().Value.ConnectionString;

            options.UseSqlServer(connectionString);
        });

        services.AddRepositoriesDependencyInjection();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
