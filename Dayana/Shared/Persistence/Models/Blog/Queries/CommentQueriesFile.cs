using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Infrastructure.Pagination;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Blog.Queries;

#region post comment
public record GetPostCommentByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostCommentFilterQuery(RequestInfo requestInfo)
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

#region post category comment

public record GetPostCategoryCommentByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostCategoryCommentByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public DefaultPaginationFilter Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}

public record GetPostCategoryCommentByIdQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostCategoryCommentByIdQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int Id { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}
#endregion