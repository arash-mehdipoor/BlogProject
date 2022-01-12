using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Users.Commands.RegisterUser
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator()
        {
            RuleFor(u => u.FirstName).Length(2, 250).NotEmpty().WithMessage("Can Not Be Null");
            RuleFor(u => u.LastName).Length(2, 250).NotEmpty().WithMessage("Can Not Be Null");
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Invalid email format.")
                .EmailAddress().WithMessage("Invalid email format."); 
            RuleFor(u => u.Password).NotEmpty().WithMessage("Can Not Be Null");
            RuleFor(u => u.ConfirmPassword).NotEmpty().WithMessage("Can Not Be Null");
            RuleFor(u => u.Password).Equal(u => u.ConfirmPassword).WithMessage("The password must be the same as repeating the password");
        }
    }
}
