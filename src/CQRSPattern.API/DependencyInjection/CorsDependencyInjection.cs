using CQRSPattern.CrossCutting.Constants;

namespace CQRSPattern.API.DependencyInjection;

internal static class CorsDependencyInjection
{
    internal static void AddCorsDependencyInjection(this IServiceCollection services)
    {
        services.AddCors(p => p.AddPolicy(CorsNamesConstants.CorsPolicy, builder =>
        {
            builder.AllowAnyMethod()
                   .AllowAnyHeader()
                   .SetIsOriginAllowed(origin => true)
                   .AllowCredentials();
        }));
    }
}
