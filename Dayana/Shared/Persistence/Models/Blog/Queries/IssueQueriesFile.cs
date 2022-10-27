using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Infrastructure.Pagination;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Blog.Queries;

#region post issue comment
public record GetPostIssueCommentFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostIssueCommentFilterQuery(RequestInfo requestInfo)
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
public record GetPostCategoryIssueCommentFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostCategoryIssueCommentFilterQuery(RequestInfo requestInfo)
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

#region post issue
public record GetPostIssueByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostIssueByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public DefaultPaginationFilter Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}

public record GetPostIssueByIdQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostIssueByIdQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int PostIssueId { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}
#endregion

#region post category issue


public record GetPostCategoryIssueByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostCategoryIssueByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public DefaultPaginationFilter Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}

public record GetPostCategoryIssueByIdQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostCategoryIssueByIdQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int Id { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}

#endregion