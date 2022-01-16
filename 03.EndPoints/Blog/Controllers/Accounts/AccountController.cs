using Blog.Application.Users.Commands.RegisterUser;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Blog.Application.Users.Queries;

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

        public IActionResult Login(string ReturnUrl = "/")
        {
            return View(new LoginUserQuery() { ReturnUrl = ReturnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserQuery loginUser)
        {
            var result = await _mediator.Send(loginUser);
            if (result.Succeeded)
                return LocalRedirect(loginUser.ReturnUrl);
            if (result.RequiresTwoFactor)
                return RedirectToAction(nameof(TwoFactor));
            TempData["Message"] = "User Notfound";
            return View(loginUser);
        }

        public IActionResult TwoFactor()
        {
            return View();
        }
    }
}
