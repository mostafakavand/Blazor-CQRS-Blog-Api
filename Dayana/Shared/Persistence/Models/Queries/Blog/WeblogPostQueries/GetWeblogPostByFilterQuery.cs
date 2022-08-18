using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;
using Dayana.Shared.Persistence.Models.Filters.Blog.PostFilters;

namespace Dayana.Shared.Persistence.Models.Queries.Blog.WeblogPostQueries;

public class GetWeblogPostByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetWeblogPostByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public WeblogPostFilter Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}