using CQRSPattern.CrossCutting.Settings.NotificationSettings;

namespace CQRSPattern.CrossCutting.Interfaces.Settings;

public interface INotificationHandler
{
    List<Notification> GetNotifications();
    bool HasNotifications();
    void AddNotification(string key, string message);
}
