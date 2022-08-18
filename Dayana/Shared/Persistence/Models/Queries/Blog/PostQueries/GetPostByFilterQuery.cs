using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;
using Dayana.Shared.Persistence.Models.Filters.Blog.PostFilters;

namespace Dayana.Shared.Persistence.Models.Queries.Blog.PostQueries;

public class GetPostByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public WeblogPostFilter Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}