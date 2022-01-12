using Blog.Application.Users.Commands.RegisterUser;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
namespace Blog.Controllers.Accounts
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserCommand registerUser)
        {
            var result = await _mediator.Send(registerUser);
            if (result.IsSuccess)
                TempData["SuccessMessage"] = result.SuccessMessage;
            else
                TempData["ErrorMessage"] = result.ErrorMessage;
            return View();
        }

    }
}
