using Dayana.Server.Application.Behaviors.Blog;
using Dayana.Server.Application.Behaviors.Identity;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.Models.Blog.Commands;
using MediatR;

namespace Dayana.Server.Api.Extensions.DependencyInjection;

public static class MediatRInjection
{
    public static IServiceCollection AddConfiguredMediatR(this IServiceCollection services)
    {
        // Generic behaviors
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommitBehavior<,>));

        #region blog

        #region blog post

        services.AddTransient(typeof(IPipelineBehavior<CreatePostCommand, OperationResult>),
            typeof(CreatePostValidationBehavior<CreatePostCommand, OperationResult>));
        services.AddTransient(typeof(IPipelineBehavior<UpdatePostCommand, OperationResult>),
            typeof(UpdatePostValidationBehavior<UpdatePostCommand, OperationResult>));
        services.AddTransient(typeof(IPipelineBehavior<DeletePostCommand, OperationResult>),
            typeof(DeletePostValidationBehavior<DeletePostCommand, OperationResult>));

        #endregion

        #region blog post category

        services.AddTransient(typeof(IPipelineBehavior<CreatePostCategoryCommand, OperationResult>),
            typeof(CreatePostCategoryValidationBehavior<CreatePostCategoryCommand, OperationResult>));
        services.AddTransient(typeof(IPipelineBehavior<UpdatePostCategoryCommand, OperationResult>),
            typeof(UpdatePostCategoryValidationBehavior<UpdatePostCategoryCommand, OperationResult>));
        services.AddTransient(typeof(IPipelineBehavior<DeletePostCategoryCommand, OperationResult>),
            typeof(DeletePostCategoryValidationBehavior<DeletePostCategoryCommand, OperationResult>));

        #endregion

        #endregion

        return services;
    }
}