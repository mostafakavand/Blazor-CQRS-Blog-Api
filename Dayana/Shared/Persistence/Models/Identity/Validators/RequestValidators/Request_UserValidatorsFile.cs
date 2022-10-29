using Dayana.Shared.Domains.Identity.Roles;
using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Identity.Requests;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.RequestValidators;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.Username)
              .NotEmpty()
              .WithState(_ => GenericErrors<User>.InvalidVariableError("user name"));

        RuleFor(x => x.FirstName)
         .NotEmpty()
         .WithState(_ => GenericErrors<User>.InvalidVariableError("first name"));


        RuleFor(x => x.LastName)
         .NotEmpty()
         .WithState(_ => GenericErrors<User>.InvalidVariableError("last name"));


        RuleFor(x => x.FullName)
         .NotEmpty()
         .WithState(_ => GenericErrors<User>.InvalidVariableError("full name"));


        RuleFor(x => x.Email)
         .NotEmpty()
         .When(x => string.IsNullOrEmpty(x.Mobile))
         .WithState(_ => GenericErrors<User>.CustomError(variableName: "email", causeOfError: "fill at least one of email and mobile fields"));


        RuleFor(x => x.Mobile)
         .NotEmpty()
         .When(x => string.IsNullOrEmpty(x.Email))
         .WithState(_ => GenericErrors<User>.CustomError(variableName: "email", causeOfError: "fill at least one of email and mobile fields"));


        RuleFor(x => x.Password)
         .NotEmpty()
         .WithState(_ => GenericErrors<User>.InvalidVariableError("password"));
    }
}

public class GetUserByFilterRequestValidator : AbstractValidator<GetUserByFilterRequest>
{
    public GetUserByFilterRequestValidator()
    {
        RuleFor(x => x.keyword)
           .NotEmpty()
           .When(x => string.IsNullOrEmpty(x.Email))
           .WithState(_ => GenericErrors<User>.InvalidVariableError("search keword"));

        RuleFor(x => x.Email)
          .NotEmpty()
          .When(x => string.IsNullOrEmpty(x.keyword))
          .WithState(_ => GenericErrors<User>.InvalidVariableError("email"));
    }
}

public class UpdateUserPasswordRequestValidator : AbstractValidator<UpdateUserPasswordRequest>
{
    public UpdateUserPasswordRequestValidator()
    {
        RuleFor(x => x.NewPassword)
           .NotEmpty()
           .WithState(_ => GenericErrors<User>.InvalidVariableError("new password"));

        RuleFor(x => x.LastPassword)
          .NotEmpty()
          .WithState(_ => GenericErrors<User>.InvalidVariableError("last password"));
    }
}

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithState(_ => GenericErrors<User>.InvalidVariableError("user name"));

        RuleFor(x => x.Password)
         .NotEmpty()
         .WithState(_ => GenericErrors<User>.InvalidVariableError("password"));

        RuleFor(x => x.Mobile)
        .NotEmpty()
        .When(x => string.IsNullOrEmpty(x.Email))
        .WithState(_ => GenericErrors<User>.InvalidVariableError("mobile"));

        RuleFor(x => x.Email)
         .NotEmpty()
         .When(x => string.IsNullOrEmpty(x.Mobile))
         .WithState(_ => GenericErrors<User>.InvalidVariableError("email"));
    }
}


public class UpdateUserRolesRequestValidator : AbstractValidator<UpdateUserRolesRequest>
{
    public UpdateUserRolesRequestValidator()
    {
        RuleFor(x => x.RoleEids)
            .NotEmpty()
            .NotNull()
            .WithState(_ => GenericErrors<Role>.InvalidVariableError("user id"));
    }
}