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

public class GetPostByIdQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostByIdQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int WeblogPostId { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}

public class GetWeblogPostCategoryByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetWeblogPostCategoryByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public DefaultPaginationFilter Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}

public class GetPostCategoryByIdQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostCategoryByIdQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int Id { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}