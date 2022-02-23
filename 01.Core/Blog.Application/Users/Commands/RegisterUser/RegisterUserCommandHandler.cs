using AutoMapper;
using Blog.Application.Common;
using Blog.Domain.Users.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;

namespace Blog.Application.Users.Commands.RegisterUser
{


    public class RegisterUserCommandHandler : RequestHandler<RegisterUserCommand, ResponseDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        protected override ResponseDto Handle(RegisterUserCommand request)
        {

            request.UserName = request.Email;
            var user = _mapper.Map<User>(request);
            var result = _userManager.CreateAsync(user, request.Password).Result;
            if (result.Succeeded)
            {
                Serilog.Log.Information("A new user has been added to the website | UserName :{0},{1}", user.UserName, user.FirstName + " " + user.LastName);
                return new ResponseDto(true, "Registration completed successfully");
            }
            else
            {
                string messge = "";
                foreach (var item in result.Errors)
                {
                    messge += item.Description + Environment.NewLine;
                }
                Serilog.Log.Information("Failed Register / Error Message :{0}", messge);
                return new ResponseDto(false, messge);
            }
        }
    }
}
