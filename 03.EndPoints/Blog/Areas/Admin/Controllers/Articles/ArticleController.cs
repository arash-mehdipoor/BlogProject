using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Blog.Application.Articles.Commands.CreateArticle;
using Microsoft.AspNetCore.Identity;
using Blog.Domain.Users;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Areas.Admin.Controllers.Articles
{
    [Authorize]
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<User> _userManager;
        public ArticleController(IMediator mediator, UserManager<User> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleCommand articleCommand)
        {
            var user = await _userManager.GetUserAsync(User);
            articleCommand.UserId = user.Id;
            var result = await _mediator.Send(articleCommand);
            return View();
        }
    }
}
