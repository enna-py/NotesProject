using BL.Handler.NoteHandler.NoteRequests;
using BL.Handler.NoteHandler.NoteValidators;
using Core.Enums;
using FluentValidation.TestHelper;

namespace UnitTests.BLTests.ValidatorTests.NoteValidatorTests;

public class NoteChangeColorValidatorTests
{
    private readonly ChangeColorRequestValidator _validator;

    public NoteChangeColorValidatorTests()
    {
        _validator = new ChangeColorRequestValidator();
    }

    [Fact]
    public void Validate_CorrectData_ShouldNotHaveValidationErrors()
    {
        var request = new ChangeColorRequest(Guid.NewGuid(), NotesColor.Red);

        var result = _validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.NoteId);
        result.ShouldNotHaveValidationErrorFor(x => x.Color);
    }

    [Fact]
    public void Validate_IncorrectData_ShouldHaveValidationErrors()
    {
        var request = new ChangeColorRequest(Guid.Empty, NotesColor.Red);

        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.NoteId);
    }
}
