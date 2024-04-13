using CQRSPattern.CrossCutting.Interfaces.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CQRSPattern.API.Filters;

public sealed class NotificationFilter(INotificationHandler notificationHandler) : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (notificationHandler.HasNotifications())
        {
            context.Result = new BadRequestObjectResult(notificationHandler.GetNotifications());
        }

        base.OnActionExecuted(context);
    }
}
