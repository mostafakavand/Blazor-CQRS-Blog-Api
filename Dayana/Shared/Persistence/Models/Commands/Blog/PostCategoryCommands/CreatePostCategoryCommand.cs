using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Commands.Blog.PostCategoryCommands;

public class CreatePostCategoryCommand : IRequestInfo, IRequest<OperationResult>
{
    public CreatePostCategoryCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public string CategoryTitle { get; set; }
    public string CategoryIcon { get; set; }

    public RequestInfo RequestInfo { get; set; }
}