using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Blog.Commands;

#region PostComment

public record CreatePostCommentCommand : IRequestInfo, IRequest<OperationResult>
{
    public CreatePostCommentCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public string CommentText { get; set; }
    public bool IsReply { get; set; }
    public int PostId { get; set; }
    public int CommentOwnerId { get; set; }
    public int? ReplyToCommentId { get; set; }

    public RequestInfo RequestInfo { get; set; }
}

public record DeletePostCommentCommand : IRequestInfo, IRequest<OperationResult>
{
    public DeletePostCommentCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public int Id { get; set; }

    public RequestInfo RequestInfo { get; set; }
}

public record UpdatePostCommentCommand : IRequestInfo, IRequest<OperationResult>
{
    public UpdatePostCommentCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int Id { get; set; }
    public string CommentText { get; set; }
    public bool IsReply { get; set; }
    public int PostId { get; set; }
    public int CommentOwnerId { get; set; }
    public int? ReplyToCommentId { get; set; }

    public RequestInfo RequestInfo { get; set; }
}

#endregion

#region PostIssueComments

public record CreatePostIssueCommentCommand : IRequestInfo, IRequest<OperationResult>
{
    public CreatePostIssueCommentCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public RequestInfo RequestInfo { get; set; }
    public string CommentText { get; set; }
    public bool IsReply { get; set; }
    public int PostIssueId { get; set; }
    public int CommentOwnerId { get; set; }
    public int? ReplyToCommentId { get; set; }
}

public record DeletePostIssueCommentCommand : IRequestInfo, IRequest<OperationResult>
{
    public DeletePostIssueCommentCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public RequestInfo RequestInfo { get; set; }
    public int Id { get; set; }
}

public record UpdatePostIssueCommentCommand : IRequestInfo, IRequest<OperationResult>
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

#endregion

#region PostCategoryIssueComments

public record CreatePostCategoryIssueCommentCommand : IRequestInfo, IRequest<OperationResult>
{
    public CreatePostCategoryIssueCommentCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public RequestInfo RequestInfo { get; set; }

    public string CommentText { get; set; }
    public bool IsReply { get; set; }
    public int PostCategoryIssueId { get; set; }
    public int CommentOwnerId { get; set; }
    public int? ReplyToCommentId { get; set; }
}

public record DeletePostCategoryIssueCommentCommand : IRequestInfo, IRequest<OperationResult>
{
    public DeletePostCategoryIssueCommentCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public RequestInfo RequestInfo { get; set; }
    public int Id { get; set; }
}

public record UpdatePostCategoryIssueCommentCommand : IRequestInfo, IRequest<OperationResult>
{
    public UpdatePostCategoryIssueCommentCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public RequestInfo RequestInfo { get; set; }
    public int Id { get; set; }
    public string CommentText { get; set; }
    public bool IsReply { get; set; }
    public int PostCategoryIssueId { get; set; }
    public int CommentOwnerId { get; set; }
    public int? ReplyToCommentId { get; set; }
}


#endregion

