using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;
using Dayana.Shared.Persistence.Models.Blog.Filters.BlogPosts.PostFilters;

namespace Dayana.Shared.Persistence.Models.Blog.Queries.BlogPosts.PostQueries;

public class GetPostByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public PostFilter Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}