using AutoMapper;
using Blog.Domain.Articles.Entitiy;
using Blog.Domain.Articles.Interfaces;
using Blog.Domain.Users.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Blog.Application.Articles.Commands.CreateArticle
{


    public class CreateArticleCommandHandler : RequestHandler<CreateArticleCommand, int>
    {
        private readonly IArticleRepasitory _article;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;
        public ClaimsPrincipal User => _accessor.HttpContext.User;

        public CreateArticleCommandHandler(IArticleRepasitory article,
            IMapper mapper,
            IHttpContextAccessor accessor,
            UserManager<User> userManager)
        {
            _article = article;
            _mapper = mapper;
            _accessor = accessor ?? throw new ArgumentNullException(nameof(accessor));
            _userManager = userManager;
        }

        protected override int Handle(CreateArticleCommand request)
        {
            var user = _userManager.GetUserAsync(User).Result;
            request.UserId = user.Id;
            request.UserName = user.UserName;
            var article = _mapper.Map<Article>(request);
            _article.Add(article);

            // Add Claim For User
            //var articleCount = _article.GetArticleCountByUserId(user.Id);
            //var claimBefor = User.FindFirst("GoldenAuthor");
            //var claimUser = _userManager.GetClaimsAsync(user).Result;

            //if (claimUser.Count == 0)
            //{
            //    Claim newClaim = new Claim("GoldenAuthor", articleCount.ToString(), ClaimValueTypes.String);
            //    var addClaim = _userManager.AddClaimAsync(user, newClaim).Result;
            //}
            //else
            //{
            //    Claim newClaim = new Claim("GoldenAuthor", articleCount.ToString(), ClaimValueTypes.String);
            //    var updateClaim = _userManager.ReplaceClaimAsync(user, claimBefor, newClaim).Result;
            //}
            return article.Id;
        }
    }
}
