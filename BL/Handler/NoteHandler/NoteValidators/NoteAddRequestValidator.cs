using BL.Handler.NoteHandler.NoteRequests;
using FluentValidation;

namespace BL.Handler.NoteHandler.NoteValidators;
public class NoteAddRequestValidator : AbstractValidator<NoteAddRequest>
{
    public NoteAddRequestValidator()
    {
        RuleFor(note => note.Name)
            .MaximumLength(15)
            .NotEmpty();

        RuleFor(note => note.Description)
            .NotEmpty()
            .MaximumLength(100);
        
        RuleFor(note => note.UserId)
            .NotEmpty();
    }
}
