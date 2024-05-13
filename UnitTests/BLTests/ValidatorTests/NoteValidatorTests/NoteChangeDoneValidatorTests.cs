using BL.Handler.NoteHandler.NoteRequests;
using BL.Handler.NoteHandler.NoteValidators;
using FluentValidation.TestHelper;

namespace UnitTests.BLTests.ValidatorTests.NoteValidatorTests;
public class NoteChangeDoneValidatorTests
{
    private readonly ChangeIsDoneRequestValidator _validator;

    public NoteChangeDoneValidatorTests()
    {
        _validator = new ChangeIsDoneRequestValidator();
    }

    [Fact]
    public void Validate_CorrectData_ShouldNotHaveValidationErrors()
    {
        var request = new ChangeIsDoneRequest(Guid.NewGuid());

        var result = _validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.NoteId);
    }

    [Fact]
    public void Validate_InCorrectData_ShouldNotHaveValidationErrors()
    {
        var request = new ChangeIsDoneRequest(Guid.Empty);

        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.NoteId);
    }
}