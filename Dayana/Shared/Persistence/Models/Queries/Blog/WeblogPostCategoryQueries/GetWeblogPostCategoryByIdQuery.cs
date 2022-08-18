using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Queries.Blog.WeblogPostCategoryQueries;

public class GetWeblogPostCategoryByIdQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetWeblogPostCategoryByIdQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int Id { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}