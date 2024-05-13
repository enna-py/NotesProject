using BL.Handler.UserHandler.UserRequests;
using BL.Handler.UserHandler.UserValidators;
using FluentValidation.TestHelper;

namespace UnitTests.BLTests.ValidatorTests.UserValidatorTests;
public class UserChangeNameValidatorTests
{
    private ChangeNameUserRequestValidator _validator;

    public UserChangeNameValidatorTests()
    {
        _validator = new ChangeNameUserRequestValidator();
    }

    [Fact]
    public void ChangeName_CorrectData_ReturnTrue()
    {
        var request = new ChangeNameUserRequest(Guid.NewGuid(), "TestName");

        var result = _validator.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(x => x.UserId);
        result.ShouldNotHaveValidationErrorFor(x => x.NewName);
    }

    [Fact]
    public void ChangeName_InCorrectData_ReturnFalse()
    {
        var request = new ChangeNameUserRequest(Guid.Empty, string.Empty);

        var result = _validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(x => x.UserId);
        result.ShouldHaveValidationErrorFor(x => x.NewName);
    }
}
