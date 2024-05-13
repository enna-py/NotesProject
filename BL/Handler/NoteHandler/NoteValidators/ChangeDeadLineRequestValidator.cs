using BL.Handler.NoteHandler.NoteRequests;
using FluentValidation;

namespace BL.Handler.NoteHandler.NoteValidators;
public class ChangeDeadLineRequestValidator : AbstractValidator<ChangeDeadLineRequest>
{
    public ChangeDeadLineRequestValidator()
    {
        RuleFor(note => note.NoteId)
            .NotEmpty();

        RuleFor(note => note.DeadLine)
            .Must(x => x != DateTime.MinValue);
    }
}