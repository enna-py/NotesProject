using BL.Handler.UserHandler.UserRequests;
using BL.Handler.UserHandler.UserValidators;
using FluentValidation.TestHelper;

namespace UnitTests.BLTests.ValidatorTests.UserValidatorTests;
public class UserChangePasswordValidatorTests
{
    private ChangePasswordRequestValidator _validator;

    public UserChangePasswordValidatorTests()
    {
        _validator = new ChangePasswordRequestValidator();
    }

    [Fact]
    public void ChangePassword_CorrectData_ReturnTrue()
    {
        var request = new ChangePasswordRequest(Guid.NewGuid(), "12345678908249");

        var result = _validator.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(x => x.UserId);
        result.ShouldNotHaveValidationErrorFor(x => x.NewPassword);
    }

    [Fact]
    public void ChangePassword_InCorrectData_ReturnFalse()
    {
        var request = new ChangePasswordRequest(Guid.Empty, string.Empty);

        var result = _validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(x => x.UserId);
        result.ShouldHaveValidationErrorFor(x => x.NewPassword);
    }
}
