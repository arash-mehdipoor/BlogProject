using AutoMapper;
using Blog.Domain.Articles.Interfaces;
using Blog.Domain.Users.Entity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;

namespace Blog.Application.Articles.Commands.EditArticle
{


    public class EditArticleCommandHandler : RequestHandler<EditArticleCommand, int>
    {
        private readonly IArticleRepasitory _article;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;
        private readonly IAuthorizationService _authorizationService;
        public ClaimsPrincipal User => _accessor.HttpContext.User;

        public EditArticleCommandHandler(IArticleRepasitory article,
            IMapper mapper,
            IHttpContextAccessor accessor,
            IAuthorizationService authorizationService,
            UserManager<User> userManager)
        {
            _article = article;
            _mapper = mapper;
            _accessor = accessor ?? throw new ArgumentNullException(nameof(accessor));
            _authorizationService = authorizationService;
            _userManager = userManager;
        }

        protected override int Handle(EditArticleCommand request)
        {
            var article = _article.Get(request.Id);
            request.UserId = article.UserId;
            request.UserName = article.UserName;
            _mapper.Map(request, article);
            var res = _authorizationService.AuthorizeAsync(User, request, "IsBlogForUser").Result;

            if (res.Succeeded)
            {
                _article.SaveChange();
            }
            return -1;
        }
    }
}
