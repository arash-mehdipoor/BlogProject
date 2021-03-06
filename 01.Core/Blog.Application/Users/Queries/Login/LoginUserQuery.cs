using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Blog.Application.Users.Queries.Login
{
    public class LoginUserQuery : IRequest<SignInResult>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
