using MediatR;
using System;
using Microsoft.AspNetCore.Identity;
using Blog.Domain.Users.Entity;
using Blog.Application.Users.Queries.Login;

namespace Blog.Application.Users.Queries
{
    public class LoginUserQueryHandler : RequestHandler<LoginUserQuery, SignInResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public LoginUserQueryHandler(UserManager<User> userManager, SignInManager<User> signinManager)
        {
            _userManager = userManager;
            _signInManager = signinManager;
        }

        protected override SignInResult Handle(LoginUserQuery request)
        {
            var user = _userManager.FindByNameAsync(request.UserName).Result;
            if (user != null)
            {
                _signInManager.SignOutAsync();
                var result = _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true).Result;
                return result;
            }
            return SignInResult.Failed;
        }
    }
}
