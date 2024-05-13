using Core.Enums;

namespace BL.Handler.NoteHandler.NoteRequests;
public record ChangeColorRequest(Guid NoteId, NotesColor Color);
