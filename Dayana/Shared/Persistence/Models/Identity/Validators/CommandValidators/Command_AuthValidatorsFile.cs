﻿using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using Dayana.Shared.Persistence.Models.Identity.Requests;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.CommandValidators;


public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .When(x => string.IsNullOrEmpty(x.Email))
            .WithState(_ => GenericErrors<LoginCommand>.InvalidVariableError("user name"));

        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => string.IsNullOrEmpty(x.UserName))
            .WithState(_ => GenericErrors<LoginCommand>.InvalidVariableError("email address"));

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithState(_ => GenericErrors<LoginCommand>.InvalidVariableError("password"));
    }
}


