using Core.Enums;

namespace BL.Responses.Note;
public record NoteGetAllResponse(Guid Id, string Name, string Description, NotesGroup Group, NotesPriority Priority);
