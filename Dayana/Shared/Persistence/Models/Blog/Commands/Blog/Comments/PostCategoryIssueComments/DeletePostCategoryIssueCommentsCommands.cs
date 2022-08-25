using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Blog.Commands.Blog.Comments.PostCategoryIssueComments;
public class DeletePostCategoryIssueCommentsCommands : IRequestInfo, IRequest<OperationResult>
{
    public DeletePostCategoryIssueCommentsCommands(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public RequestInfo RequestInfo { get; set; }
    public int Id { get; set; }
}
