using CQRSPattern.CrossCutting.Interfaces.DataLayer;
using CQRSPattern.CrossCutting.Interfaces.Settings;
using FluentValidation;
using FluentValidation.Results;

namespace CQRSPattern.Application.BaseHandlers;

public abstract class BaseCommandHandler<TDomain>
{
    protected readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<TDomain> _validator;
    protected readonly INotificationHandler _notificationHandler;

    protected BaseCommandHandler(
        IUnitOfWork unitOfWork,
        IValidator<TDomain> validator,
        INotificationHandler notificationHandler)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
        _notificationHandler = notificationHandler;
    }

    protected async Task<bool> ValidateAsync(TDomain domain)
    {
        var validationResult = await _validator.ValidateAsync(domain);

        if (validationResult.IsValid)
        {
            return true;
        }

        foreach (ValidationFailure error in validationResult.Errors)
        {
            _notificationHandler.AddNotification(error.PropertyName, error.ErrorMessage);
        }

        return false;
    }
}
