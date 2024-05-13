using BL.Handler.UserHandler.UserRequests;
using FluentValidation;

namespace BL.Handler.UserHandler.UserValidators;
public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
{
    public ChangePasswordRequestValidator()
    {
        RuleFor(user => user.UserId)
            .NotEmpty();

        RuleFor(user => user.NewPassword)
            .NotEmpty()
            .MaximumLength(20)
            .MinimumLength(10);
    }
}
