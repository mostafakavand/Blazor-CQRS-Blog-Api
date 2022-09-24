using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Infrastructure.Pagination;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Blog.Queries.BlogPosts.PostCategoryQueries;

public class GetWeblogPostCategoryByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetWeblogPostCategoryByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public DefaultPaginationFilter Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}