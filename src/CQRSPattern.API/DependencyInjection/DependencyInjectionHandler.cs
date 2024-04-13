namespace CQRSPattern.API.DependencyInjection;

internal static class DependencyInjectionHandler
{
    internal static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataDependencyInjection();
        services.AddOptionsDependencyInjection(configuration);
    }
}
