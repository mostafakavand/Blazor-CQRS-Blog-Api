using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Queries.Blog.WeblogPostQueries;

public class GetWeblogPostByIdQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetWeblogPostByIdQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int WeblogPostId { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}