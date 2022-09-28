using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Infrastructure.Pagination;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Blog.Queries;
public record GetPostByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public DefaultPaginationFilter Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}

public record GetPostByIdQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostByIdQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int PostId { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}

public record GetPostCategoryByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostCategoryByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public DefaultPaginationFilter Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}

public record GetPostCategoryByIdQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostCategoryByIdQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int Id { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}