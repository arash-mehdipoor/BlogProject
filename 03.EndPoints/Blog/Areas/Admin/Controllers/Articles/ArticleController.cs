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
        public ArticleController(IMediator mediator, UserManager<User> userManager)
        {
            _mediator = mediator; 
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleCommand articleCommand)
        {
            var result = await _mediator.Send(articleCommand);
            return View();
        }
    }
}
