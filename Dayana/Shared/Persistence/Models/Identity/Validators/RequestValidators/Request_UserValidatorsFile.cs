using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Persistence.Models.Identity.Requests;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.RequestValidators;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.Username)
              .NotEmpty()
              .WithState(_ => UserErrors.InvalidUsernameValidationError);

        RuleFor(x => x.FirstName)
         .NotEmpty()
         .WithState(_ => UserErrors.InvalidFirstNameValidationError);


        RuleFor(x => x.LastName)
         .NotEmpty()
         .WithState(_ => UserErrors.InvalidLastNameValidationError);


        RuleFor(x => x.FullName)
         .NotEmpty()
         .WithState(_ => UserErrors.InvalidFullNameValidationError);


        RuleFor(x => x.Email)
         .NotEmpty()
         .WithState(_ => UserErrors.InvalidEmailValidationError);


        RuleFor(x => x.Mobile)
         .NotEmpty()
         .WithState(_ => UserErrors.InvalidMobileValidationError);


        RuleFor(x => x.Password)
         .NotEmpty()
         .WithState(_ => UserErrors.InvalidPasswordValidationError);
    }
}

public class GetUserByFilterRequestValidator : AbstractValidator<GetUserByFilterRequest>
{
    public GetUserByFilterRequestValidator()
    {
        RuleFor(x => x.keyword)
           .NotEmpty()
           .When(x => string.IsNullOrEmpty(x.Email))
           .WithState(_ => CommonErrors.InvalidInputValidationError);

        RuleFor(x => x.Email)
          .NotEmpty()
          .When(x => string.IsNullOrEmpty(x.keyword))
          .WithState(_ => CommonErrors.InvalidInputValidationError);
    }
}

public class UpdateUserPasswordRequestValidator : AbstractValidator<UpdateUserPasswordRequest>
{
    public UpdateUserPasswordRequestValidator()
    {
        RuleFor(x => x.NewPassword)
           .NotEmpty()
           .WithState(_ => UserErrors.InvalidPasswordValidationError);

        RuleFor(x => x.LastPassword)
          .NotEmpty()
          .WithState(_ => UserErrors.InvalidPasswordValidationError);
    }
}

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithState(_ => UserErrors.InvalidUsernameValidationError);

        RuleFor(x => x.Password)
         .NotEmpty()
         .WithState(_ => UserErrors.InvalidPasswordValidationError);

        RuleFor(x => x.Mobile)
        .NotEmpty()
        .When(x => string.IsNullOrEmpty(x.Email))
        .WithState(_ => CommonErrors.InvalidInputValidationError);

        RuleFor(x => x.Email)
         .NotEmpty()
         .When(x => string.IsNullOrEmpty(x.Mobile))
         .WithState(_ => CommonErrors.InvalidInputValidationError);
    }
}


public class UpdateUserRolesRequestValidator : AbstractValidator<UpdateUserRolesRequest>
{
    public UpdateUserRolesRequestValidator()
    {
        RuleFor(x => x.RoleEids)
            .NotEmpty()
            .NotNull()
            .WithState(_ => RoleErrors.InvalidRoleTitleError);
    }
}