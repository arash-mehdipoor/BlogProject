using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Blog.Application.Articles.Commands.CreateArticle;

namespace Blog.Controllers.Blogs
{
    public class ArticleController : Controller
    {
        private readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

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
