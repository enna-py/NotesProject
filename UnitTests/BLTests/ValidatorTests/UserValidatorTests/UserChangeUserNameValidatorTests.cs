using BL.Handler.UserHandler.UserRequests;
using BL.Handler.UserHandler.UserValidators;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.BLTests.ValidatorTests.UserValidatorTests;
public class UserChangeUserNameValidatorTests
{
    private ChangeUserNameRequestValidator _validator;

    public UserChangeUserNameValidatorTests()
    {
        _validator = new ChangeUserNameRequestValidator();
    }

    [Fact]
    public void ChangeName_CorrectData_ReturnTrue()
    {
        var request = new ChangeUserNameRequest(Guid.NewGuid(), "TestName");

        var result = _validator.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(x => x.UserId);
        result.ShouldNotHaveValidationErrorFor(x => x.NewUserName);
    }

    [Fact]
    public void ChangeName_InCorrectData_ReturnFalse()
    {
        var request = new ChangeUserNameRequest(Guid.Empty, string.Empty);

        var result = _validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(x => x.UserId);
        result.ShouldHaveValidationErrorFor(x => x.NewUserName);
    }
}
