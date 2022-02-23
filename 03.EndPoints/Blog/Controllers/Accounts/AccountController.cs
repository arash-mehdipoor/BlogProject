using Blog.Application.Users.Commands.RegisterUser;
using Blog.Application.Users.Queries.Login;
using Blog.Domain.Users.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserCommand registerUser)
        {
            var result = await _mediator.Send(registerUser);
            if (result.IsSuccess)
                return RedirectToAction(nameof(Login));
            TempData["ErrorMessage"] = result.Message;
            return View(registerUser);
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl = "/")
        {
            return View(new LoginUserQuery() { ReturnUrl = ReturnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult TwoFactor()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
