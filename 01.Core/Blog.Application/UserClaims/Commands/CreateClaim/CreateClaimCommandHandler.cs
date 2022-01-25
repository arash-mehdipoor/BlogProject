using Blog.Application.Common;
using Blog.Domain.Users.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Blog.Application.UserClaims.Commands.CreateClaim
{
    public class CreateClaimCommandHandler : RequestHandler<CreateClaimCommand, ResponseDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _accessor;
        public ClaimsPrincipal User => _accessor.HttpContext.User;

        public CreateClaimCommandHandler(IHttpContextAccessor accessor, UserManager<User> userManager)
        {
            _userManager = userManager;
            _accessor = accessor ?? throw new ArgumentNullException(nameof(accessor));
        }

        protected override ResponseDto Handle(CreateClaimCommand request)
        {

            var user = _userManager.GetUserAsync(User).Result;
            Claim newClaim = new Claim(request.ClaimType, request.ClaimValue, ClaimValueTypes.String);
            var result = _userManager.AddClaimAsync(user, newClaim).Result;
            if (result.Succeeded)
                return new ResponseDto(true, $"New claim added to user : {user.UserName}");
            else
            {
                string messge = "";
                foreach (var item in result.Errors)
                {
                    messge += item.Description + Environment.NewLine;
                }
                return new ResponseDto(false, messge);
            }
        }
    }
}
