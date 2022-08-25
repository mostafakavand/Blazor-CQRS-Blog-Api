using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Blog.Commands.Blog.PostCommands;

public class CreatePostCommand : IRequestInfo, IRequest<OperationResult>
{
    public CreatePostCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public string Title { get; set; }
    public string Summery { get; set; }
    public string TextContent { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}