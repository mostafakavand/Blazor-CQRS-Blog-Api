using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Domains.Blog.BlogPosts;
internal class Post: BaseDomain
{
    public string PostTitle { get; set; }
    public string Subject { get; set; }
    public string Summary { get; set; }
    public string PostBody { get; set; }

    #region Navigation

    public int PostCategoryId { get; set; }

    public PostCategory PostCategory { get; set; }

    #endregion
}
