using CQRSPattern.DatabaseSettings.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace CQRSPattern.API.DependencyInjection;

internal static class MigrationHandler
{
    internal static void MigrateDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        using var dbContext = scope.ServiceProvider.GetService<AppDbContext>();

        try
        {
            dbContext!.Database.Migrate();
        }
        catch
        {
            throw;
        }
    }
}
