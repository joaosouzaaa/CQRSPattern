using CQRSPattern.Application.Books.Commands.CreateBook;
using CQRSPattern.Application.Books.Commands.UpdateBook;
using CQRSPattern.Application.Books.Queries.GetAllBooks;
using CQRSPattern.Application.Books.Queries.GetBookById;

namespace CQRSPattern.API.DependencyInjection;

internal static class MappersDependencyInjection
{
    internal static void AddMappersDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<ICreateBookMapper, CreateBookMapper>();
        services.AddScoped<IGetAllBooksMapper, GetAllBooksMapper>();
        services.AddScoped<IGetBookByIdMapper, GetBookByIdMapper>();
        services.AddScoped<IUpdateBookMapper, UpdateBookMapper>();
    }
}
