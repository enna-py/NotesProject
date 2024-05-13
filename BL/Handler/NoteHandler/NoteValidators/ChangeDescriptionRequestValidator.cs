using BL.Handler.NoteHandler.NoteRequests;
using FluentValidation;

namespace BL.Handler.NoteHandler.NoteValidators;
public class ChangeDescriptionRequestValidator : AbstractValidator<ChangeDescriptionRequest>
{
    public ChangeDescriptionRequestValidator()
    {
        RuleFor(note => note.NoteId)
            .NotEmpty();

        RuleFor(note => note.Description)
            .NotEmpty()
            .MaximumLength(100);
    }
}
