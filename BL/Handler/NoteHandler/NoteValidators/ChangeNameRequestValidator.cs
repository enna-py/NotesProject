using BL.Handler.NoteHandler.NoteRequests;
using FluentValidation;

namespace BL.Handler.NoteHandler.NoteValidators;
public class ChangeNameRequestValidator : AbstractValidator<ChangeNameRequest>
{
    public ChangeNameRequestValidator()
    {
        RuleFor(note => note.NoteId)
            .NotEmpty();

        RuleFor(note => note.NewName)
            .NotEmpty()
            .MaximumLength(15);
    }
}
