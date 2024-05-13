using BL.Handler.NoteHandler.NoteRequests;
using BL.Handler.NoteHandler.NoteValidators;
using Core.Enums;
using FluentValidation.TestHelper;

namespace UnitTests.BLTests.ValidatorTests.NoteValidatorTests;
public class ChangePriorityValidatorTests
{
    private ChangePriorityRequestValidator _validator;

    public ChangePriorityValidatorTests()
    {
        _validator = new ChangePriorityRequestValidator();
    }

    [Fact]
    public void Validate_CorrectData_ShouldNotHaveValidationErrors()
    {
        var request = new ChangePriorityRequest(Guid.NewGuid(), NotesPriority.None);

        var result = _validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.NoteId);
        result.ShouldNotHaveValidationErrorFor(x => x.Priority);
    }

    [Fact]
    public void Validate_InCorrectData_ShouldHaveValidationErrors()
    {
        var request = new ChangePriorityRequest(Guid.Empty, NotesPriority.None);

        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.NoteId);
    }
}
