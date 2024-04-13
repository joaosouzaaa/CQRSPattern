﻿using CQRSPattern.CrossCutting.Interfaces.Repositories;
using CQRSPattern.DataStore.Repositories;

namespace CQRSPattern.API.DependencyInjection;

internal static class RepositoriesDependencyInjection
{
    internal static void AddRepositoriesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
    }
}
