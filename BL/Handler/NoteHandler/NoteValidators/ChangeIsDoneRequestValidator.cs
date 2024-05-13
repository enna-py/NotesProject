using BL.Handler.NoteHandler.NoteRequests;
using FluentValidation;

namespace BL.Handler.NoteHandler.NoteValidators;
public class ChangeIsDoneRequestValidator : AbstractValidator<ChangeIsDoneRequest>
{
    public ChangeIsDoneRequestValidator()
    {
        RuleFor(note => note.NoteId)
            .NotEmpty();
    }
}

