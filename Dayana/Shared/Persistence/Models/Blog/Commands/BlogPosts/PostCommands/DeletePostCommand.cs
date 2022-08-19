using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Blog.Commands.BlogPosts.PostCommands;

public class DeletePostCommand : IRequestInfo, IRequest<OperationResult>
{
    public RequestInfo RequestInfo { get; set; }

    public DeletePostCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public int Id { get; set; }
}