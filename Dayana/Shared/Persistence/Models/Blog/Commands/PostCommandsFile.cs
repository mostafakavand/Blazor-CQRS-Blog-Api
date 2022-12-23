using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Blog.Commands;

public record CreatePostCommand : IRequestInfo, IRequest<OperationResult>
{
    public CreatePostCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public string Title { get; set; }
    public string Subject { get; set; }
    public string Summery { get; set; }
    public string TextContent { get; set; }
    public int PostCategoryId { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}

public record DeletePostCommand : IRequestInfo, IRequest<OperationResult>
{
    public RequestInfo RequestInfo { get; set; }

    public DeletePostCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public int Id { get; set; }
}

public record UpdatePostCommand : IRequestInfo, IRequest<OperationResult>
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
    public string Subject { get; set; }
    public int PostCategoryId { get; set; }
}
public record CreatePostCategoryCommand : IRequestInfo, IRequest<OperationResult>
{
    public CreatePostCategoryCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public string CategoryTitle { get; set; }
    public string CategorySubject { get; set; }
    public string CategoryIcon { get; set; }

    public RequestInfo RequestInfo { get; set; }
}

public record DeletePostCategoryCommand : IRequestInfo, IRequest<OperationResult>
{
    public DeletePostCategoryCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public int Id { get; set; }
    public RequestInfo RequestInfo { get; set; }
}

public record UpdatePostCategoryCommand : IRequestInfo, IRequest<OperationResult>
{
    public UpdatePostCategoryCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public int Id { get; set; }
    public string CategoryTitle { get; set; }
    public string CategorySubject { get; set; }
    public string CategoryIcon { get; set; }

    public RequestInfo RequestInfo { get; set; }
}