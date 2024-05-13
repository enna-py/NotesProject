using BL.Handler.UserHandler.UserRequests;
using FluentValidation;

namespace BL.Handler.UserHandler.UserValidators;
public class UserAddRequestValidator : AbstractValidator<UserAddRequest>
{
    public UserAddRequestValidator()
    {
        RuleFor(user => user.UserName)
            .NotEmpty()
            .MaximumLength(15);

        RuleFor(user => user.Email)
            .NotEmpty()
            .EmailAddress()
            .Must(email => email.EndsWith("@gmail.com"))
            .WithMessage("Email must be ended with @gmail.com");

        RuleFor(user => user.Password)
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(15);

        RuleFor(user => user.Name)
            .NotEmpty()
            .MaximumLength(15)
            .Must(name => !name.Any(char.IsDigit))
            .WithMessage("The name cannot have numbers");
    }
}
