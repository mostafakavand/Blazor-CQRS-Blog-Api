using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.Models.Identity.Commands.Roles;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Blog.Commands.Blog.Comments.PostIssueComments;
public class UpdatePostIssueCommentCommand : IRequestInfo, IRequest<OperationResult>
{
    public UpdatePostIssueCommentCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public RequestInfo RequestInfo { get; set; }
    public int Id { get; set; }
    public string CommentText { get; set; }
    public bool IsReply { get; set; }
    public int PostIssueId { get; set; }
    public int CommentOwnerId { get; set; }
    public int? ReplyToCommentId { get; set; }
}


public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(x => x.PermissionIds)
            .NotEmpty()
            .WithState(_ => PermissionErrors.InvalidPermissionIdValidationError);

        RuleFor(x => x.Title)
            .MaximumLength(Defaults.NameLength)
            .WithState(_ => CommonErrors.InvalidTitleValidationError);

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithState(_ => CommonErrors.InvalidTitleValidationError);
    }
}