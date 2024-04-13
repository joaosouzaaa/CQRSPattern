using CQRSPattern.Application.Books.Commands.CreateBook;

namespace CQRSPattern.API.DependencyInjection;

internal static class MappersDependencyInjection
{
    internal static void AddMappersDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<ICreateBookMapper, CreateBookMapper>();
    }
}
