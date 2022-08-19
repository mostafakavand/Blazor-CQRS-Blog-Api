using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Queries.Blog.PostCategoryQueries;

public class GetPostCategoryByIdQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostCategoryByIdQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int Id { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}