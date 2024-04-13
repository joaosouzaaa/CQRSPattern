using CQRSPattern.Application.Books.Commands;
using CQRSPattern.Domain.Entities;
using FluentValidation;

namespace CQRSPattern.API.DependencyInjection;

internal static class ValidatorsDependencyInjection
{
    internal static void AddValidatorsDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IValidator<Book>, BookValidator>();
    }
}
