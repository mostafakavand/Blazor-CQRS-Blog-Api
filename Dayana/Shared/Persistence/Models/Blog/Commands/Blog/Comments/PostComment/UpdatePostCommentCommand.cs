using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Blog.Commands.Blog.Comments.PostComment;
public class UpdatePostCommentCommand : IRequestInfo, IRequest<OperationResult>
{
    public UpdatePostCommentCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int Id { get; set; }
    public string CommentText { get; set; }
    public bool IsReply { get; set; }
    public int PostId { get; set; }
    public int CommentOwnerId { get; set; }
    public int? ReplyToCommentId { get; set; }

    public RequestInfo RequestInfo { get; set; }
}
