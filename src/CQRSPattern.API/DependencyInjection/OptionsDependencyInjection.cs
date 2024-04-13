using CQRSPattern.CrossCutting.Constants;
using CQRSPattern.CrossCutting.Options;

namespace CQRSPattern.API.DependencyInjection;

internal static class OptionsDependencyInjection
{
    internal static void AddOptionsDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ConnectionStringsOptions>(configuration.GetSection(OptionsConstants.ConnectionStringsSection));
    }
}
