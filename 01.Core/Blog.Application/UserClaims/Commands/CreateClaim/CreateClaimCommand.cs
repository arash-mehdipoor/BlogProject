using Blog.Application.Common;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.UserClaims.Commands.CreateClaim
{
    public class CreateClaimCommand : IRequest<ResponseDto>
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
