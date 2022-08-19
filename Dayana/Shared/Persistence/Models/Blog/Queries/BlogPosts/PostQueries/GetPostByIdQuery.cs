using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Blog.Queries.BlogPosts.PostQueries;

public class GetPostByIdQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPostByIdQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int WeblogPostId { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}