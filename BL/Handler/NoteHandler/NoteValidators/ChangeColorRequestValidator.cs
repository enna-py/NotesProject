using BL.Handler.NoteHandler.NoteRequests;
using FluentValidation;

namespace BL.Handler.NoteHandler.NoteValidators;
public class ChangeColorRequestValidator : AbstractValidator<ChangeColorRequest>
{
    public ChangeColorRequestValidator()
    {
        RuleFor(note => note.NoteId)
            .NotEmpty();

        RuleFor(note => note.Color)
            .NotNull()
            .IsInEnum();
    }
}
