using Blog.Application.Common;
using Blog.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Blog.Application.Users.Commands.RegisterUser
{


    public class RegisterUserCommandHandler : RequestHandler<RegisterUserCommand, Response>
    {
        private readonly UserManager<User> _userManager;
        public RegisterUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        protected override Response Handle(RegisterUserCommand request)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.Email
            };

            var result = _userManager.CreateAsync(user, request.Password).Result;
            if (result.Succeeded)
                return new Response()
                {
                    IsSuccess = true,
                    SuccessMessage = "Registration completed successfully"
                };
            else
            {
                string messge = "";
                foreach (var item in result.Errors)
                {
                    messge += item.Description + Environment.NewLine;
                }
                return new Response() { ErrorMessage = messge };
            }
        }
    }
}
