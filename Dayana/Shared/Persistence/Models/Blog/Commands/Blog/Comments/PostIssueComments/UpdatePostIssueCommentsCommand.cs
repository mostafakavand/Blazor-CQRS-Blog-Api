using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Blog.Commands.Blog.Comments.PostIssueComments;
public class UpdatePostIssueCommentsCommand : IRequestInfo, IRequest<OperationResult>
{
    public UpdatePostIssueCommentsCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public RequestInfo RequestInfo { get; set; }
    public string CommentText { get; set; }
    public bool IsReply { get; set; }
    public int PostIssueId { get; set; }
    public int CommentOwnerId { get; set; }
    public int? ReplyToCommentId { get; set; }
}
