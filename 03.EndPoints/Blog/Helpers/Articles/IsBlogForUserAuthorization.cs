using Blog.Application.Articles.Commands.EditArticle;
using Blog.Application.Articles.Queries.GetArticleList;
using Blog.Domain.Articles;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Helpers.Articles
{
    public class BlogForUserRequirement : IAuthorizationRequirement
    {
    }

    public class IsBlogForUserAuthorization : AuthorizationHandler<BlogForUserRequirement, EditArticleCommand>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BlogForUserRequirement requirement, EditArticleCommand resource)
        {
            if (context.User.Identity?.Name == resource.UserName)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
