using BL.Handler.UserHandler.UserRequests;
using BL.Handler.UserHandler.UserValidators;
using FluentValidation.TestHelper;

namespace UnitTests.BLTests.ValidatorTests.UserValidatorTests;
public class UserChangeEmailValidatorTests
{
    private ChangeEmailRequestValidator _validator;

    public UserChangeEmailValidatorTests()
    {
        _validator = new ChangeEmailRequestValidator();
    }

    [Fact]
    public void ChangeEmail_CorrectData_ReturnsTrue()
    {
        var request = new ChangeEmailRequest(Guid.NewGuid(), "test@gmail.com");

        var result = _validator.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(x => x.UserId);
        result.ShouldNotHaveValidationErrorFor(x => x.Email);
    }

    [Fact]
    public void ChangeEmail_InCorrectData_ReturnFalse()
    {
        var request = new ChangeEmailRequest(Guid.Empty, string.Empty);

        var result = _validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(x => x.UserId);
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }
}
