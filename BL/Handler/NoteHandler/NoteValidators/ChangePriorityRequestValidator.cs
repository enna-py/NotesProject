using BL.Handler.NoteHandler.NoteRequests;
using FluentValidation;

namespace BL.Handler.NoteHandler.NoteValidators;
public class ChangePriorityRequestValidator : AbstractValidator<ChangePriorityRequest>
{
    public ChangePriorityRequestValidator()
    {
        RuleFor(note => note.NoteId)
            .NotEmpty();

        RuleFor(note => note.Priority)
            .NotEmpty()
            .IsInEnum();
    }
}
