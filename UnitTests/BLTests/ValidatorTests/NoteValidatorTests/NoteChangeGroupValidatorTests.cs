using BL.Handler.NoteHandler.NoteRequests;
using BL.Handler.NoteHandler.NoteValidators;
using Core.Enums;
using FluentValidation.TestHelper;

namespace UnitTests.BLTests.ValidatorTests.NoteValidatorTests;
public class NoteChangeGroupValidatorTests
{
    private ChangeGroupRequestValidator _validator;

    public NoteChangeGroupValidatorTests()
    {
        _validator = new ChangeGroupRequestValidator();
    }

    [Fact]
    public void Validate_CorrectData_ShouldNotHaveValidationErrors()
    {
        var request = new ChangeGroupRequest(Guid.NewGuid(), NotesGroup.None);

        var result = _validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.NoteId);
        result.ShouldNotHaveValidationErrorFor(x => x.Group);
    }

    [Fact]
    public void Validate_InCorrectData_ShouldHaveValidationErrors()
    {
        var request = new ChangeGroupRequest(Guid.Empty, NotesGroup.None);

        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.NoteId);
    }
}
