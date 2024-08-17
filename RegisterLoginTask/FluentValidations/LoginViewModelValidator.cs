using RegisterLoginTask.Models;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace RegisterLoginTask.FluentValidations
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid EmailAddress");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
