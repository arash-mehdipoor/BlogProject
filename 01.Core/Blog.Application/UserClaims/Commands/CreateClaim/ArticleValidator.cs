using FluentValidation;

namespace Blog.Application.UserClaims.Commands.CreateClaim
{
    public class ClaimValidator : AbstractValidator<CreateClaimCommand>
    {
        public ClaimValidator()
        {
            RuleFor(u => u.ClaimType).Length(2, 150).NotEmpty().WithMessage("Can Not Be Null");
            RuleFor(u => u.ClaimValue).NotEmpty().WithMessage("Can Not Be Null");
        }
    }
}
