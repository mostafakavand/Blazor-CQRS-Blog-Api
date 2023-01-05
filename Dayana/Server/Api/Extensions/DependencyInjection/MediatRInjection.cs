using Dayana.Server.Application.Behaviors.Blog;
using Dayana.Server.Application.Behaviors.Identity;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.Models.Blog.Commands;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using MediatR;
using System.Reflection;

namespace Dayana.Server.Api.Extensions.DependencyInjection;

public static class MediatRInjection
{
    public static IServiceCollection AddConfiguredMediatR(this IServiceCollection services)
    {
        // Handlers
        services.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly);

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

        #region identity

        #region Users

        services.AddTransient(typeof(IPipelineBehavior<CreateUserCommand, OperationResult>),
           typeof(CreateUserValidationBehavior<CreateUserCommand, OperationResult>));
        services.AddTransient(typeof(IPipelineBehavior<UpdateUserCommand, OperationResult>),
            typeof(UpdateUserValidationBehavior<UpdateUserCommand, OperationResult>));
        services.AddTransient(typeof(IPipelineBehavior<DeleteUserCommand, OperationResult>),
            typeof(DeleteUserValidationBehavior<DeleteUserCommand, OperationResult>));

        #endregion

        #region User Role

        services.AddTransient(typeof(IPipelineBehavior<UpdateUserRolesCommand, OperationResult>),
           typeof(UpdateUserRolesValidationBehavior<UpdateUserRolesCommand, OperationResult>));
        services.AddTransient(typeof(IPipelineBehavior<CreateUserPermissionCommand, OperationResult>),
            typeof(CreateUserPermissionValidationBehavior<CreateUserPermissionCommand, OperationResult>));
        services.AddTransient(typeof(IPipelineBehavior<DeleteUserPermissionCommand, OperationResult>),
            typeof(DeleteUserPermissionValidationBehavior<DeleteUserPermissionCommand, OperationResult>));

        #endregion

        #region Role

        services.AddTransient(typeof(IPipelineBehavior<CreateRoleCommand, OperationResult>),
           typeof(CreateRoleValidationBehavior<CreateRoleCommand, OperationResult>));
        services.AddTransient(typeof(IPipelineBehavior<UpdateRoleCommand, OperationResult>),
           typeof(UpdateRoleValidationBehavior<UpdateRoleCommand, OperationResult>));
        services.AddTransient(typeof(IPipelineBehavior<DeleteRoleCommand, OperationResult>),
            typeof(DeleteRoleValidationBehavior<DeleteRoleCommand, OperationResult>));


        #endregion

        #endregion

        return services;
    }
}