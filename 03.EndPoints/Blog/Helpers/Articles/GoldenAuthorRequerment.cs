using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Helpers.Articles
{
    public class GoldenAuthorRequerment : IAuthorizationRequirement
    {
        public int ArticleWrittenCount { get; set; }
        public GoldenAuthorRequerment(int articleWrittenCount)
        {
            ArticleWrittenCount = articleWrittenCount;
        }
    }
    public class GoldenAuthorRequermentHandler : AuthorizationHandler<GoldenAuthorRequerment>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GoldenAuthorRequerment requirement)
        {
            var claim = context.User.FindFirst("GoldenAuthor");
            if (claim != null)
            {
                int articleWrittenCount = int.Parse(claim?.Value);
                if (articleWrittenCount > requirement.ArticleWrittenCount)
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }


}

