using AutoMapper;
using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Persistence.Models.Blog.Base;
using Dayana.Shared.Persistence.Models.Blog.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.AutoMapperProfile;
public class BlogAutoMapperProfile : Profile
{
	public BlogAutoMapperProfile()
	{
		CreateMap<Post, PostModel>().ReverseMap();
        CreateMap<PostCategory, PostCategoryModel>().ReverseMap();
        CreateMap<PostIssue, PostIssueModel>().ReverseMap();
        CreateMap<PostCategoryIssue, PostCategoryIssueModel>().ReverseMap();
        CreateMap<PostComment, PostCommentModel>().ReverseMap();
        CreateMap<PostIssueComment, PostIssueCommentModel>().ReverseMap();
        CreateMap<PostCategoryIssueComment, PostCategoryIssueCommentModel>().ReverseMap();
    }
}
