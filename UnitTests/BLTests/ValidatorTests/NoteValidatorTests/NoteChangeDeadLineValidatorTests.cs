using BL.Handler.NoteHandler.NoteRequests;
using BL.Handler.NoteHandler.NoteValidators;
using FluentValidation.TestHelper;

namespace UnitTests.BLTests.ValidatorTests.NoteValidatorTests;
public class NoteChangeDeadLineValidatorTests
{
    private readonly ChangeDeadLineRequestValidator _validator;

    public NoteChangeDeadLineValidatorTests()
    {
        _validator = new ChangeDeadLineRequestValidator();
    }

    [Fact]
    public void Validate_CorrectData_ShouldNotHaveValidationErrors()
    {
        var request = new ChangeDeadLineRequest(Guid.NewGuid(), DateTime.Now);

        var result = _validator.TestValidate(request);
        result.ShouldNotHaveValidationErrorFor(x => x.NoteId);
        result.ShouldNotHaveValidationErrorFor(x => x.DeadLine);
    }

    [Fact]
    public void Validate_InCorrectData_ShouldHaveValidationErrors()
    {
        var request = new ChangeDeadLineRequest(Guid.Empty, DateTime.MinValue);

        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.NoteId);
        result.ShouldHaveValidationErrorFor(x => x.DeadLine);
    }
}
