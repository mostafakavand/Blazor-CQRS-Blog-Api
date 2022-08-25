using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Blog.Commands.Blog.Comments.PostComment;
public class DeletePostCommentCommand : IRequestInfo, IRequest<OperationResult>
{
    public DeletePostCommentCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public int Id { get; set; }

    public RequestInfo RequestInfo { get; set; }
}
