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
using Blog.Application.Articles.Commands.EditArticle;
using Blog.Application.Articles.Queries.GetArticleList;

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
        public IActionResult Index(GetArticleListQuery getArticleList)
        {
            var articles = _mediator.Send(getArticleList).Result;
            return View(articles);
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
        [HttpGet]
        public IActionResult Edit(FindArticleQuery articleQuery)
        {
            var result = _mediator.Send(articleQuery).Result;
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditArticleCommand articleCommand)
        {
            var result = await _mediator.Send(articleCommand);
            return View();
        }


    }
}
