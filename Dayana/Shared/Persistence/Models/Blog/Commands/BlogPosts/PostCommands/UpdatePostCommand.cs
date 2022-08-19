using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Blog.Commands.BlogPosts.PostCommands;

public class UpdatePostCommand : IRequestInfo, IRequest<OperationResult>
{
    public RequestInfo RequestInfo { get; set; }

    public UpdatePostCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Summery { get; set; }
    public string TextContent { get; set; }
}