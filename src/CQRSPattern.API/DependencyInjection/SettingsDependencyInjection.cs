using CQRSPattern.API.Filters;
using CQRSPattern.CrossCutting.Interfaces.Settings;
using CQRSPattern.CrossCutting.Settings.NotificationSettings;

namespace CQRSPattern.API.DependencyInjection;

internal static class SettingsDependencyInjection
{
    internal static void AddSettingsDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<INotificationHandler, NotificationHandler>();

        services.AddScoped<NotificationFilter>();

        services.AddMvc(options => options.Filters.AddService<NotificationFilter>());
    }
}
