using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Blog.Commands;


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

#region Post Issue


public record CreatePostIssueCommand : IRequestInfo, IRequest<OperationResult>
{
    public CreatePostIssueCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public RequestInfo RequestInfo { get; set; }
    public string IssueTitle { get; set; }
    public string IssueDescription { get; set; }

    public int PostId { get; set; }
}

public record DeletePostIssueCommand : IRequestInfo, IRequest<OperationResult>
{
    public DeletePostIssueCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public RequestInfo RequestInfo { get; set; }
    public int Id { get; set; }
    public int PostId { get; set; }
}

public record UpdatePostIssueCommand : IRequestInfo, IRequest<OperationResult>
{
    public UpdatePostIssueCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public RequestInfo RequestInfo { get; set; }
    public string IssueTitle { get; set; }
    public string IssueDescription { get; set; }
    public int PostId { get; set; }
    public int PosIssueId { get; set; }

}


#endregion

#region Post Category Issue


public record CreatePostCategoryIssueCommand : IRequestInfo, IRequest<OperationResult>
{
    public CreatePostCategoryIssueCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public RequestInfo RequestInfo { get; set; }
    public string IssueTitle { get; set; }
    public string IssueDescription { get; set; }
    public int PostCategoryId { get; set; }
}

public record DeletePostCategoryIssueCommand : IRequestInfo, IRequest<OperationResult>
{
    public DeletePostCategoryIssueCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public RequestInfo RequestInfo { get; set; }
    public int Id { get; set; }
    public int PostCategoryId { get; set; }
}

public record UpdatePostCategoryIssueCommand : IRequestInfo, IRequest<OperationResult>
{
    public UpdatePostCategoryIssueCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public RequestInfo RequestInfo { get; set; }
    public string IssueTitle { get; set; }
    public string IssueDescription { get; set; }
    public int PostCategoryId { get; set; }
}


#endregion