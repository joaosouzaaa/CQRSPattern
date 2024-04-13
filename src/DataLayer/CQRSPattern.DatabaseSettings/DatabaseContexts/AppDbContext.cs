using Microsoft.EntityFrameworkCore;

namespace CQRSPattern.DatabaseSettings.DatabaseContexts;
public sealed class AppDbContext(DbContextOptions<DbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
}
