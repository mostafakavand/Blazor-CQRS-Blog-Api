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