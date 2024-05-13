using BL.Handler.UserHandler.UserRequests;
using FluentValidation;

namespace BL.Handler.UserHandler.UserValidators;
public class ChangeEmailRequestValidator : AbstractValidator<ChangeEmailRequest>
{
    public ChangeEmailRequestValidator()
    {
        RuleFor(user => user.UserId)
            .NotEmpty();

        RuleFor(user => user.Email)
            .NotEmpty()
            .EmailAddress()
            .Must(email => email.EndsWith("@gmail.com"))
            .WithMessage("Email must be ended with @gmail.com");
    }
}
