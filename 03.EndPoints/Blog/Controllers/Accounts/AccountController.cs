using Blog.Application.Users.Commands.RegisterUser;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Blog.Application.Users.Queries;
using Microsoft.AspNetCore.Identity;
using Blog.Domain.Users;

namespace Blog.Controllers.Accounts
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IMediator mediator, SignInManager<User> signInManager)
        {
            _mediator = mediator;
            _signInManager = signInManager;
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
                TempData["SuccessMessage"] = result.Message;
            else
                TempData["ErrorMessage"] = result.Message;
            return View();
        }

        public IActionResult Login(string ReturnUrl = "/")
        {
            return View(new LoginUserQuery() { ReturnUrl = ReturnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserQuery loginUser)
        {
            if (!ModelState.IsValid) 
                return View(loginUser); 
            var result = await _mediator.Send(loginUser);
            if (result.Succeeded)
                return LocalRedirect(loginUser.ReturnUrl);
            if (result.RequiresTwoFactor)
                return RedirectToAction(nameof(TwoFactor));
            TempData["Message"] = "User Notfound";
            return View(loginUser);
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult TwoFactor()
        {
            return View();
        }
    }
}
