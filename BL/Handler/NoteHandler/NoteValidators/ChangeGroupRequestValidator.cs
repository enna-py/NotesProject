using BL.Handler.NoteHandler.NoteRequests;
using FluentValidation;

namespace BL.Handler.NoteHandler.NoteValidators;
public class ChangeGroupRequestValidator : AbstractValidator<ChangeGroupRequest>
{
    public ChangeGroupRequestValidator()
    {
        RuleFor(note => note.NoteId)
            .NotEmpty();

        RuleFor(note => note.Group)
            .NotEmpty()
            .IsInEnum();
    }
}
