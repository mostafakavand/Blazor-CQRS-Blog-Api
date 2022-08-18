using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;
using Dayana.Shared.Persistence.Models.Filters.Blog.PostCategoryFilters;

namespace Dayana.Shared.Persistence.Models.Queries.Blog.WeblogPostCategoryQueries;

public class GetWeblogPostCategoryByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetWeblogPostCategoryByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public PostCategoryFilter Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}