using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Blog.Commands.Blog.Comments.PostComment;
public class CreatePostCommentCommand : IRequestInfo, IRequest<OperationResult>
{
    public CreatePostCommentCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public string CommentText { get; set; }
    public bool IsReply { get; set; }
    public int PostId { get; set; }
    public int CommentOwnerId { get; set; }
    public int? ReplyToCommentId { get; set; }

    public RequestInfo RequestInfo { get; set; }

}
