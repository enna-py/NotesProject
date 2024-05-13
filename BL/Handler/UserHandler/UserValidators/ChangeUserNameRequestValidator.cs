using BL.Handler.UserHandler.UserRequests;
using FluentValidation;

namespace BL.Handler.UserHandler.UserValidators;
public class ChangeUserNameRequestValidator : AbstractValidator<ChangeUserNameRequest>
{
    public ChangeUserNameRequestValidator()
    {
        RuleFor(user => user.UserId)
            .NotEmpty();

        RuleFor(user => user.NewUserName)
            .NotEmpty()
            .MaximumLength(15);
    }
}
