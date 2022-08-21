using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Infrastructure.Operations;
using FluentValidation;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Identity.Commands.Users;

public class CreateUserCommand : IRequestInfo, IRequest<OperationResult>
{
    public CreateUserCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public string Username { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserState State { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public RequestInfo RequestInfo { get; private set; }
}


public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithState(_ => UserErrors.InvalidUsernameValidationError);

        RuleFor(x => x.Username)
            .Length(2, Defaults.UsernameLength)
            .WithState(_ => UserErrors.InvalidUsernameValidationError);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(Defaults.MinPasswordLength)
            .WithState(_ => UserErrors.InvalidPasswordValidationError);

        RuleFor(x => x.Mobile)
            .MaximumLength(Defaults.MobileNumberLength)
            .WithState(_ => UserErrors.InvalidPhoneNumberValidationError);

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithState(_ => UserErrors.InvalidEmailValidationError);
    }
}