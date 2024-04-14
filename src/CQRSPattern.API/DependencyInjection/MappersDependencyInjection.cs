using CQRSPattern.Application.Books.Commands.CreateBook;
using CQRSPattern.Application.Books.Commands.UpdateBook;

namespace CQRSPattern.API.DependencyInjection;

internal static class MappersDependencyInjection
{
    internal static void AddMappersDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<ICreateBookMapper, CreateBookMapper>();
        services.AddScoped<IUpdateBookMapper, UpdateBookMapper>();
    }
}
