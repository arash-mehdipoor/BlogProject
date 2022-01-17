using Blog.Application.UserClaims.Commands.CreateClaim;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
namespace Blog.Areas.Admin.Controllers.UserClaim
{
    [Area("Admin")]
    public class UserClaimController : Controller
    {
        private readonly IMediator _mediator;

        public UserClaimController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View(User.Claims);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateClaimCommand claimCommand)
        {
            var result = _mediator.Send(claimCommand).Result;
            if (result.IsSuccess)
            {
                claimCommand = new CreateClaimCommand();
                TempData["SuccessMessage"] = result.Message;
            }
            else
                TempData["ErrorMessage"] = result.Message;
            return View(claimCommand);
        }
    }
}
