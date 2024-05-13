using BL.Handler.NoteHandler.NoteRequests;
using BL.Handler.NoteHandler.NoteValidators;
using FluentValidation.TestHelper;

namespace UnitTests.BLTests.ValidatorTests.NoteValidatorTests;
public class NoteAddValidatorTests
{
    private readonly NoteAddRequestValidator _validator;

    public NoteAddValidatorTests()
    {
        _validator = new NoteAddRequestValidator();
    }

    [Fact]
    public void Validate_CorrectData_ShouldNotHaveValidationErrors()
    {
        var request = new NoteAddRequest("TestName", "Test Description", Guid.NewGuid());

        var result = _validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.Name);
        result.ShouldNotHaveValidationErrorFor(x => x.Description);
        result.ShouldNotHaveValidationErrorFor(x => x.UserId);
    }

    [Fact]
    public void Validate_InCorrectData_ShouldHaveValidationErrors()
    {
        var request = new NoteAddRequest(string.Empty, string.Empty, Guid.Empty);

        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.Name);
        result.ShouldHaveValidationErrorFor(x => x.Description);
        result.ShouldHaveValidationErrorFor(x => x.UserId);
    }
}
