﻿using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Blog.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Blog.Validators.BaseValidators;
public class PostCategoryCommentModelValidator : AbstractValidator<PostCategoryCommentModel>
{
    public PostCategoryCommentModelValidator()
    {
        RuleFor(x => x.CommentOwnerId)
            .NotNull()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<PostCategoryComment>.InvalidVariableError("comment writer id"));

        RuleFor(x => x.CommentText)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostCategoryComment>.InvalidVariableError("comment text"));

        RuleFor(x => x.IsReply)
            .NotNull()
            .WithState(_ => GenericErrors<PostCategoryComment>.InvalidVariableError("is-reply"));

        RuleFor(x => x.PostCategoryId)
          .NotNull()
          .GreaterThan(0)
          .WithState(_ => GenericErrors<PostCategoryComment>.InvalidVariableError("post category id"));

        RuleFor(x => x.ReplyToCommentId)
          .NotNull()
          .When(x => x.IsReply == true)
          .GreaterThan(0)
          .WithState(_ => GenericErrors<PostCategoryComment>.InvalidVariableError("reply to comment id"));

        RuleFor(x => x.CreatedAt)
            .NotNull()
            .WithState(_ => GenericErrors<PostCategoryComment>.InvalidVariableError("create time"));
        RuleFor(x => x.UpdatedAt)
            .NotNull()
            .WithState(_ => GenericErrors<PostCategoryComment>.InvalidVariableError("update time"));

    }
}

public class PostCommentModelValidator : AbstractValidator<PostCommentModel>
{
    public PostCommentModelValidator()
    {
        RuleFor(x => x.CommentOwnerId)
            .NotNull()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("comment writer id"));

        RuleFor(x => x.CommentText)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("comment text"));

        RuleFor(x => x.IsReply)
            .NotNull()
            .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("is-reply"));

        RuleFor(x => x.PostId)
          .NotNull()
          .GreaterThan(0)
          .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("post id"));

        RuleFor(x => x.ReplyToCommentId)
          .NotNull()
          .When(x => x.IsReply == true)
          .GreaterThan(0)
          .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("reply to comment id"));

        RuleFor(x => x.CreatedAt)
            .NotNull()
            .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("create time"));
        RuleFor(x => x.UpdatedAt)
            .NotNull()
            .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("update time"));

    }
}