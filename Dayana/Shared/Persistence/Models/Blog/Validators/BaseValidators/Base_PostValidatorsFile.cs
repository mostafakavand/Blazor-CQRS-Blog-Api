using Dayana.Shared.Infrastructure.Errors.Blog;
using Dayana.Shared.Persistence.Models.Blog.Base;
using Dayana.Shared.Persistence.Models.Identity.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Blog.Validators.BaseValidators;
//public class PostModelValidator : AbstractValidator<PostModel>
//{
//    public PostModelValidator()
//    {
//        RuleFor(x => x.PostTitle)
//            .NotNull()
//            .NotEmpty()
//            .WithState(_ => PostErrors.ti);

//        RuleFor(x => x.FullName)
//            .EmailAddress()
//            .WithState(_ => UserErrors.InvalidFullNameValidationError);

//        RuleFor(x => x.AccessToken)
//            .NotEmpty()
//            .WithState(_ => UserErrors.InvalidAccessTokenValidationError);
//    }
//}


//public class TokenResultValidator : AbstractValidator<TokenResult>
//{
//    public TokenResultValidator()
//    {
//        RuleFor(x => x.AccessToken)
//            .NotEmpty()
//            .WithState(_ => UserErrors.InvalidAccessTokenValidationError);
//    }
//}