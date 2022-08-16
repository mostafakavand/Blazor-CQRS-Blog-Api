using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Domains.Blog.BlogPosts;
internal class PostCategory: BaseDomain
{
    public string CategoryTitle { get; set; }
    public string CategorySubject { get; set; }
    public string CategoryIcon { get; set; }

    #region Navigation

    public List<Post> CategoryPosts { get; set; }

    #endregion
}
