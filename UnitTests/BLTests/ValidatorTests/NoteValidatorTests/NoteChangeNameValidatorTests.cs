using BL.Handler.NoteHandler.NoteRequests;
using BL.Handler.NoteHandler.NoteValidators;
using FluentValidation.TestHelper;

namespace UnitTests.BLTests.ValidatorTests.NoteValidatorTests;
public class NoteCHangeNameValidatorTests
{
    private readonly ChangeNameRequestValidator _validator;

    public NoteCHangeNameValidatorTests()
    {
        _validator = new ChangeNameRequestValidator();
    }

    [Fact]
    public void Validate_CorrectData_ShouldNotHaveValidationErrors()
    {
        var request = new ChangeNameRequest(Guid.NewGuid(), "TestName");

        var result = _validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.NoteId);
        result.ShouldNotHaveValidationErrorFor(x => x.NewName);
    }
    [Fact]
    public void Validate_InCorrectData_ShouldHaveValidationErrors()
    {
        var request = new ChangeNameRequest(Guid.Empty, string.Empty);

        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.NoteId);
        result.ShouldHaveValidationErrorFor(x => x.NewName);
    }
}