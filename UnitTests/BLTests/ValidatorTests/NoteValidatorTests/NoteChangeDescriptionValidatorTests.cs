using BL.Handler.NoteHandler.NoteRequests;
using BL.Handler.NoteHandler.NoteValidators;
using FluentValidation.TestHelper;

namespace UnitTests.BLTests.ValidatorTests.NoteValidatorTests;
public class NoteChangeDescriptionValidatorTests
{
    private readonly ChangeDescriptionRequestValidator _validator;

    public NoteChangeDescriptionValidatorTests()
    {
        _validator = new ChangeDescriptionRequestValidator();
    }

    [Fact]
    public void Validate_CorrectData_ShouldNotHaveValidationErrors()
    {
        var request = new ChangeDescriptionRequest(Guid.NewGuid(), "Test");

        var result = _validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.NoteId);
        result.ShouldNotHaveValidationErrorFor(x => x.Description);
    }

    [Fact]
    public void Validate_InCorrectData_ShouldHaveValidationErrors()
    {
        var request = new ChangeDescriptionRequest(Guid.Empty, string.Empty);

        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.NoteId);
        result.ShouldHaveValidationErrorFor(x => x.Description);
    }
}
