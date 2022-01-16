﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Blog.Application.Articles.Commands.CreateArticle;
using Microsoft.AspNetCore.Identity;
using Blog.Domain.Users;

namespace Blog.Controllers.Blogs
{
    public class ArticleController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<User> _userManager;
        public ArticleController(IMediator mediator, UserManager<User> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

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
