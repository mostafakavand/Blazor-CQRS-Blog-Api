using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Infrastructure.Pagination;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Blog.Queries;

#region post comment
public record GetPostCommentByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostCommentByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public DefaultPaginationFilter Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}

public record GetPostCommentByIdQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostCommentByIdQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int PostCommentId { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}


#endregion

#region post issue comment
public record GetPostIssueCommentByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostIssueCommentByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public DefaultPaginationFilter Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}

public record GetPostIssueCommentByIdQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostIssueCommentByIdQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int PostIssueId { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}
#endregion

#region post category issue comment
public record GetPostCategoryIssueCommentByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostCategoryIssueCommentByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public DefaultPaginationFilter Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}

public record GetPostCategoryIssueCommentByIdQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostCategoryIssueCommentByIdQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int PostCategoryIssueId { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}
#endregion