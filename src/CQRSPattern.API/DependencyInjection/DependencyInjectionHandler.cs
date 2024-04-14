namespace CQRSPattern.API.DependencyInjection;

internal static class DependencyInjectionHandler
{
    internal static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCorsDependencyInjection();

        services.AddMediatR(options => options.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly));

        services.AddSettingsDependencyInjection();
        services.AddDataDependencyInjection();
        services.AddOptionsDependencyInjection(configuration);
        services.AddMappersDependencyInjection();
        services.AddValidatorsDependencyInjection();
    }
}
