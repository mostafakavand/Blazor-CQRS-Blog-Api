using Dayana.Shared.Persistence.Models.Blog.Base.Issues;
using Dayana.Shared.Persistence.Models.Identity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Blog.Base;
public class PostCategoryCommentModel : BaseModel
{
    public string CommentText { get; set; }
    public bool IsReply { get; set; }

    #region Navigations

    public int PostCategoryId { get; set; }
    public PostCategoryModel PostCategory { get; set; }

    public int CommentOwnerId { get; set; }
    public UserModel CommentOwner { get; set; }

    public int? ReplyToCommentId { get; set; }
    #endregion
}


public class PostCategoryIssueCommentModel : BaseModel
{
    public string CommentText { get; set; }
    public bool IsReply { get; set; }

    #region Navigations

    public int PostCategoryIssueId { get; set; }
    public PostCategoryIssueModel PostCategoryIssue { get; set; }

    public int CommentOwnerId { get; set; }
    public UserModel CommentOwner { get; set; }

    public int? ReplyToCommentId { get; set; }
    #endregion
}

public class PostCommentModel : BaseModel
{
    public string CommentText { get; set; }
    public bool IsReply { get; set; }

    #region Navigations

    public int PostId { get; set; }
    public PostModel Post { get; set; }

    public int CommentOwnerId { get; set; }
    public UserModel CommentOwner { get; set; }

    public int? ReplyToCommentId { get; set; }
    #endregion
}

public class PostIssueCommentModel : BaseModel
{
    public string CommentText { get; set; }
    public bool IsReply { get; set; }

    #region Navigations

    public int PostIssueId { get; set; }
    public PostIssueModel PostIssue { get; set; }

    public int CommentOwnerId { get; set; }
    public UserModel CommentOwner { get; set; }

    public int? ReplyToCommentId { get; set; }

    #endregion
}
