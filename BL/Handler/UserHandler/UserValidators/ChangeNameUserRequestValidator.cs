using BL.Handler.UserHandler.UserRequests;
using FluentValidation;

namespace BL.Handler.UserHandler.UserValidators;
public class ChangeNameUserRequestValidator : AbstractValidator<ChangeNameUserRequest>
{
    public ChangeNameUserRequestValidator()
    {
        RuleFor(user => user.UserId)
            .NotEmpty();

        RuleFor(user => user.NewName)
            .NotEmpty()
            .MaximumLength(15)
            .Must(name => !name.Any(char.IsDigit))
            .WithMessage("The name cannot have numbers");
    }
}
