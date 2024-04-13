using CQRSPattern.CrossCutting.Interfaces.DataLayer.Repositories.Books;
using CQRSPattern.DataAccessLayer.Repositories;
using CQRSPattern.DataStore.Repositories;

namespace CQRSPattern.API.DependencyInjection;

internal static class RepositoriesDependencyInjection
{
    internal static void AddRepositoriesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IBookCommandRepository, BookCommandRepository>();
        services.AddScoped<IBookQueryRepository, BookQueryRepository>();
    }
}
