using BL.Handler.UserHandler.UserRequests;
using BL.Handler.UserHandler.UserValidators;
using FluentValidation.TestHelper;

namespace UnitTests.BLTests.ValidatorTests.UserValidatorTests;
public class UserAddValidatorTests
{
    private UserAddRequestValidator _validator;

    public UserAddValidatorTests()
    {
        _validator = new UserAddRequestValidator();
    }

    [Fact]
    public void AddUser_CorrectData_returnsGuid()
    {
        var request = new UserAddRequest("TestName", "TestEmail@gmail.com", "12323456789Test", "TestUserName");

        var result = _validator.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(x => x.Email);
        result.ShouldNotHaveValidationErrorFor(x => x.UserName);
        result.ShouldNotHaveValidationErrorFor(x => x.Password);
        result.ShouldNotHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void AddUser_InCorrectData_returnsEx()
    {
        var request = new UserAddRequest(string.Empty, string.Empty, string.Empty, string.Empty);

        var result = _validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(x => x.Email);
        result.ShouldHaveValidationErrorFor(x => x.UserName);
        result.ShouldHaveValidationErrorFor(x => x.Password);
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }
}
