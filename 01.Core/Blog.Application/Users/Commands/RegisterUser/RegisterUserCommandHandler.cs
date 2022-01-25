﻿using AutoMapper;
using Blog.Application.Common;
using Blog.Domain.Users.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Serilog.Events;
using System;
using System.Collections.Generic;

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
            //var user = new User
            //{
            //    FirstName = request.FirstName,
            //    LastName = request.LastName,
            //    Email = request.Email,
            //    UserName = request.Email
            //};

            var user = _mapper.Map<User>(request);
            var result = _userManager.CreateAsync(user, request.Password).Result;
            if (result.Succeeded)
            {
                Serilog.Log.Information($"A new user has been added to the website | UserName : {user.UserName}, {user.FirstName + " " + user.LastName}");
                return new ResponseDto(true, "Registration completed successfully");
            }
            else
            {
                string messge = "";
                foreach (var item in result.Errors)
                {
                    messge += item.Description + Environment.NewLine;
                }
                Serilog.Log.Information($"Failed Register / Error Message : {messge}");
                return new ResponseDto(false, messge);
            }
        }
    }
}
