using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Blog.Commands.Blog.Comments.PostCategoryIssueComments;
public class CreatePostCategoryIssueCommentsCommands : IRequestInfo, IRequest<OperationResult>
{
    public CreatePostCategoryIssueCommentsCommands(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public RequestInfo RequestInfo { get; set; }

    public string CommentText { get; set; }
    public bool IsReply { get; set; }
    public int PostCategoryIssueId { get; set; }
    public int CommentOwnerId { get; set; }
    public int? ReplyToCommentId { get; set; }
}
